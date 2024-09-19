using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VAW_DataAccessLayer;
using VAW_Models;

namespace VAW_BusinessAccessLayer
{
    public class CapacityBuildingManager
    {
        CapacityBuildingDAL CapacityBuildingDAL = new CapacityBuildingDAL();

        public List<Tran_a_1b_capacitybulidingprogram_Model> GetCapacityBuilding(string year)
        {
            List<Tran_a_1b_capacitybulidingprogram_Model> list = new List<Tran_a_1b_capacitybulidingprogram_Model>();
            DataTable dt = CapacityBuildingDAL.GetCapacityBuildingByYear(year).Tables[0];
            if (dt.Rows.Count > 0)
            {
                list = (from DataRow dr in dt.Rows
                        select new Tran_a_1b_capacitybulidingprogram_Model()
                        {
                            Record_ID = dr["Record_ID"].ToString(),
                            VAW_Year = dr["VAW_Year"].ToString(),
                            UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                            CvoOrgCode = dr["CvoOrgCode"].ToString(),
                            CvoId = dr["CvoId"].ToString(),
                            FromDate = DateTime.Parse(dr["FromDate"].ToString()),
                            ToDate = DateTime.Parse(dr["ToDate"].ToString()),
                            TrainingName = dr["TrainingName"].ToString(),
                            EmployeesTrained =int.Parse(dr["EmployeesTrained"].ToString()),
                            BriefDescription = dr["BriefDescription"].ToString(),
                            CreatedOn = dr["CreatedOn"].ToString(),
                            CreatedBy = dr["CreatedBy"].ToString(),
                            CreatedByIP = dr["CreatedByIP"].ToString(),
                            CreatedBySession = dr["CreatedBySession"].ToString(),
                            UpdatedOn = dr["UpdatedOn"].ToString(),
                            UpdatedBy = dr["UpdatedBy"].ToString(),
                            UpdatedByIp = dr["UpdatedByIp"].ToString()

                        }).ToList();
            }
            return list;
        }

        public DataSet GetCapacityBuildingRecordByCVOID(string cvoid)
        {
            return CapacityBuildingDAL.GetCapacityBuildingRecordByCVOID(cvoid);
        }
        public int SaveCapacityBuilding(Tran_a_1b_capacitybulidingprogram_Model capacityBuildingObj)
        {
            return CapacityBuildingDAL.SaveCapacityBuilding(capacityBuildingObj);
        }
    }
}
