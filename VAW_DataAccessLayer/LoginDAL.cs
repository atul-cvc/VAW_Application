
using System;
using System.Data;
using System.Data.SqlClient;
using VAW_Utility;

namespace VAW_DataAccessLayer
{
    public class LoginDAL
    {
        public string SqlConnection;
        public ErrorLog errolog = new ErrorLog();
        public LoginDAL()
        {
            SqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString.ToString();
        }

        public DataSet UserLogin(string UserId, string password)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoLoginId", UserId);
                Sqlpara[1] = new SqlParameter("@p_CvoPassword", password);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadCvoUser", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }



        public DataSet ForgetPassword(string txtEmail, string txtMobile, string defaultpass)
        {

            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[3];
                Sqlpara[1] = new SqlParameter("@txtMobile", txtMobile);
                Sqlpara[2] = new SqlParameter("@deafultpass", defaultpass);


                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ForgetPassword", Sqlpara);



            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        public DataSet UserLoginTrailPer(string userid, String Flag, String LoginSession, String LoginIpAddress, int Section, String hostname)
        {

            DateTime LoginDateTime = DateTime.Now;
            Console.WriteLine("Current date and time: " + LoginDateTime);

            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[7];
                Sqlpara[0] = new SqlParameter("@UserID", userid);
                Sqlpara[1] = new SqlParameter("@Flag", Flag);
                Sqlpara[2] = new SqlParameter("@LoginDateTime", LoginDateTime);
                Sqlpara[3] = new SqlParameter("@LoginSession", LoginSession);
                Sqlpara[4] = new SqlParameter("@LoginIpAddress", LoginIpAddress);
                Sqlpara[5] = new SqlParameter("@Section", Section);
                Sqlpara[6] = new SqlParameter("@hostname", hostname);

                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_AuditLoginTrail", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }


        public DataSet UserLoginTrailFailed(string userid, String Flag, String LoginIpAddress, String hostname)
        {

            DateTime LoginDateTime = DateTime.Now;
            Console.WriteLine("Current date and time: " + LoginDateTime);

            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[5];
                Sqlpara[0] = new SqlParameter("@UserID", userid);
                Sqlpara[1] = new SqlParameter("@Flag", Flag);
                Sqlpara[2] = new SqlParameter("@LoginDateTime", LoginDateTime);
                Sqlpara[3] = new SqlParameter("@LoginIpAddress", LoginIpAddress);
                Sqlpara[4] = new SqlParameter("@hostname", hostname);

                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_AuditLoginTrail", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }



        public DataSet Verify_User(string txtEmail, string txtMobile)
        {


            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@txtEmail", txtEmail);
                Sqlpara[1] = new SqlParameter("@txtMobile", txtMobile);


                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_Verify_User", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);

            }
            return DS;
        }
    }
}
