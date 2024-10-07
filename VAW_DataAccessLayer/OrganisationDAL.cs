using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAW_Utility;
using static System.Collections.Specialized.BitVector32;

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
                
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadAllOrgList");
                
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetAllOrgsListByMinName(string MinName)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@MinName", MinName);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadAllOrgListByMinName", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        public DataSet GetMinistry()
        {
            DataSet DS = new DataSet();
            try
            {                
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_GetMinistry");
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
    }
}
