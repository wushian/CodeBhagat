using Angular2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Angular2.Controllers
{
    // [Authorize(Roles = "Admin")]
    public class RolesAdminController : Controller
    {
        public RolesAdminController()
        {
        }

        public RolesAdminController(ApplicationUserManager userManager,
            ApplicationRoleManager roleManager)
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
            set
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
	// GET: /Roles/
        //public ActionResult Index()
        //{
        //    return View(RoleManager.Roles);
        //}

        [HttpGet]
        public JsonResult GetRoles()
        {
            return Json(new
            {
                roles = RoleManager.Roles.Select(p => new
                {
                    p.Name,
                    p.Id,
                    p.Description
                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Roles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            // Get the list of Users in this Role
            var users = new List<ApplicationUser>();

            // Get the list of Users in this Role
            foreach (var user in UserManager.Users.ToList())
            {
                if (await UserManager.IsInRoleAsync(user.Id, role.Name))
                {
                    users.Add(user);
                }
            }

            ViewBag.Users = users;
            ViewBag.UserCount = users.Count();
            return View(role);
        }

        //
        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            // Initialize ApplicationRole instead of IdentityRole:
            var status = false;
            var message = string.Empty;

            try
            {
                var role = new ApplicationRole(roleViewModel.Name);
                role.Description = roleViewModel.Description;

                var roleresult = await RoleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    message = roleresult.Errors.First();
                }
                else
                {
                    status = true;
                    message = "Role record added successfully.";
                }
            }
            catch (System.Exception ex)
            {
                message = "Error while trying to create role. Error: " + ex.Message;
            }
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }
        
        //
        // GET: /Roles/Edit/Admin
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            RoleViewModel roleModel = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
            return View(roleModel);
        }

        //
	// POST: /Roles/Edit/5
	[HttpPut]

	public async Task<ActionResult> Edit(RoleViewModel roleModel)
	{
            var status = false;
            var message = string.Empty;

            try
            {
                var role = await RoleManager.FindByIdAsync(roleModel.Id);
                role.Name = roleModel.Name;
                // Update the new Description property:
                role.Description = roleModel.Description;

                await RoleManager.UpdateAsync(role);
                status = true;
                message = "Role record updated successfully.";
            }
            catch (System.Exception ex)
            {
                message = "Error while trying to update role. Error: " + ex.Message;
            }
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Roles/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //
        // POST: /Roles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            	var status = false;
		var message = string.Empty;

		var role = await RoleManager.FindByIdAsync(id);

		if (role == null)
		{
		    message = "Role does not exist.";
		}
		else
		{
                if (UserManager.Users.Any(u => u.Roles.Any(r => r.RoleId == id)))
                {
                    message = "Selected role is currently in use. Please remove this role from all users before removing the role..";
                }
                else
                {
		    IdentityResult result;
		    result = await RoleManager.DeleteAsync(role);
		    if (!result.Succeeded)
		    {
			message = result.Errors.First();
		    }
		    else
		    {
			message = "Role has been successfully deleted.";
			status = true;
		    }
		}
            }
            return Json(new { status = status, message =message}, JsonRequestBehavior.AllowGet);
        }
    }
}
