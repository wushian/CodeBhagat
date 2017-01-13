using Angular2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Angular2.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class UsersAdminController : Controller
    {
        public UsersAdminController()
        {
        }

        public UsersAdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        //
        // GET: /Users/
        //
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await UserManager.Users.ToListAsync();
            return Json(new
            {
                users = users.ToList().Select(p => new
                {
                    p.FirstName,
                    p.UserName,
                    p.Email,
                    p.Id,
                    Roles = p.Roles.Count() > 0 ? string.Join(",", p.Roles.ToList().Select(q => RoleManager.FindById(q.RoleId).Name).ToList()) : ""
                })
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Users/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            //var userRoles = user.Roles.Count() > 0 ? string.Join(",", user.Roles.ToList().Select(q => RoleManager.FindById(q.RoleId).Name).ToList()) : "";
            var userRoles = user.Roles.Count() > 0 ? string.Join(",", user.Roles.ToList().Select(q => q.RoleId).ToList()) : "";

			return Json(new
            {
                user = new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Address,
                    user.City,
                    user.State,
                    user.PostalCode,
                    user.UserName,
                    user.Email,
                    user.PhoneNumber,
                    Roles = userRoles
				}
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Users/Create
        public async Task<ActionResult> Create()
        {
            //Get the list of Roles
            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Name");
            return View();
        }

        ////
        //// POST: /Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel userViewModel, params string[] selectedRoles)
        {
            bool status = false;
            string message = string.Empty;

            try
            {

                var isUser = UserManager.FindByName(userViewModel.UserName);
                var isEmail = UserManager.FindByEmail(userViewModel.Email);

                if (isUser != null)
                {
                    message = "User name alredy exist.";
                    return Json(new { status, message }, JsonRequestBehavior.AllowGet);
                }
                if (isEmail != null)
                {
                    message = "Email alredy exist.";
                    return Json(new { status, message }, JsonRequestBehavior.AllowGet);
                }

                var user = new ApplicationUser
                {
                    UserName = userViewModel.UserName,
                    Email = userViewModel.Email,

                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    Address = userViewModel.Address,
                    City = userViewModel.City,
                    State = userViewModel.State,
                    PostalCode = userViewModel.PostalCode
                };

                var adminresult = await UserManager.CreateAsync(user, userViewModel.Password);

                //Add User to the selected Roles 
                if (adminresult.Succeeded)
                {
                    if (selectedRoles != null)
                    {
                        var result = await UserManager.AddToRolesAsync(user.Id, selectedRoles);
                        if (!result.Succeeded)
                        {
                            message = result.Errors.First();
                        }
                        else
                        {
                            message = "user create successfully.";
                            status = true;
                        }
                    }
                }
                else
                {
                    message = adminresult.Errors.First();
                    return Json(new { status, message }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = false;
            }

            return Json(new { status, message }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Users/Edit/1
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userRoles = await UserManager.GetRolesAsync(user.Id);

            return View(new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                /*
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                City = user.City,
                State = user.State,
                PostalCode = user.PostalCode, */
                RolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                })
            });
        }

        //
        // POST: /Users/Edit/5
        [HttpPut]
        //   //  [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Email,Id,UserName,FirstName,LastName,Address,City,State,PostalCode,")] EditUserViewModel editUser, params string[] selectedRoles)
        {
            bool status = false;
            string message = string.Empty;

            try
            {
                // Find User
                var user = await UserManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    message = "User not exist.";
                    return Json(new { status, message }, JsonRequestBehavior.AllowGet);
                }

                // Find Roles for the user
                var userRoles = await UserManager.GetRolesAsync(editUser.Id);
                if (UserManager.Users.Any(p => p.UserName == editUser.UserName && p.Id != editUser.Id))
                {
                    editUser.RolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
                   {
                       Selected = userRoles.Contains(x.Name),
                       Text = x.Name,
                       Value = x.Name
                   });
                    message = "User name ready exist.";
                    return Json(new { status, message }, JsonRequestBehavior.AllowGet);
                }

                if (UserManager.Users.Any(p => p.Email == editUser.Email && p.Id != editUser.Id))
                {
                    editUser.RolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
                    {
                        Selected = userRoles.Contains(x.Name),
                        Text = x.Name,
                        Value = x.Name
                    });

                    message = "Email address already exist.";
                    return Json(new { status, message }, JsonRequestBehavior.AllowGet);
                }

                // Edit User Details
                user.UserName = editUser.UserName;
                user.Email = editUser.Email;
                user.FirstName = editUser.FirstName;
                user.LastName = editUser.LastName;
                user.Address = editUser.Address;
                user.City = editUser.City;
                user.State = editUser.State;
                user.PostalCode = editUser.PostalCode;

				var roles = RoleManager.Roles.ToList();
				selectedRoles = selectedRoles ?? new string[] { };
				List<string> empty = new List<string>() { null };

				var rolesToAdd = selectedRoles.Except(userRoles).Except(empty).ToArray<string>();
				var rolesToRemove = userRoles.Except(selectedRoles).Except(empty).ToArray<string>();

				if (rolesToAdd.Length > 0)
                {
					// Add newly selected roles
                    var result = await UserManager.AddToRolesAsync(user.Id, rolesToAdd);
                if (!result.Succeeded)
                {
                    editUser.RolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
                    {
                        Selected = userRoles.Contains(x.Name),
                        Text = x.Name,
                        Value = x.Name
                    });
                    ModelState.AddModelError("", result.Errors.First());
                        return Json(new {status, message}, JsonRequestBehavior.AllowGet);
                    }
                }

				if (rolesToRemove.Length > 0)
				{
					// Remove unselected roles
					var result = await UserManager.RemoveFromRolesAsync(user.Id, rolesToRemove);
                if (!result.Succeeded)
                {
                    editUser.RolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
                    {
                        Selected = userRoles.Contains(x.Name),
                        Text = x.Name,
                        Value = x.Name
                    });
						message = result.Errors.First();
						status = false;
						return Json(new { status, message }, JsonRequestBehavior.AllowGet);
                }
            }

				status = true;
                message = "User has been updated successfully.";
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = false;
            }

            return Json(new { status, message }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Users/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5
        //    [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            bool status = false;
            string message = string.Empty;
                var user = await UserManager.FindByIdAsync(id);

                if (user == null)
                {
                message = "User not found.";
                return Json(new { status, message }, JsonRequestBehavior.AllowGet);
                }

                var result = await UserManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                message = result.Errors.First();
                }
            else
            {
                status = true;
                message = "User successfully deleted.";
            }
            return Json(new { status, message }, JsonRequestBehavior.AllowGet);
        }
    }
}
