using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using VAW_BusinessAccessLayer;
using VAW_WebApplication.Models;
using VAW_Models;
using WebGrease;
using ASPSnippets.Captcha;
using VAW_Utility;
namespace VAW_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ErrorLog errolog = new ErrorLog();
        LoginManager loginManager = new LoginManager();
        public Captcha Captcha
        {
            get
            {
                return (Captcha)TempData["Captcha"];
            }
            set
            {
                TempData["Captcha"] = value;
            }
        }
     

        public ActionResult Index()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            this.Captcha = new Captcha(125, 40, 20f, "#FFFFFF", "#61028D", Mode.AlphaNumeric);
            loginViewModel.ImageData = this.Captcha.ImageData;
            return View(loginViewModel);          
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (this.Captcha.IsValid(model.CaptchaAnswer))
                    {
                        string hostname = Dns.GetHostName();
                        string LoginIpAddress = Dns.GetHostByName(hostname).AddressList[0].ToString();
                        Session["UserRole"] = null;
                        Session["DefaultUrl"] = null;
                        LoginModal loginViewModal = new LoginModal();
                        List<LoginModal> logindata = loginManager.ValidateLoginUser(model.Username, model.Password);

                        if (logindata != null && logindata.Count == 1)
                        {
                            loginViewModal = logindata[0];
                            Session["LogedUser"] = loginViewModal;
                            if (logindata[0].UserID == "ADMIN")
                            {
                                Session["UserRole"] = "ROLE_ADMIN";
                                string ur = Session["UserRole"] as string;
                                return RedirectToAction("Index", "Admin");
                            }
                            return RedirectToAction("Index", "Dashboard");

                        }

                    }
                    else
                    {
                        ViewBag.Error = "Captcha invalid";
                    }
                }
                model.ImageData = this.Captcha.ImageData;


                return View(model);
            }
            catch (Exception ex) { 
                errolog.WriteErrorLog(ex);
                return RedirectToAction("Index");
            }
        }
        
    }
}