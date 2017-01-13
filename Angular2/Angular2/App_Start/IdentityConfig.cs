using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Angular2.Models;

namespace Angular2
{
	// Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
	public class ApplicationUserManager : UserManager<ApplicationUser>
	{
		public ApplicationUserManager(IUserStore<ApplicationUser> store)
		: base(store)
		{
		}

		public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
		{
			var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
			// Configure validation logic for usernames
			manager.UserValidator = new UserValidator<ApplicationUser>(manager)
			{
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = true
			};
			// Configure validation logic for passwords
			manager.PasswordValidator = new PasswordValidator
			{
				RequiredLength = 6,
				RequireNonLetterOrDigit = true,
				RequireDigit = true,
				RequireLowercase = true,
				RequireUppercase = true,
			};
			manager.EmailService = new EmailService();
			var dataProtectionProvider = options.DataProtectionProvider;
			if (dataProtectionProvider != null)
			{
				manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
			}
			return manager;
		}
	}
	public class ApplicationRole : IdentityRole
	{
		public ApplicationRole() : base() { }
		public ApplicationRole(string name) : base(name) { }
		public string Description { get; set; }
	}

	// Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
	public class ApplicationRoleManager : RoleManager<ApplicationRole>
	{
		public ApplicationRoleManager(
		    IRoleStore<ApplicationRole, string> roleStore)
		    : base(roleStore)
		{
		}
		public static ApplicationRoleManager Create(
		    IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
		{
		    return new ApplicationRoleManager(
			new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()));
		}
	}

	// This is useful if you do not want to tear down the database each time you run the application.
	// public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
	// This example shows you how to create a new database if the Model changes
	public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			InitializeIdentityForEF(context);
			base.Seed(context);
		}

        	public static void InitializeIdentityForEF(ApplicationDbContext db)
        	{
        		var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        		var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

			#region Create Default Roles
			string[] roles = new string[] { "Admin", "User", "AppManager" };
			foreach(var roleName in roles)
			{
				var role = roleManager.FindByName(roleName);
				if (role == null)
				{
					role = new ApplicationRole(roleName);
					var roleresult = roleManager.Create(role);
				}
			}
			#endregion

			#region Create Default Users
			var users = new[] {
				new { UserName = "admin", Email = "admin@gmail.com", Password = "Admin@123", Role = "Admin", FirstName = "Admin", LastName = "CodeBhagat", PhoneNumber = "1234567890" },
				new { UserName = "user", Email = "user@gmail.com", Password = "User@123", Role = "User", FirstName = "User", LastName = "CodeBhagat", PhoneNumber = "1234567890" }
				};

			foreach(var user in users)
			{
				var objUser = userManager.FindByName(user.UserName);
				var objEmail = userManager.FindByEmail(user.Email);
				if (objUser == null && objEmail == null)
				{
					objUser = new ApplicationUser { UserName = user.UserName, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, PhoneNumber = user.PhoneNumber };
					var result = userManager.Create(objUser, user.Password);
					result = userManager.SetLockoutEnabled(objUser.Id, false);
				}

				// Add user admin to Role Admin if not already added
				var userRoles = userManager.GetRoles(objUser.Id);
				if (!userRoles.Contains(user.Role))
				{
					var result = userManager.AddToRole(objUser.Id, user.Role);
				}
			}
			#endregion
		}
	}

    // Configure the application sign-in manager which is used in this application.
	public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
	{
		public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
		    : base(userManager, authenticationManager)
		{
		
		}

public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

		public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
		{
		    return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
		}
	}

	public class EmailService : IIdentityMessageService
	{
		public async Task SendAsync(IdentityMessage message)
		{
			await configSendEmailasync(message);
		}

		// Use NuGet to install SendGrid (Basic C# client lib) 
		private async Task configSendEmailasync(IdentityMessage message)
		{
			var myMessage = new MailMessage();

			myMessage.To.Add(new MailAddress("chiragbhagat@gmail.com"));
			myMessage.To.Add(new MailAddress(message.Destination));
			myMessage.From = new System.Net.Mail.MailAddress("chiragbhagat@gmail.com", "CB");
			myMessage.Subject = message.Subject;
			myMessage.Body = message.Body;

			SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
			//System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("joe@contoso.com", "XXXXXX");
			System.Net.NetworkCredential credentials = CredentialCache.DefaultNetworkCredentials;
			smtpClient.Credentials = credentials;
			smtpClient.EnableSsl = true;
			string userState = "test message1";
			smtpClient.SendAsync(myMessage, userState);
			await Task.FromResult(0);

			//await Task.FromResult(0);
			//SmtpClient SMTP = new SmtpClient();
			//SMTP.Credentials = ;
			//var credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailService:Account"],
			//                                        ConfigurationManager.AppSettings["emailService:Password"]);

			//// Create a Web transport for sending email.
			//var transportWeb = new Web(credentials);

			//// Send the email.
			//if (transportWeb != null)
			//{
			//    await transportWeb.DeliverAsync(myMessage);
			//}
			//else
			//{
			//    //Trace.TraceError("Failed to create Web transport.");
			//    await Task.FromResult(0);
			//}
		}
	}
}
