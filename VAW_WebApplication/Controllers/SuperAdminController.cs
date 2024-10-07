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
using System.Web.UI.WebControls;

namespace VAW_WebApplication.Controllers
{

    [CustomAuthorize(Roles = "SuperAdmin")]   
    public class SuperAdminController : Controller
    {
        OrganisationBAL OrgBal = new OrganisationBAL();
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
            DataTable _tblMinName= OrgBal.GetMinistry().Tables[0];
            ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("SuperAdmin"))
                                    .ToList(), "Name", "Name");
            ViewBag.MinList= ToSelectList(_tblMinName, "MinName", "MinName");

            //ViewBag.OrgList = new SelectList(context.Roles.Where(u => !u.Name.Contains("SuperAdmin"))
            //                        .ToList(), "Name", "Name");
            //GetMinistry
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
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email,PhoneNumber=model.PhoneNumber, MinName=model.MinistryName, CvoOrgCode=model.OrgCode };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    await UserManager.AddToRoleAsync(user.Id, model.UserRoles);
                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }
            DataTable _tblMinName = OrgBal.GetMinistry().Tables[0];
            ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("SuperAdmin"))
                                    .ToList(), "Name", "Name");
            ViewBag.MinList = ToSelectList(_tblMinName, "MinName", "MinName");
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


        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }
            list.Insert(0, new SelectListItem() { Text = "-Select-", Value = "" });
            return new SelectList(list, "Value", "Text");
        }

        [HttpPost]
        public ActionResult GetOrganization(string MinName)
        {            
            List<SelectListItem> OrgCodeAndName = new List<SelectListItem>();
           
            if (!string.IsNullOrEmpty(MinName))
            {
                DataTable _tblMinName = OrgBal.GetAllOrgsListByMinName(MinName).Tables[0];
                foreach (DataRow row in _tblMinName.Rows)
                {
                    OrgCodeAndName.Add(new SelectListItem()
                    {
                        Text = row["Name"].ToString(),
                        Value = row["OrgCode"].ToString()
                    });
                }
            }
            return Json(OrgCodeAndName, JsonRequestBehavior.AllowGet);
        }
    }
}