using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using VAW_Utility;

namespace VAW_DataAccessLayer
{
    public class CapacityBuildingDAL
    {
        public string SqlConnection;
        public ErrorLog errolog = new ErrorLog();

        public CapacityBuildingDAL()
        {
            SqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString.ToString();
        }

        public DataSet GetCapacityBuildingByYear(string year)
        {
            int? _year = Convert.ToInt32(year);
            DataSet DS = new DataSet();
            try
            {
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", _year);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadCapacityBuildingProgram", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        public void CreateCapacityBuilding()
        {
            //MySqlParameter[] parameters = new MySqlParameter[]
            //   {
            //        new MySqlParameter("@p_VAW_Year", MySqlDbType.Int32) { Value = 2024 },
            //        new MySqlParameter("@p_UniqueTransactionId", MySqlDbType.Text) { Value = "TX123456" },
            //        new MySqlParameter("@p_CvoOrgCode", MySqlDbType.Text) { Value = "CVO123" },
            //        new MySqlParameter("@p_CvoId", MySqlDbType.Text) { Value = "CVOID456" },
            //        new MySqlParameter("@p_FromDate", MySqlDbType.DateTime) { Value = new DateTime(2024, 1, 1) },
            //        new MySqlParameter("@p_ToDate", MySqlDbType.DateTime) { Value = new DateTime(2024, 12, 31) },
            //        new MySqlParameter("@p_TrainingName", MySqlDbType.Text) { Value = "Leadership Training" },
            //        new MySqlParameter("@p_EmployeesTrained", MySqlDbType.Int32) { Value = 50 },
            //        new MySqlParameter("@p_BriefDescription", MySqlDbType.Text) { Value = "An extensive leadership training program." },
            //        new MySqlParameter("@p_CreatedOn", MySqlDbType.DateTime) { Value = DateTime.Now },
            //        new MySqlParameter("@p_CreatedBy", MySqlDbType.Text) { Value = "admin" },
            //        new MySqlParameter("@p_CreatedByIP", MySqlDbType.VarChar, 50) { Value = "192.168.1.1" },
            //        new MySqlParameter("@p_CreatedBySession", MySqlDbType.Text) { Value = "session123" },
            //        new MySqlParameter("@p_UpdatedOn", MySqlDbType.DateTime) { Value = DateTime.Now },
            //        new MySqlParameter("@p_UpdatedBy", MySqlDbType.Text) { Value = "admin" },
            //        new MySqlParameter("@p_UpdatedByIp", MySqlDbType.Text) { Value = "192.168.1.1" }
            //   };
        }
    }
}
