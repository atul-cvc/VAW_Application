using SMS_EMAIL_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace VAW_Utility
{
    public class OTP_Util
    {
        public string SendOTP(string MobNumer , string Email)
        {
            DataSet ds = new DataSet();
            string OTP = GenerateRandomNumber();
            Send_SMS_OTP(MobNumer, Email, OTP);
            return OTP;
        }
        public string GenerateRandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(10000, 20000);
            return randomNumber.ToString();
        }

        public void Send_SMS_OTP(string MobileNumber, string Email, string OTP)
        {
            SMS_Mail_OTP sMS_Mail_OTP = new SMS_Mail_OTP();
            string Mobile_OTP_Status = sMS_Mail_OTP.SendSmsNotification(MobileNumber, OTP);
            string Email_OTP_Status = sMS_Mail_OTP.Send_Email(Email, OTP);

            //string[] Mobile_OTP = Mobile_OTP_Status.Split('|');
            //string[] Mail_OTP = Email_OTP_Status.Split('|');

        }
    }
}
