using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VAW_WebApplication.Models;
using VAW_WebApplication.Common;
using System.Data;
using VAW_BusinessAccessLayer;
using VAW_Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;

namespace VAW_WebApplication.Controllers
{

    [CustomAuthorize(Roles = "SuperAdmin")]   
    public class SuperAdminController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        CapacityBuildingManager capacityBuildingManager = new CapacityBuildingManager();
        YearsBAL yearsBAL = new YearsBAL();
        string IPAddress = null;
        // GET: ViewVigilanceAwareness
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        ApplicationDbContext context = new ApplicationDbContext();
        public SuperAdminController()
        {
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        public SuperAdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            
        }
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
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

       


        // GET: SuperAdmin
        public ActionResult Index(string selected_year)
        {
            selected_year = !string.IsNullOrEmpty(selected_year) ? selected_year : DateTime.Now.Year.ToString();
            try
            {                           

                var roles = roleManager.Roles.ToList();                
                return View(roles);
            }
            catch (Exception ex)
            {

            }
            return View();
            
        }
        //
        // GET: /Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]       
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        //
        // GET: /Account/Register
        [HttpGet]
        public ActionResult UserRole()
        {
           
            return View();            
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UserRole(RoleViewModel role)
        {
            if (ModelState.IsValid)
            {  
                AppRole appRole = new AppRole();
                appRole.Name=role.RoleName;
                var result=await roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                AddErrors(result);

            }
            // If we got this far, something failed, redisplay form
            return View(role);
        }


        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "SuperAdmin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}