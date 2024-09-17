using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAW_DataAccessLayer;
using VAW_Models;

namespace VAW_BusinessAccessLayer
{
    public class LoginManager
    {
        List<LoginModal> list = new List<LoginModal>();
        LoginDAL LoginDAL = new LoginDAL();
        public LoginManager()
        {
            //list.Add(new LoginViewModal() { UserID="ABC1",password="123",UserRole="ROLE_DH"});
            //list.Add(new LoginViewModal() { UserID = "ABC2", password = "123", UserRole = "ROLE_SO" });
            //list.Add(new LoginViewModal() { UserID = "ABC3", password = "123", UserRole = "ROLE_BO" });
            //list.Add(new LoginViewModal() { UserID = "ABC4", password = "123", UserRole = "ROEL_AB" });
            //list.Add(new LoginViewModal() { UserID = "ABC5", password = "123", UserRole = "ROEL_SECRETARY" });
        }

        public List<LoginModal> ValidateLoginUser(string userid, string password)
        {
            List<LoginModal> loginViewModal = null;
            DataTable usertable = LoginDAL.UserLogin(userid, password).Tables[0];
            if (usertable.Rows.Count > 0)
            {
                loginViewModal = (from DataRow dr in usertable.Rows
                                  select new LoginModal()
                                  {
                                      //ID = int.Parse(dr["CvoID"].ToString()),
                                      //ID = dr["CvoID"].ToString(),
                                      UserID = dr["CvoID"].ToString(),
                                      UserName = dr["CvoID"].ToString()
                                      //UserRole = dr["userProfile"].ToString(),
                                      //userActiveStatus = dr["userActiveStatus"].ToString(),
                                      //Section = dr["Section"].ToString(),
                                      //SOID = dr["SOID"].ToString(),
                                      //BOID = dr["BOID"].ToString(),
                                      //ASID = dr["ASID"].ToString(),
                                      //SECID = dr["SECID"].ToString(),
                                      //Email = dr["userEmail"].ToString(),
                                      //ChangePasswordFlag = Convert.ToInt32(dr["ChangePasswordFlag"]),
                                      //CVCID = dr["CVCID"].ToString(),
                                      //MappedSection = dr["MappedSection"].ToString(),
                                      //password = dr["userPassword"].ToString()
                                  }).ToList();
            }
            return loginViewModal;

        }



        public DataSet UserLoginTrailp(string UserID, string Flag, string LoginSession, string LoginIpAddress, int Section, string hostname)


        {
            return LoginDAL.UserLoginTrailPer(UserID, Flag, LoginSession, LoginIpAddress, Section, hostname);




        }

        public DataSet UserLoginTrailpFailed(string UserID, string Flag, string LoginIpAddress, string hostname)


        {
            return LoginDAL.UserLoginTrailFailed(UserID, Flag, LoginIpAddress, hostname);


        }


    }
}
