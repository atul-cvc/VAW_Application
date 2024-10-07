//using CVC_Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAW_Utility;

namespace VAW_DataAccessLayer
{
    public class Sms_Mail_OTP_Dal
    {
        public string SqlConnection;
        public ErrorLog errolog = new ErrorLog();
        public Sms_Mail_OTP_Dal()
        {
            SqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString.ToString();
        }

        public DataSet GetMobileNumberAndEmail(string CvoId)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@userLogin", CvoId);

                dataSet = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_GetMobileNumber", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return dataSet;
        }
        public DataSet SetOtpDetails(string GenerateOTP, string FilledOTP, string UserID, string Count)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[4];
                Sqlpara[0] = new SqlParameter("@GenerateOTP", GenerateOTP);
                Sqlpara[1] = new SqlParameter("@UserID", UserID);
                Sqlpara[2] = new SqlParameter("@Count", Count);
                Sqlpara[3] = new SqlParameter("@FilledOTP", FilledOTP);
                dataSet = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_SetOTPDetails", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return dataSet;
        }
        public DataSet SetOtpDetailslOGIN(string GenerateOTP,string userid)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@otp", GenerateOTP);
                Sqlpara[1] = new SqlParameter("@userLogin", userid);
                dataSet = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_SetOTPDetails_login", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return dataSet;
        }
    }
}
