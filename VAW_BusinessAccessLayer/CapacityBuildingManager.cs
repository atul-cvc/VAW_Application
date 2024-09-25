﻿using System;
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

        public DataSet GetCapacityBuildingRecordByRecordId(int id)
        {
            return CapacityBuildingDAL.GetCapacityBuildingRecordByRecordId(id);
        }
        public DataSet GetCapacityBuildingRecordByCVOID(string cvoid)
        {
            return CapacityBuildingDAL.GetCapacityBuildingRecordByCVOID(cvoid);
        }
        public int SaveCapacityBuilding(Tran_a_1b_capacitybulidingprogram_Model capacityBuildingObj)
        {
            return CapacityBuildingDAL.SaveCapacityBuilding(capacityBuildingObj);
        }

        public DataSet GetSystemImpRecordByRecordId(int id)
        {
            return CapacityBuildingDAL.GetSystemImpRecordByRecordId(id);
        }
        public DataSet GetSystemImpRecordByCVOID(string cvoid)
        {
            return CapacityBuildingDAL.GetSystemImpRecordByCVOID(cvoid);
        }
        public int SaveIdentificationAndImplimentation(Tran_a_2b_sysimp_Model IdentificationAndImpliObj)
        {
            return CapacityBuildingDAL.SaveIdentificationAndImplimentation(IdentificationAndImpliObj);
        }

        public DataSet GetCircularsRecordByRecordId(int id)
        {
            return CapacityBuildingDAL.GetCircularsRecordByRecordId(id);
        }
        public DataSet GetCircularsRecordByCVOID(string cvoid)
        {
            return CapacityBuildingDAL.GetCircularsRecordByCVOID(cvoid);
        }
        public int SaveCirculars(Tran_a_3b_updation_circular_guidelines_manuals_Model CircularModel)
        {
            return CapacityBuildingDAL.SaveCirculars(CircularModel);
        }

        public DataSet GetDisposalOfComplaintByRecordId(int id)
        {
            return CapacityBuildingDAL.GetDisposalOfComplaintByRecordId(id);
        }
        public DataSet GetDisposalOfComplaintByCVOID(string cvoid)
        {
            return CapacityBuildingDAL.GetDisposalOfComplaintByCVOID(cvoid);
        }

        public int SaveDisposalOfComplaint(Tran_a_4b_disposalofcomplaints_Model DisposalOfComlaintObj)
        {
            return CapacityBuildingDAL.SaveDisposalOfComplaint(DisposalOfComlaintObj);
        }


        public DataSet GetDynamicDigitalPresenceByRecordId(int id)
        {
            return CapacityBuildingDAL.GetDynamicDigitalPresenceByRecordId(id);
        }
        public DataSet GetDynamicDigitalPresenceByCVOID(string cvoid)
        {
            return CapacityBuildingDAL.GetDynamicDigitalPresenceByCVOID(cvoid);
        }

        
        public int SaveDynamicDigitalPresence(Tran_a_5b_dynamicdigitalpresence_Model DigitalDynObj)
        {
            return CapacityBuildingDAL.SaveDynamicDigitalPresence(DigitalDynObj);
        }

        
    }
}
