using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAW_Utility;

namespace VAW_DataAccessLayer
{
    public class YearsDAL
    {
        public string SqlConnection;
        public ErrorLog errolog = new ErrorLog();
        public YearsDAL()
        {
            SqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString.ToString();
        }

        public DataSet GetAllYearsList()
        {
            DataSet DS = new DataSet();
            try
            {
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadAllYearsList");
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

    }
}
