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
using SMS_EMAIL_Models;
using CVC_DataAccessLayer;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
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
                                //string ur = Session["UserRole"] as string;
                                //return RedirectToAction("Index", "Admin");
                            }
                            else
                            {
                                Session["UserRole"] = "ROLE_CVO";
                            }

                            //SendOTP
                            OTP_Util OTP_Util = new OTP_Util();
                            Session["OTP"] = OTP_Util.SendOTP("8700655713", "atulkumar65@gmail.com");

                            //return RedirectToAction("Index", "Dashboard");

                            return RedirectToAction("VerifyOTP", new { userId = logindata[0].UserID });
                            //return RedirectToAction("VerifyOTP", new VerifyOTPViewModel { UserId = logindata[0].UserID });
                            //return RedirectToUserRole(Session["UserRole"] as string);
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
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
                //return RedirectToAction("Index");
                return PartialView("Error");
            }
        }

        public ActionResult VerifyOTP(string UserId)
        {
            try
            {
                var model = new VerifyOTPViewModel { UserId = UserId, NoOfAttempt = 0 };
                Session["OtpAttempts"] = 0;
                return View(model);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
                return PartialView("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerifyOTP(VerifyOTPViewModel verifyVM)
        {
            try
            {
                string _sessionOTP = Session["OTP"].ToString();
                LoginModal SessionUser = Session["LogedUser"] as LoginModal;

                // Check if the model state is valid
                if (!ModelState.IsValid)
                {
                    return View(verifyVM);
                }

                // Handle invalid OTP
                if (_sessionOTP != null && _sessionOTP.Equals(verifyVM.Otp))
                {
                    // Redirect based on user role

                    return RedirectToUserRole(Session["UserRole"] as string);
                    //if (userRole == "ROLE_ADMIN")
                    //{
                    //    return RedirectToAction("Index", "Admin");
                    //}
                    //if (userRole == "ROLE_CVO")
                    //{
                    //    return RedirectToAction("Index", "Dashboard");
                    //}
                    //// Fallback if no role matches
                    //return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid OTP.");
                    ViewBag.OTPErrorMsg = "Invalid OTP";
                    verifyVM.NoOfAttempt = Convert.ToInt32(Session["OtpAttempts"]) + 1;
                    Session["OtpAttempts"] = verifyVM.NoOfAttempt.ToString();
                    if (verifyVM.NoOfAttempt < 3)
                        return View(verifyVM); // Return the view with the model to show the error
                    else
                    {
                        //lock the user
                        //LockUser();
                        return RedirectToAction("Index");
                    }
                }

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
                return PartialView("Error");
            }

        }

        // Method to lock the user
        private void LockUser(LoginModal sessionUser)
        {
            // Implement your user-locking logic here
            // e.g., mark the user as locked in the database or session
        }

        public ActionResult RedirectToUserRole(string userRole)
        {
            //if (userRole == "ROLE_ADMIN")
            //{
            //    return RedirectToAction("Index", "Admin");
            //}
            //if (userRole == "ROLE_CVO")
            //{
            //    return RedirectToAction("Index", "Dashboard");
            //}
            //// Fallback if no role matches
            //return RedirectToAction("Index");

            switch (userRole)
            {
                case "ROLE_ADMIN":
                    return RedirectToAction("Index", "Admin");

                case "ROLE_CVO":
                    return RedirectToAction("Index", "Dashboard");

                default:
                    return RedirectToAction("Index");
            }
        }
    }
}