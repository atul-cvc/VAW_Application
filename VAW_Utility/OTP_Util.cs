﻿using SMS_EMAIL_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAW_Utility
{
    public class OTP_Util
    {
        public string SendOTP(string MobNumer , string email)
        {
            //login process
            DataSet ds = new DataSet();
            //Sms_Mail_OTP_Dal sms_Mail_OTP_Dal = new Sms_Mail_OTP_Dal();
            //ds = sms_Mail_OTP_Dal.GetMobileNumberAndEmail(logindata[0].UserID);
            //DataTable dt = ds.Tables[0];
            
            //if (dt.Rows.Count > 0)
            //{
            //    //MobNumer = dt.Rows[0]["MobileNumber"].ToString();
            //    //email = dt.Rows[0]["Email"].ToString();

            //    //MobNumer = "8859460310";
            //    //email = "surya31072000@gmail.com";
            //}

            Random random = new Random();
            int randomNumber = random.Next(10000, 20000);
            string OTP = randomNumber.ToString();

            SMS_Mail_OTP sMS_Mail_OTP = new SMS_Mail_OTP();
            string Mobile_OTP_Status = sMS_Mail_OTP.SendSmsNotification(MobNumer, OTP);
            string Email_OTP_Status = sMS_Mail_OTP.Send_Email(email, OTP);

            //string[] Mobile_OTP = Mobile_OTP_Status.Split('|');
            //string[] Mail_OTP = Email_OTP_Status.Split('|');

            return OTP;
            //if (Mobile_OTP[0] == "success" || Mail_OTP[0] == "success")
            //{
            //    Session["MobileOTP"] = Mobile_OTP[1].ToString();
            //    Session["MailOTP"] = Mail_OTP[1].ToString();
            //    //Sms_Mail_OTP_Dal loginDAL = new Sms_Mail_OTP_Dal();
            //    //loginDAL.SetOtpDetailslOGIN(OTP, logindata[0].UserID);
            //    //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('OTP Sent To Your Registered Mbile No And Mail Please Check. In Case Of Any Issues Kindly Contact IT Cell');", true);
            //}
        }
    }
}
