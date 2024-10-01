using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using VAW_Utility;
using System.Data.SqlClient;
using VAW_Models;
using static System.Net.Mime.MediaTypeNames;

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
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", _year);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadCapacityBuildingProgram", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        //===============================================================================================================================
        #region Capacity Building .1


        public DataSet GetCapacityBuildingRecordByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadCapacityBuildingProgram", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetCapacityBuildingRecordByCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadCapacityBuildingProgramByCVOID", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetCapacityBuildingRecordByCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadCapacityBuildingProgramByCVOIDAndYEAR", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetCapacityBuildingRecordByID(int ID)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", ID);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadCapacityBuildingProgram", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetCapacityBuildingRecordByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadCapacityBuildingProgramByYearAndOrg", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public void CreateCapacityBuilding()
        {
            //SqlParameter[] parameters = new SqlParameter[]
            //   {
            //        new SqlParameter("@p_VAW_Year", MySqlDbType.Int32) { Value = 2024 },
            //        new SqlParameter("@p_UniqueTransactionId", MySqlDbType.Text) { Value = "TX123456" },
            //        new SqlParameter("@p_CvoOrgCode", MySqlDbType.Text) { Value = "CVO123" },
            //        new SqlParameter("@p_CvoId", MySqlDbType.Text) { Value = "CVOID456" },
            //        new SqlParameter("@p_FromDate", MySqlDbType.DateTime) { Value = new DateTime(2024, 1, 1) },
            //        new SqlParameter("@p_ToDate", MySqlDbType.DateTime) { Value = new DateTime(2024, 12, 31) },
            //        new SqlParameter("@p_TrainingName", MySqlDbType.Text) { Value = "Leadership Training" },
            //        new SqlParameter("@p_EmployeesTrained", MySqlDbType.Int32) { Value = 50 },
            //        new SqlParameter("@p_BriefDescription", MySqlDbType.Text) { Value = "An extensive leadership training program." },
            //        new SqlParameter("@p_CreatedOn", MySqlDbType.DateTime) { Value = DateTime.Now },
            //        new SqlParameter("@p_CreatedBy", MySqlDbType.Text) { Value = "admin" },
            //        new SqlParameter("@p_CreatedByIP", MySqlDbType.VarChar, 50) { Value = "192.168.1.1" },
            //        new SqlParameter("@p_CreatedBySession", MySqlDbType.Text) { Value = "session123" },
            //        new SqlParameter("@p_UpdatedOn", MySqlDbType.DateTime) { Value = DateTime.Now },
            //        new SqlParameter("@p_UpdatedBy", MySqlDbType.Text) { Value = "admin" },
            //        new SqlParameter("@p_UpdatedByIp", MySqlDbType.Text) { Value = "192.168.1.1" }
            //   };
        }
        public int SaveCapacityBuilding(Tran_a_1b_capacitybulidingprogram_Model capacityBuildingObj)
        {
            int EffectedRows = 0;
            try
            {

                SqlParameter[] Sqlpara = new SqlParameter[13];
                Sqlpara[0] = new SqlParameter("@p_VAW_Year", capacityBuildingObj.VAW_Year);
                Sqlpara[1] = new SqlParameter("@p_UniqueTransactionId", capacityBuildingObj.UniqueTransactionId);
                Sqlpara[2] = new SqlParameter("@p_CvoOrgCode", capacityBuildingObj.CvoOrgCode);
                Sqlpara[3] = new SqlParameter("@p_CvoId", capacityBuildingObj.CvoId);
                Sqlpara[4] = new SqlParameter("@p_FromDate", capacityBuildingObj.FromDate);
                Sqlpara[5] = new SqlParameter("@p_ToDate", capacityBuildingObj.ToDate);
                Sqlpara[6] = new SqlParameter("@p_TrainingName", capacityBuildingObj.TrainingName);
                Sqlpara[7] = new SqlParameter("@p_EmployeesTrained", capacityBuildingObj.EmployeesTrained);
                Sqlpara[8] = new SqlParameter("@p_BriefDescription", capacityBuildingObj.BriefDescription);
                Sqlpara[9] = new SqlParameter("@p_CreatedOn", capacityBuildingObj.CreatedOn);
                Sqlpara[10] = new SqlParameter("@p_CreatedBy", capacityBuildingObj.CreatedBy);
                Sqlpara[11] = new SqlParameter("@p_CreatedByIP", capacityBuildingObj.CreatedByIP);
                Sqlpara[12] = new SqlParameter("@p_CreatedBySession", capacityBuildingObj.CreatedBySession);
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateCapacityBuildingProgram", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        public DataSet GetSystemImpRecordByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadSysImp", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        public int UpdateCapacityBuilding(Tran_a_1b_capacitybulidingprogram_Model capacityBuildingObj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[11];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", capacityBuildingObj.Record_ID);
                Sqlpara[1] = new SqlParameter("@p_VAW_Year", capacityBuildingObj.VAW_Year);
                Sqlpara[2] = new SqlParameter("@p_FromDate", capacityBuildingObj.FromDate);
                Sqlpara[3] = new SqlParameter("@p_ToDate", capacityBuildingObj.ToDate);
                Sqlpara[4] = new SqlParameter("@p_TrainingName", capacityBuildingObj.TrainingName);
                Sqlpara[5] = new SqlParameter("@p_EmployeesTrained", capacityBuildingObj.EmployeesTrained);
                Sqlpara[6] = new SqlParameter("@p_BriefDescription", capacityBuildingObj.BriefDescription);
                Sqlpara[7] = new SqlParameter("@p_CreatedOn", capacityBuildingObj.CreatedOn);
                Sqlpara[8] = new SqlParameter("@p_CreatedBy", capacityBuildingObj.CreatedBy);
                Sqlpara[9] = new SqlParameter("@p_CreatedByIP", capacityBuildingObj.CreatedByIP);
                Sqlpara[10] = new SqlParameter("@p_CreatedBySession", capacityBuildingObj.CreatedBySession);

                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateCapacityBuildingProgram", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        #endregion
        //===============================================================================================================================

        #region Identification and Implementation of Systemic Improvement Measures .2
        public DataSet GetSystemImpRecordByCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadSysImpByCVOID", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetSystemImpRecordByCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadSysImpByCVOIDAndYEAR", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetSystemImpRecordByRecordID(int ID)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", ID);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadSysImp", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetSystemImpRecordByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadSysImpByYearAndOrg", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        public int SaveIdentificationAndImplimentation(Tran_a_2b_sysimp_Model IdentificationAndImpliObj)
        {
            int EffectedRows = 0;
            try
            {

                SqlParameter[] Sqlpara = new SqlParameter[15];
                Sqlpara[0] = new SqlParameter("@p_VAW_Year", IdentificationAndImpliObj.VAW_Year);
                Sqlpara[1] = new SqlParameter("@p_UniqueTransactionId", IdentificationAndImpliObj.UniqueTransactionId);
                Sqlpara[2] = new SqlParameter("@p_CvoOrgCode", IdentificationAndImpliObj.CvoOrgCode);
                Sqlpara[3] = new SqlParameter("@p_CvoId", IdentificationAndImpliObj.CvoId);
                Sqlpara[4] = new SqlParameter("@p_FromDate", IdentificationAndImpliObj.FromDate);
                Sqlpara[5] = new SqlParameter("@p_ToDate", IdentificationAndImpliObj.ToDate);
                Sqlpara[6] = new SqlParameter("@p_Sys_Imp_Implemented_During_Campaign", IdentificationAndImpliObj.Sys_Imp_Implemented_During_Campaign);
                Sqlpara[7] = new SqlParameter("@p_Sys_Imp_Suggested_Last_5_Years_But_Pending", IdentificationAndImpliObj.Sys_Imp_Suggested_Last_5_Years_But_Pending);
                Sqlpara[8] = new SqlParameter("@p_CreatedOn", IdentificationAndImpliObj.CreatedOn);
                Sqlpara[9] = new SqlParameter("@p_CreatedBy", IdentificationAndImpliObj.CreatedBy);
                Sqlpara[10] = new SqlParameter("@p_CreatedByIP", IdentificationAndImpliObj.CreatedByIP);
                Sqlpara[11] = new SqlParameter("@p_CreatedBySession", IdentificationAndImpliObj.CreatedBySession);
                Sqlpara[12] = new SqlParameter("@p_NoOf_Cases_Analysis", IdentificationAndImpliObj.NoOf_CasesTakenForAnalysis_past5Years);
                Sqlpara[13] = new SqlParameter("@p_KeyAreas_BasesdOn_Analysis", IdentificationAndImpliObj.KeyAreasDetected_BasedonAnalysis);
                Sqlpara[14] = new SqlParameter("@p_Sys_Improvements_Analysis", IdentificationAndImpliObj.Sys_Improvements_Identified_And_Impl_BasedOnAnalysis);
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateSysImp", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int UpdateIdentificationAndImplimentation(Tran_a_2b_sysimp_Model IdentificationAndImpliObj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[13];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", IdentificationAndImpliObj.Record_ID);
                Sqlpara[1] = new SqlParameter("@p_VAW_Year", IdentificationAndImpliObj.VAW_Year);
                Sqlpara[2] = new SqlParameter("@p_FromDate", IdentificationAndImpliObj.FromDate);
                Sqlpara[3] = new SqlParameter("@p_ToDate", IdentificationAndImpliObj.ToDate);
                Sqlpara[4] = new SqlParameter("@p_Sys_Imp_Implemented_During_Campaign", IdentificationAndImpliObj.Sys_Imp_Implemented_During_Campaign);
                Sqlpara[5] = new SqlParameter("@p_Sys_Imp_Suggested_Last_5_Years_But_Pending", IdentificationAndImpliObj.Sys_Imp_Suggested_Last_5_Years_But_Pending);
                Sqlpara[6] = new SqlParameter("@p_CreatedOn", IdentificationAndImpliObj.CreatedOn);
                Sqlpara[7] = new SqlParameter("@p_CreatedBy", IdentificationAndImpliObj.CreatedBy);
                Sqlpara[8] = new SqlParameter("@p_CreatedByIP", IdentificationAndImpliObj.CreatedByIP);
                Sqlpara[9] = new SqlParameter("@p_CreatedBySession", IdentificationAndImpliObj.CreatedBySession);
                Sqlpara[10] = new SqlParameter("@p_NoOf_Cases_Analysis", IdentificationAndImpliObj.NoOf_CasesTakenForAnalysis_past5Years);
                Sqlpara[11] = new SqlParameter("@p_KeyAreas_BasesdOn_Analysis", IdentificationAndImpliObj.KeyAreasDetected_BasedonAnalysis);
                Sqlpara[12] = new SqlParameter("@p_Sys_Improvements_Analysis", IdentificationAndImpliObj.Sys_Improvements_Identified_And_Impl_BasedOnAnalysis);
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateSysImp", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        #endregion

        //===============================================================================================================================
        #region Updation of Circulars .3

        public DataSet GetCircularsRecordByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadUpdationCircularGuidelinesManuals", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        public DataSet GetCircularsRecordByCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadUpdationCircularGuidelinesManualsByCVOID", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetCircularsRecordByCVOIDandYear(string cvoid,string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadUpdationCircularGuidelinesManualsByCVOIDAndYEAR", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetCircularsByRecordID(int ID)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", ID);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadUpdationCircularGuidelinesManuals", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetCircularsByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadUpdationCircularGuidelinesManualsByYearAndOrg", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public int SaveCirculars(Tran_a_3b_updation_circular_guidelines_manuals_Model CircularModel)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[12];
                Sqlpara[0] = new SqlParameter("@p_VAW_Year", CircularModel.VAW_Year);
                Sqlpara[1] = new SqlParameter("@p_UniqueTransactionId", CircularModel.UniqueTransactionId);
                Sqlpara[2] = new SqlParameter("@p_CvoOrgCode", CircularModel.CvoOrgCode);
                Sqlpara[3] = new SqlParameter("@p_CvoId", CircularModel.CvoId);
                Sqlpara[4] = new SqlParameter("@p_FromDate", CircularModel.FromDate);
                Sqlpara[5] = new SqlParameter("@p_ToDate", CircularModel.ToDate);
                Sqlpara[6] = new SqlParameter("@p_WhetherUpdatedDuingCampaign", CircularModel.WhetherUpdatedDuingCampaign);
                Sqlpara[7] = new SqlParameter("@p_BriefDetails", CircularModel.BriefDetails);
                Sqlpara[8] = new SqlParameter("@p_CreatedOn", CircularModel.CreatedOn);
                Sqlpara[9] = new SqlParameter("@p_CreatedBy", CircularModel.CreatedBy);
                Sqlpara[10] = new SqlParameter("@p_CreatedByIP", CircularModel.CreatedByIP);
                Sqlpara[11] = new SqlParameter("@p_CreatedBySession", CircularModel.CreatedBySession);
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateUpdationCircularGuidelinesManuals", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int UpdateCirculars(Tran_a_3b_updation_circular_guidelines_manuals_Model CircularModel)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[9];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", CircularModel.Record_ID);
                Sqlpara[1] = new SqlParameter("@p_VAW_Year", CircularModel.VAW_Year);
                Sqlpara[2] = new SqlParameter("@p_FromDate", CircularModel.FromDate);
                Sqlpara[3] = new SqlParameter("@p_ToDate", CircularModel.ToDate);
                Sqlpara[4] = new SqlParameter("@p_WhetherUpdatedDuingCampaign", CircularModel.WhetherUpdatedDuingCampaign);
                Sqlpara[5] = new SqlParameter("@p_BriefDetails", CircularModel.BriefDetails);
                Sqlpara[6] = new SqlParameter("@p_CreatedOn", CircularModel.CreatedOn);
                Sqlpara[7] = new SqlParameter("@p_CreatedBy", CircularModel.CreatedBy);
                Sqlpara[8] = new SqlParameter("@p_CreatedByIP", CircularModel.CreatedByIP);
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateUpdationCircularGuidelinesManuals", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        #endregion
        //===============================================================================================================================
        #region Disposal of Complaints .4
        public DataSet GetDisposalOfComplaintByCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDisposalOfComplaintsByCVOID", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetDisposalOfComplaintByCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDisposalOfComplaintsByCVOIDAndYEAR", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetDisposalOfComplaintByRecordID(int ID)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", ID);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDisposalOfComplaints", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetDisposalOfComplaintByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDisposalOfComplaintsByYearAndOrg", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public int SaveDisposalOfComplaint(Tran_a_4b_disposalofcomplaints_Model DisposalOfComlaintObj)
        {
            int EffectedRows = 0;
            try
            {

                SqlParameter[] Sqlpara = new SqlParameter[14];
                Sqlpara[0] = new SqlParameter("@p_VAW_Year", DisposalOfComlaintObj.VAW_Year);
                Sqlpara[1] = new SqlParameter("@p_UniqueTransactionId", DisposalOfComlaintObj.UniqueTransactionId);
                Sqlpara[2] = new SqlParameter("@p_CvoOrgCode", DisposalOfComlaintObj.CvoOrgCode);
                Sqlpara[3] = new SqlParameter("@p_CvoId", DisposalOfComlaintObj.CvoId);
                Sqlpara[4] = new SqlParameter("@p_NoOf_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608", DisposalOfComlaintObj.NoOf_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608);
                Sqlpara[5] = new SqlParameter("@p_Remarks_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608", DisposalOfComlaintObj.Remarks_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608 ?? "");
                Sqlpara[6] = new SqlParameter("@p_NoOf_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign", DisposalOfComlaintObj.NoOf_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign);
                Sqlpara[7] = new SqlParameter("@p_Remarks_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign", DisposalOfComlaintObj.Remarks_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign ?? "");
                Sqlpara[8] = new SqlParameter("@p_NoOf_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511", DisposalOfComlaintObj.NoOf_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511);
                Sqlpara[9] = new SqlParameter("@p_Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511", DisposalOfComlaintObj.Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511 ?? "");
                Sqlpara[10] = new SqlParameter("@p_CreatedOn", DisposalOfComlaintObj.CreatedOn);
                Sqlpara[11] = new SqlParameter("@p_CreatedBy", DisposalOfComlaintObj.CreatedBy);
                Sqlpara[12] = new SqlParameter("@p_CreatedByIP", DisposalOfComlaintObj.CreatedByIP);
                Sqlpara[13] = new SqlParameter("@p_CreatedBySession", DisposalOfComlaintObj.CreatedBySession);
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateDisposalOfComplaints", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int UpdateDisposalOfComplaint(Tran_a_4b_disposalofcomplaints_Model DisposalOfComlaintObj)
        {
            int EffectedRows = 0;
            try
            {

                SqlParameter[] Sqlpara = new SqlParameter[11];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", DisposalOfComlaintObj.Record_ID);
                Sqlpara[1] = new SqlParameter("@p_VAW_Year", DisposalOfComlaintObj.VAW_Year);
                Sqlpara[2] = new SqlParameter("@p_NoOf_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608", DisposalOfComlaintObj.NoOf_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608);
                Sqlpara[3] = new SqlParameter("@p_Remarks_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608", DisposalOfComlaintObj.Remarks_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608);
                Sqlpara[4] = new SqlParameter("@p_NoOf_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign", DisposalOfComlaintObj.NoOf_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign);
                Sqlpara[5] = new SqlParameter("@p_Remarks_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign", DisposalOfComlaintObj.Remarks_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign);
                Sqlpara[6] = new SqlParameter("@p_NoOf_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511", DisposalOfComlaintObj.NoOf_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511);
                Sqlpara[7] = new SqlParameter("@p_Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511", DisposalOfComlaintObj.Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511);
                Sqlpara[8] = new SqlParameter("@p_CreatedOn", DisposalOfComlaintObj.CreatedOn);
                Sqlpara[9] = new SqlParameter("@p_CreatedBy", DisposalOfComlaintObj.CreatedBy);
                Sqlpara[10] = new SqlParameter("@p_CreatedByIP", DisposalOfComlaintObj.CreatedByIP);
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateDisposalOfComplaints", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        #endregion

        //===============================================================================================================================
        #region Digital Dynamic Presence .5
        public DataSet GetDynamicDigitalPresenceByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDynamicDigitalPresence", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        public DataSet GetDynamicDigitalPresenceByCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDynamicDigitalPresenceByCVOID", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetDynamicDigitalPresenceByCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDynamicDigitalPresenceByCVOIDAndYEAR", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetDynamicDigitalPresenceByRecordID(int ID)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", ID);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDynamicDigitalPresence", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetDynamicDigitalPresenceByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDynamicDigitalPresenceByYearAndOrg", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        public int SaveDynamicDigitalPresence(Tran_a_5b_dynamicdigitalpresence_Model DynamicDigital)
        {
            int EffectedRows = 0;
            try
            {

                SqlParameter[] Sqlpara = new SqlParameter[12];
                Sqlpara[0] = new SqlParameter("@p_VAW_Year", DynamicDigital.VAW_Year);
                Sqlpara[1] = new SqlParameter("@p_UniqueTransactionId", DynamicDigital.UniqueTransactionId);
                Sqlpara[2] = new SqlParameter("@p_CvoOrgCode", DynamicDigital.CvoOrgCode);
                Sqlpara[3] = new SqlParameter("@p_CvoId", DynamicDigital.CvoId);
                Sqlpara[4] = new SqlParameter("@p_WhetherRegularMaintenanceOfWebsiteUpdationDone", DynamicDigital.WhetherRegularMaintenanceOfWebsiteUpdationDone);
                Sqlpara[5] = new SqlParameter("@p_SystemIntroducedForUpdationAndReview", DynamicDigital.SystemIntroducedForUpdationAndReview);
                Sqlpara[6] = new SqlParameter("@p_WhetherAdditionalAreas_Activities_ServicesBroughtOnline", DynamicDigital.WhetherAdditionalAreas_Activities_ServicesBroughtOnline);
                Sqlpara[7] = new SqlParameter("@p_DetailsOfAdditionalActivities", DynamicDigital.DetailsOfAdditionalActivities);
                Sqlpara[8] = new SqlParameter("@p_CreatedOn", DynamicDigital.CreatedOn);
                Sqlpara[9] = new SqlParameter("@p_CreatedBy", DynamicDigital.CreatedBy);
                Sqlpara[10] = new SqlParameter("@p_CreatedByIP", DynamicDigital.CreatedByIP);
                Sqlpara[11] = new SqlParameter("@p_CreatedBySession", DynamicDigital.CreatedBySession);
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateDynamicDigitalPresence", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int UpdateDynamicDigitalPresence(Tran_a_5b_dynamicdigitalpresence_Model DynamicDigital)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[9];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", DynamicDigital.Record_ID);
                Sqlpara[1] = new SqlParameter("@p_VAW_Year", DynamicDigital.VAW_Year);
                Sqlpara[2] = new SqlParameter("@p_WhetherRegularMaintenanceOfWebsiteUpdationDone", DynamicDigital.WhetherRegularMaintenanceOfWebsiteUpdationDone);
                Sqlpara[3] = new SqlParameter("@p_SystemIntroducedForUpdationAndReview", DynamicDigital.SystemIntroducedForUpdationAndReview);
                Sqlpara[4] = new SqlParameter("@p_WhetherAdditionalAreas_Activities_ServicesBroughtOnline", DynamicDigital.WhetherAdditionalAreas_Activities_ServicesBroughtOnline);
                Sqlpara[5] = new SqlParameter("@p_DetailsOfAdditionalActivities", DynamicDigital.DetailsOfAdditionalActivities);
                Sqlpara[6] = new SqlParameter("@p_CreatedOn", DynamicDigital.CreatedOn);
                Sqlpara[7] = new SqlParameter("@p_CreatedBy", DynamicDigital.CreatedBy);
                Sqlpara[8] = new SqlParameter("@p_CreatedByIP", DynamicDigital.CreatedByIP);
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateDynamicDigitalPresence", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        #endregion
        //===============================================================================================================================
    }
}
