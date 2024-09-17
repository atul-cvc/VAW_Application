
using System;
using System.Data;
using MySql.Data.MySqlClient;
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
                MySqlParameter[] Sqlpara = new MySqlParameter[2];
                Sqlpara[0] = new MySqlParameter("@p_CvoLoginId", UserId);
                Sqlpara[1] = new MySqlParameter("@p_CvoPassword", password);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadCvoUser", Sqlpara);

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
                MySqlParameter[] Sqlpara = new MySqlParameter[3];
                Sqlpara[0] = new MySqlParameter("@txtEmail", txtEmail);
                Sqlpara[1] = new MySqlParameter("@txtMobile", txtMobile);
                Sqlpara[2] = new MySqlParameter("@deafultpass", defaultpass);


                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ForgetPassword", Sqlpara);



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
                MySqlParameter[] Sqlpara = new MySqlParameter[7];
                Sqlpara[0] = new MySqlParameter("@UserID", userid);
                Sqlpara[1] = new MySqlParameter("@Flag", Flag);
                Sqlpara[2] = new MySqlParameter("@LoginDateTime", LoginDateTime);
                Sqlpara[3] = new MySqlParameter("@LoginSession", LoginSession);
                Sqlpara[4] = new MySqlParameter("@LoginIpAddress", LoginIpAddress);
                Sqlpara[5] = new MySqlParameter("@Section", Section);
                Sqlpara[6] = new MySqlParameter("@hostname", hostname);

                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_AuditLoginTrail", Sqlpara);

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
                MySqlParameter[] Sqlpara = new MySqlParameter[5];
                Sqlpara[0] = new MySqlParameter("@UserID", userid);
                Sqlpara[1] = new MySqlParameter("@Flag", Flag);
                Sqlpara[2] = new MySqlParameter("@LoginDateTime", LoginDateTime);
                Sqlpara[3] = new MySqlParameter("@LoginIpAddress", LoginIpAddress);
                Sqlpara[4] = new MySqlParameter("@hostname", hostname);

                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_AuditLoginTrail", Sqlpara);

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
                MySqlParameter[] Sqlpara = new MySqlParameter[2];
                Sqlpara[0] = new MySqlParameter("@txtEmail", txtEmail);
                Sqlpara[1] = new MySqlParameter("@txtMobile", txtMobile);


                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_Verify_User", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);

            }
            return DS;
        }
    }
}
