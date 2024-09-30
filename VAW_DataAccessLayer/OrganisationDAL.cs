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
    public class OrganisationDAL
    {
        public string SqlConnection;
        public ErrorLog errolog = new ErrorLog();
        public OrganisationDAL()
        {
            SqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString.ToString();
        }
        public DataSet GetAllOrgsList()
        {
            DataSet DS = new DataSet();
            try
            {
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadAllOrgList");
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
    }
}
