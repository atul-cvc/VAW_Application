using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAW_Models;
using VAW_Utility;

namespace VAW_DataAccessLayer
{
    public class IntegrityPledgeDAL
    {
        public string SqlConnection;
        public ErrorLog errolog = new ErrorLog();

        public IntegrityPledgeDAL()
        {
            SqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString.ToString();
        }

        public DataSet GetIntegrityPledgeBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_CvoId", cvoid);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadIntegrityPledgeByCVOID", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        public int SaveIntegrityPledge(Tran_1a_integritypledge_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                MySqlParameter[] Sqlpara = new MySqlParameter[15];
                Sqlpara[0] = new MySqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                Sqlpara[1] = new MySqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                Sqlpara[2] = new MySqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                Sqlpara[3] = new MySqlParameter("@p_CvoId", obj.CvoId);
                Sqlpara[4] = new MySqlParameter("@p_DateOfActivity", Convert.ToDateTime(obj.DateOfActivity));
                Sqlpara[5] = new MySqlParameter("@p_TotalNoOfEmployees_UndertakenPledge", Convert.ToInt32(obj.TotalNoOfEmployees_UndertakenPledge));
                Sqlpara[6] = new MySqlParameter("@p_TotalNoOfCustomers_UndertakenPledge", Convert.ToInt32(obj.TotalNoOfCustomers_UndertakenPledge));
                Sqlpara[7] = new MySqlParameter("@p_TotalNoOfCitizen_UndertakenPledge", Convert.ToInt32(obj.TotalNoOfCitizen_UndertakenPledge));
                Sqlpara[8] = new MySqlParameter("@p_CreatedOn", DateTime.Now);
                Sqlpara[9] = new MySqlParameter("@p_CreatedBy", "your_user"); // Replace with actual user
                Sqlpara[10] = new MySqlParameter("@p_CreatedByIP", "127.0.0.1"); // Replace with actual IP
                Sqlpara[11] = new MySqlParameter("@p_CreatedBySession", "session_id"); // Replace with actual session
                Sqlpara[12] = new MySqlParameter("@p_UpdatedOn", DateTime.Now);
                Sqlpara[13] = new MySqlParameter("@p_UpdatedBy", obj.UpdatedBy);
                Sqlpara[14] = new MySqlParameter("@p_UpdatedByIp", "127.0.0.1");

                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateIntegrityPledge", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
    }
}
