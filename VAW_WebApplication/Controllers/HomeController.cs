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

namespace VAW_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        LoginManager loginManager = new LoginManager();
        public ActionResult Index()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {               
                string hostname = Dns.GetHostName();
                string LoginIpAddress = Dns.GetHostByName(hostname).AddressList[0].ToString();
                Session["UserRole"] = null;
                Session["DefaultUrl"] = null;

                LoginModal loginViewModal = new LoginModal();
                try
                {
                    //if (!string.IsNullOrEmpty(txtCaptcha.Text.Trim()))
                    //{
                    //    FuncValidationResult ValidationResult = ValidateLogin();
                    //    if (ValidationResult.ResultStatus)
                    //    {
                    //        if (txtCaptcha.Text != null)
                    //        {
                                //cptCaptcha.ValidateCaptcha(txtCaptcha.Text.Trim());
                                //if (cptCaptcha.UserValidated)
                                //{
                                    var logindata = loginManager.ValidateLoginUser(model.Username, model.Password);

                    if (logindata != null && logindata.Count == 1)
                    {
                        loginViewModal = logindata[0];
                        Session["LogedUser"] = loginViewModal;
                        return RedirectToAction("About", "Home");

                    }

                                    //    LoginViewModal loginViewModal2 = (LoginViewModal)Session["LogedUser"];

                                    //    int Section = 0;
                                    //    String LoginSession = Session.SessionID;
                                    //    if (!string.IsNullOrEmpty(loginViewModal2.Section) && loginViewModal2.Section != "&nbsp;")
                                    //    {
                                    //        Section = Convert.ToInt32(loginViewModal2.Section);
                                    //    }
                                    //    if (loginViewModal.userActiveStatus == "Active")
                                    //    {
                                    //        Flag = "Login";
                                    //        loginManager.UserLoginTrailp(txtuserid.Text, Flag, LoginSession, LoginIpAddress, Section, hostname);

                                    //        if (loginViewModal.ChangePasswordFlag == 0)
                                    //        {
                                    //            Response.Redirect("ChangePassword.aspx");
                                    //        }
                                    //        DataSet ds = new DataSet();
                                    //        Sms_Mail_OTP_Dal sms_Mail_OTP_Dal = new Sms_Mail_OTP_Dal();
                                    //        ds = sms_Mail_OTP_Dal.GetMobileNumber(txtuserid.Text);
                                    //        DataTable dt = ds.Tables[0];
                                    //        string MobNumer = "";
                                    //        string email = "";
                                    //        if (dt.Rows.Count > 0)
                                    //        {
                                    //            MobNumer = dt.Rows[0]["userMobile"].ToString();
                                    //            email = dt.Rows[0]["userEmail"].ToString();

                                    //            //MobNumer = "8859460310";
                                    //            //email = "surya31072000@gmail.com";
                                    //        }
                                    //        Random random = new Random();
                                    //        int randomNumber = random.Next(10000, 20000);
                                    //        string OTP = randomNumber.ToString();


                                    //        //SMS_Mail_OTP sMS_Mail_OTP = new SMS_Mail_OTP();
                                    //        //string Mobile_OTP_Status = sMS_Mail_OTP.SendSmsNotification(MobNumer, OTP);
                                    //        //string Email_OTP_Status = sMS_Mail_OTP.Send_Email(email, OTP);

                                    //        //string[] Mobile_OTP = Mobile_OTP_Status.Split('|');
                                    //        //string[] Mail_OTP = Email_OTP_Status.Split('|');

                                    //        //if (Mobile_OTP[0] == "success" || Mail_OTP[0] == "success")
                                    //        //{
                                    //        //    Session["MobileOTP"] = Mobile_OTP[1].ToString();
                                    //        //    Session["MailOTP"] = Mail_OTP[1].ToString();
                                    //        //    Sms_Mail_OTP_Dal loginDAL = new Sms_Mail_OTP_Dal();
                                    //        //    loginDAL.SetOtpDetailslOGIN(OTP, txtuserid.Text);
                                    //        //    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('OTP Sent To Your Registered Mbile No And Mail Please Check. In Case Of Any Issues Kindly Contact IT Cell');", true);
                                    //        //}


                                    //        //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, //Version
                                    //        //    loginViewModal.UserName.ToString(), // //Username
                                    //        //    DateTime.Now,//Time issued
                                    //        //    DateTime.Now.AddMinutes(180),// Expiration time
                                    //        //    chkrememberme.Checked,// Persistent?
                                    //        //    loginViewModal.UserRole);//// User data string, in our case, to hold the role
                                    //        //string role = loginViewModal.UserRole.Trim();
                                    //        //string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                                    //        //HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                                    //        //Response.Cookies.Add(authenticationCookie);
                                    //        //string jwttoken = JwtWork.GenerateJwtToken(360);
                                    //        ///// FormsAuthentication.SetAuthCookie(loginViewModal.UserName, chkrememberme.Checked);
                                    //        //// FormsAuthentication.RedirectFromLoginPage(loginViewModal.UserName, chkrememberme.Checked);
                                    //        //Session["UserRole"] = loginViewModal.UserRole.ToUpper();
                                    //        //Session["userLogin"] = txtuserid.Text;

                                    //        // Response.Redirect("~/VerifyOTP.aspx");
                                    //        //switch (loginViewModal.UserRole.ToUpper())
                                    //        //{
                                    //        //    case "ROLE_DH":
                                    //        //        Session["UserRole"] = "ROLE_DH";
                                    //        //        Session["DefaultUrl"] = "~/DealingHand/Default.aspx";
                                    //        //        Response.Redirect("~/DealingHand/Default.aspx");
                                    //        //        break;
                                    //        //    case "ROLE_SO":
                                    //        //        Session["UserRole"] = "ROLE_SO";
                                    //        //        Session["DefaultUrl"] = "~/DealingHand/Default.aspx";
                                    //        //        Response.Redirect("~/DealingHand/Default.aspx");
                                    //        //        //Session["DefaultUrl"] = "~/SectionOfficer/Default.aspx";
                                    //        //        //Response.Redirect("~/SectionOfficer/Default.aspx");
                                    //        //        break;
                                    //        //    case "ROLE_BO":
                                    //        //        Session["UserRole"] = "ROLE_BO";
                                    //        //        Session["DefaultUrl"] = "~/BranchOfficer/Default.aspx";
                                    //        //        Response.Redirect("~/BranchOfficer/Default.aspx");
                                    //        //        break;
                                    //        //    case "ROLE_AS":
                                    //        //        Session["UserRole"] = "ROLE_AS";
                                    //        //        Session["DefaultUrl"] = "~/Add_Secretary/Default.aspx";
                                    //        //        Response.Redirect("~/Add_Secretary/Default.aspx");
                                    //        //        break;
                                    //        //    case "ROLE_SECRETARY":
                                    //        //        Session["UserRole"] = "ROLE_SECRETARY";
                                    //        //        Session["DefaultUrl"] = "~/Secretary/Default.aspx";
                                    //        //        Response.Redirect("~/Secretary/Default.aspx");
                                    //        //        break;
                                    //        //    case "ROLE_CVC":
                                    //        //        Session["UserRole"] = "ROLE_CVC";
                                    //        //        Session["DefaultUrl"] = "~/CVC/Default.aspx";
                                    //        //        Response.Redirect("~/CVC/Default.aspx");
                                    //        //        break;
                                    //        //    case "ROLE_RECORDKEEPER":
                                    //        //        Session["UserRole"] = "ROLE_RECORDKEEPER";
                                    //        //        Session["DefaultUrl"] = "~/RecordKeeper/Default.aspx";
                                    //        //        Response.Redirect("~/RecordKeeper/Default.aspx");
                                    //        //        break;
                                    //        //    case "ROLE_ADMIN":
                                    //        //        Session["UserRole"] = "ROLE_ADMIN";
                                    //        //        Session["DefaultUrl"] = "~/AdminUser/Default.aspx";
                                    //        //        Response.Redirect("~/AdminUser/Default.aspx");
                                    //        //        break;
                                    //        //    case "ROLE_LEGAL":
                                    //        //        Session["UserRole"] = "ROLE_LEGAL";
                                    //        //        Session["DefaultUrl"] = "~/Legal/Default.aspx";
                                    //        //        Response.Redirect("~/Legal/Default.aspx");
                                    //        //        break;
                                    //        //    case "ROLE_COORD1":
                                    //        //        Session["UserRole"] = "ROLE_COORD1";
                                    //        //        Session["DefaultUrl"] = "~/Coord1/Default.aspx";
                                    //        //        Response.Redirect("~/Coord1/Default.aspx");
                                    //        //        break;
                                    //        //    case "ROLE_MEETING":
                                    //        //        Session["UserRole"] = "ROLE_MEETING";
                                    //        //        Session["DefaultUrl"] = "~/BOMeeting/Default.aspx";
                                    //        //        Response.Redirect("~/BOMeeting/Default.aspx");
                                    //        //        break;
                                    //        //    case "ROLE_COORD2":
                                    //        //        Session["UserRole"] = "ROLE_COORD2";
                                    //        //        Session["DefaultUrl"] = "~/Coord2/Default.aspx";
                                    //        //        Response.Redirect("~/Coord2/Default.aspx");
                                    //        //        break;


                                    //        //    #region 20240618_1115_Sandeep
                                    //        //    //Below code is added by Sandeep/SS on 18.06.2024 to handle PIDPI Login
                                    //        //    case "ROLE_PIDPI":
                                    //        //        Session["UserRole"] = "ROLE_PIDPI";
                                    //        //        Session["DefaultUrl"] = "~/DhPidpi/Default.aspx";
                                    //        //        Response.Redirect("~/DhPidpi/Default.aspx");
                                    //        //        break;

                                    //        //    case "ROLE_DH_PIDPI":
                                    //        //        Session["UserRole"] = "ROLE_PIDPI";
                                    //        //        Session["DefaultUrl"] = "~/DhPidpi/Default.aspx";
                                    //        //        Response.Redirect("~/DhPidpi/Default.aspx");
                                    //        //        break;

                                    //        //    case "ROLE_SO_PIDPI":
                                    //        //        Session["UserRole"] = "ROLE_PIDPI";
                                    //        //        Session["DefaultUrl"] = "~/DhPidpi/Default.aspx";
                                    //        //        Response.Redirect("~/DhPidpi/Default.aspx");
                                    //        //        break;
                                    //        //    #endregion

                                    //        //    #region For Show menu of Data Correction Request By Sandeep 27-05-2024
                                    //        //    case "ROLE_SOIT":
                                    //        //        Session["UserRole"] = "ROLE_SOIT";
                                    //        //        Session["DefaultUrl"] = "~/DealingHand/Default.aspx";
                                    //        //        Response.Redirect("~/DealingHand/Default.aspx");
                                    //        //        break;
                                    //        //    case "ROLE_BOIT":
                                    //        //        Session["UserRole"] = "ROLE_BOIT";
                                    //        //        Session["DefaultUrl"] = "~/BranchOfficer/Default.aspx";
                                    //        //        Response.Redirect("~/BranchOfficer/Default.aspx");
                                    //        //        break;
                                    //        //    #endregion

                                    //        //    #region Lokpal Entry New Case and Reference and Old File Reference By Sandeep 08-07-2024
                                    //        //    case "ROLE_LOKPAL":
                                    //        //        Session["UserRole"] = "ROLE_LOKPAL";
                                    //        //        Session["DefaultUrl"] = "~/Lokpal/Default.aspx";
                                    //        //        Response.Redirect("~/Lokpal/Default.aspx");
                                    //        //        break;
                                    //        //        #endregion

                                    //        //}
                                    //    }
                                    //    else
                                    //    {

                                    //        //Flag = "wrong password";
                                    //        //loginManager.UserLoginTrailp(txtuserid.Text, Flag, LoginSession, LoginIpAddress, Section, hostname);

                                    //        //txtuserid.Focus();
                                    //        //divmsg.Visible = true;
                                    //        //lblmsg.ForeColor = System.Drawing.Color.Red;
                                    //        //lblmsg.Text = "Unable to login. kinday contact system administrator";
                                    //        //ScriptManager.RegisterStartupScript(this, this.GetType(), "PopUp", "Infoalert('Unable to login. kinday contact system administrator');", true);
                                    //    }

                                    //    // FormsAuthentication.RedirectFromLoginPage(loginViewModal.UserID, true);

                                    //}
                                    //else
                                    //{
                                    //    //txtuserid.Focus();
                                    //    //divmsg.Visible = true;
                                    //    //lblmsg.ForeColor = System.Drawing.Color.Red;
                                    //    //lblmsg.Text = "Invalid Credentials...";
                                    //    //Flag = "Invalid Credentials";
                                    //    //loginManager.UserLoginTrailpFailed(txtuserid.Text, Flag, LoginIpAddress, hostname);

                                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "PopUp", "Infoalert('Invalid Credentials...');", true);
                                    //}
                                //}
                                //else
                                //{
                                    //txtuserid.Focus();
                                    //divmsg.Visible = true;
                                    //lblmsg.ForeColor = System.Drawing.Color.Red;
                                    //lblmsg.Text = "Invalid Captcha...";
                                    //Flag = "Invalid Captcha";
                                    //loginManager.UserLoginTrailpFailed(txtuserid.Text, Flag, LoginIpAddress, hostname);

                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "PopUp", "Infoalert('" + "InValid Captcha" + "');", true);

                                //}
                    //        }
                    //    }
                    //    else
                    //    {
                    //        //txtuserid.Focus();
                    //        //divmsg.Visible = true;
                    //        //lblmsg.ForeColor = System.Drawing.Color.Red;
                    //        //lblmsg.Text = ValidationResult.ResultDescription;
                    //        //ScriptManager.RegisterStartupScript(this, this.GetType(), "PopUp", "Infoalert('" + ValidationResult.ResultDescription + "');", true);
                    //    }
                    //}
                    //else
                    //{
                    //  // ScriptManager.RegisterStartupScript(this, this.GetType(), "PopUp", "Infoalert('Captcha is null');", true);
                    //}
                }
                catch (Exception ex)
                {
                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "PopUp", "Infoalert('" + ex.Message.ToString() + "');", true);
                }


                // Here you would typically validate the user against a database
                // For simplicity, let's assume success for any username/password
                //if (model.Username == "admin" && model.Password == "password")
                //{
                //    // Redirect to a different action, e.g., Home page
                    
                //}
                //ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}