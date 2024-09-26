using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
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
        //===============================================================================================================================
        #region Capacity Building .1


        public DataSet GetCapacityBuildingRecordByRecordId(int id)
        {           
            DataSet DS = new DataSet();
            try
            {
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadCapacityBuildingProgram", Sqlpara);

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
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_CvoId", cvoid);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadCapacityBuildingProgramByCVOID", Sqlpara);

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
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", ID);
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
        public int SaveCapacityBuilding(Tran_a_1b_capacitybulidingprogram_Model capacityBuildingObj)
        {
            int EffectedRows = 0;
            try
            {

                MySqlParameter[] Sqlpara = new MySqlParameter[13];
                Sqlpara[0] = new MySqlParameter("@p_VAW_Year", capacityBuildingObj.VAW_Year);
                Sqlpara[1] = new MySqlParameter("@p_UniqueTransactionId", capacityBuildingObj.UniqueTransactionId);
                Sqlpara[2] = new MySqlParameter("@p_CvoOrgCode", capacityBuildingObj.CvoOrgCode);
                Sqlpara[3] = new MySqlParameter("@p_CvoId", capacityBuildingObj.CvoId);
                Sqlpara[4] = new MySqlParameter("@p_FromDate", capacityBuildingObj.FromDate);
                Sqlpara[5] = new MySqlParameter("@p_ToDate", capacityBuildingObj.ToDate);
                Sqlpara[6] = new MySqlParameter("@p_TrainingName", capacityBuildingObj.TrainingName);
                Sqlpara[7] = new MySqlParameter("@p_EmployeesTrained", capacityBuildingObj.EmployeesTrained);
                Sqlpara[8] = new MySqlParameter("@p_BriefDescription", capacityBuildingObj.BriefDescription);
                Sqlpara[9] = new MySqlParameter("@p_CreatedOn", capacityBuildingObj.CreatedOn);
                Sqlpara[10] = new MySqlParameter("@p_CreatedBy", capacityBuildingObj.CreatedBy);
                Sqlpara[11] = new MySqlParameter("@p_CreatedByIP", capacityBuildingObj.CreatedByIP);
                Sqlpara[12] = new MySqlParameter("@p_CreatedBySession", capacityBuildingObj.CreatedBySession);
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateCapacityBuildingProgram", Sqlpara);
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
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadSysImp", Sqlpara);

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
                MySqlParameter[] Sqlpara = new MySqlParameter[11];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", capacityBuildingObj.Record_ID);
                Sqlpara[1] = new MySqlParameter("@p_VAW_Year", capacityBuildingObj.VAW_Year);
                Sqlpara[2] = new MySqlParameter("@p_FromDate", capacityBuildingObj.FromDate);
                Sqlpara[3] = new MySqlParameter("@p_ToDate", capacityBuildingObj.ToDate);
                Sqlpara[4] = new MySqlParameter("@p_TrainingName", capacityBuildingObj.TrainingName);
                Sqlpara[5] = new MySqlParameter("@p_EmployeesTrained", capacityBuildingObj.EmployeesTrained);
                Sqlpara[6] = new MySqlParameter("@p_BriefDescription", capacityBuildingObj.BriefDescription);
                Sqlpara[7] = new MySqlParameter("@p_CreatedOn", capacityBuildingObj.CreatedOn);
                Sqlpara[8] = new MySqlParameter("@p_CreatedBy", capacityBuildingObj.CreatedBy);
                Sqlpara[9] = new MySqlParameter("@p_CreatedByIP", capacityBuildingObj.CreatedByIP);
                Sqlpara[10] = new MySqlParameter("@p_CreatedBySession", capacityBuildingObj.CreatedBySession);

                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateCapacityBuildingProgram", Sqlpara);
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
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_CvoId", cvoid);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadSysImpByCVOID", Sqlpara);

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
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", ID);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadSysImp", Sqlpara);

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

                MySqlParameter[] Sqlpara = new MySqlParameter[12];
                Sqlpara[0] = new MySqlParameter("@p_VAW_Year", IdentificationAndImpliObj.VAW_Year);
                Sqlpara[1] = new MySqlParameter("@p_UniqueTransactionId", IdentificationAndImpliObj.UniqueTransactionId);
                Sqlpara[2] = new MySqlParameter("@p_CvoOrgCode", IdentificationAndImpliObj.CvoOrgCode);
                Sqlpara[3] = new MySqlParameter("@p_CvoId", IdentificationAndImpliObj.CvoId);
                Sqlpara[4] = new MySqlParameter("@p_FromDate", IdentificationAndImpliObj.FromDate);
                Sqlpara[5] = new MySqlParameter("@p_ToDate", IdentificationAndImpliObj.ToDate);
                Sqlpara[6] = new MySqlParameter("@p_Sys_Imp_Implemented_During_Campaign", IdentificationAndImpliObj.Sys_Imp_Implemented_During_Campaign);
                Sqlpara[7] = new MySqlParameter("@p_Sys_Imp_Suggested_Last_5_Years_But_Pending", IdentificationAndImpliObj.Sys_Imp_Suggested_Last_5_Years_But_Pending);
                Sqlpara[8] = new MySqlParameter("@p_CreatedOn", IdentificationAndImpliObj.CreatedOn);
                Sqlpara[9] = new MySqlParameter("@p_CreatedBy", IdentificationAndImpliObj.CreatedBy);
                Sqlpara[10] = new MySqlParameter("@p_CreatedByIP", IdentificationAndImpliObj.CreatedByIP);
                Sqlpara[11] = new MySqlParameter("@p_CreatedBySession", IdentificationAndImpliObj.CreatedBySession);
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateSysImp", Sqlpara);
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
                MySqlParameter[] Sqlpara = new MySqlParameter[10];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", IdentificationAndImpliObj.Record_ID);
                Sqlpara[1] = new MySqlParameter("@p_VAW_Year", IdentificationAndImpliObj.VAW_Year);
                Sqlpara[2] = new MySqlParameter("@p_FromDate", IdentificationAndImpliObj.FromDate);
                Sqlpara[3] = new MySqlParameter("@p_ToDate", IdentificationAndImpliObj.ToDate);
                Sqlpara[4] = new MySqlParameter("@p_Sys_Imp_Implemented_During_Campaign", IdentificationAndImpliObj.Sys_Imp_Implemented_During_Campaign);
                Sqlpara[5] = new MySqlParameter("@p_Sys_Imp_Suggested_Last_5_Years_But_Pending", IdentificationAndImpliObj.Sys_Imp_Suggested_Last_5_Years_But_Pending);
                Sqlpara[6] = new MySqlParameter("@p_CreatedOn", IdentificationAndImpliObj.CreatedOn);
                Sqlpara[7] = new MySqlParameter("@p_CreatedBy", IdentificationAndImpliObj.CreatedBy);
                Sqlpara[8] = new MySqlParameter("@p_CreatedByIP", IdentificationAndImpliObj.CreatedByIP);
                Sqlpara[9] = new MySqlParameter("@p_CreatedBySession", IdentificationAndImpliObj.CreatedBySession);
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateSysImp", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        #endregion

        public DataSet GetCircularsRecordByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadUpdationCircularGuidelinesManuals", Sqlpara);

            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        //===============================================================================================================================
        #region Updation of Circulars .3

        public DataSet GetCircularsRecordByCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_CvoId", cvoid);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadUpdationCircularGuidelinesManualsByCVOID", Sqlpara);

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
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", ID);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadUpdationCircularGuidelinesManuals", Sqlpara);

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
                MySqlParameter[] Sqlpara = new MySqlParameter[12];
                Sqlpara[0] = new MySqlParameter("@p_VAW_Year", CircularModel.VAW_Year);
                Sqlpara[1] = new MySqlParameter("@p_UniqueTransactionId", CircularModel.UniqueTransactionId);
                Sqlpara[2] = new MySqlParameter("@p_CvoOrgCode", CircularModel.CvoOrgCode);
                Sqlpara[3] = new MySqlParameter("@p_CvoId", CircularModel.CvoId);
                Sqlpara[4] = new MySqlParameter("@p_FromDate", CircularModel.FromDate);
                Sqlpara[5] = new MySqlParameter("@p_ToDate", CircularModel.ToDate);
                Sqlpara[6] = new MySqlParameter("@p_WhetherUpdatedDuingCampaign", CircularModel.WhetherUpdatedDuingCampaign);
                Sqlpara[7] = new MySqlParameter("@p_BriefDetails", CircularModel.BriefDetails);
                Sqlpara[8] = new MySqlParameter("@p_CreatedOn", CircularModel.CreatedOn);
                Sqlpara[9] = new MySqlParameter("@p_CreatedBy", CircularModel.CreatedBy);
                Sqlpara[10] = new MySqlParameter("@p_CreatedByIP", CircularModel.CreatedByIP);
                Sqlpara[11] = new MySqlParameter("@p_CreatedBySession", CircularModel.CreatedBySession);
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateUpdationCircularGuidelinesManuals", Sqlpara);
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
                MySqlParameter[] Sqlpara = new MySqlParameter[9];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", CircularModel.Record_ID);
                Sqlpara[1] = new MySqlParameter("@p_VAW_Year", CircularModel.VAW_Year);
                Sqlpara[2] = new MySqlParameter("@p_FromDate", CircularModel.FromDate);
                Sqlpara[3] = new MySqlParameter("@p_ToDate", CircularModel.ToDate);
                Sqlpara[4] = new MySqlParameter("@p_WhetherUpdatedDuingCampaign", CircularModel.WhetherUpdatedDuingCampaign);
                Sqlpara[5] = new MySqlParameter("@p_BriefDetails", CircularModel.BriefDetails);
                Sqlpara[6] = new MySqlParameter("@p_CreatedOn", CircularModel.CreatedOn);
                Sqlpara[7] = new MySqlParameter("@p_CreatedBy", CircularModel.CreatedBy);
                Sqlpara[8] = new MySqlParameter("@p_CreatedByIP", CircularModel.CreatedByIP);
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateUpdationCircularGuidelinesManuals", Sqlpara);
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
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_CvoId", cvoid);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDisposalOfComplaintsByCVOID", Sqlpara);

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
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", ID);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDisposalOfComplaints", Sqlpara);

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

                MySqlParameter[] Sqlpara = new MySqlParameter[14];
                Sqlpara[0] = new MySqlParameter("@p_VAW_Year", DisposalOfComlaintObj.VAW_Year);
                Sqlpara[1] = new MySqlParameter("@p_UniqueTransactionId", DisposalOfComlaintObj.UniqueTransactionId);
                Sqlpara[2] = new MySqlParameter("@p_CvoOrgCode", DisposalOfComlaintObj.CvoOrgCode);
                Sqlpara[3] = new MySqlParameter("@p_CvoId", DisposalOfComlaintObj.CvoId);
                Sqlpara[4] = new MySqlParameter("@p_NoOf_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608", DisposalOfComlaintObj.NoOf_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608);
                Sqlpara[5] = new MySqlParameter("@p_Remarks_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608", DisposalOfComlaintObj.Remarks_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608);
                Sqlpara[6] = new MySqlParameter("@p_NoOf_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign", DisposalOfComlaintObj.NoOf_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign);
                Sqlpara[7] = new MySqlParameter("@p_Remarks_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign", DisposalOfComlaintObj.Remarks_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign);
                Sqlpara[8] = new MySqlParameter("@p_NoOf_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511", DisposalOfComlaintObj.NoOf_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511);
                Sqlpara[9] = new MySqlParameter("@p_Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511", DisposalOfComlaintObj.Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511);
                Sqlpara[10] = new MySqlParameter("@p_CreatedOn", DisposalOfComlaintObj.CreatedOn);
                Sqlpara[11] = new MySqlParameter("@p_CreatedBy", DisposalOfComlaintObj.CreatedBy);
                Sqlpara[12] = new MySqlParameter("@p_CreatedByIP", DisposalOfComlaintObj.CreatedByIP);
                Sqlpara[13] = new MySqlParameter("@p_CreatedBySession", DisposalOfComlaintObj.CreatedBySession);
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateDisposalOfComplaints", Sqlpara);
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

                MySqlParameter[] Sqlpara = new MySqlParameter[11];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", DisposalOfComlaintObj.Record_ID);
                Sqlpara[1] = new MySqlParameter("@p_VAW_Year", DisposalOfComlaintObj.VAW_Year);
                Sqlpara[2] = new MySqlParameter("@p_NoOf_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608", DisposalOfComlaintObj.NoOf_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608);
                Sqlpara[3] = new MySqlParameter("@p_Remarks_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608", DisposalOfComlaintObj.Remarks_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608);
                Sqlpara[4] = new MySqlParameter("@p_NoOf_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign", DisposalOfComlaintObj.NoOf_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign);
                Sqlpara[5] = new MySqlParameter("@p_Remarks_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign", DisposalOfComlaintObj.Remarks_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign);
                Sqlpara[6] = new MySqlParameter("@p_NoOf_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511", DisposalOfComlaintObj.NoOf_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511);
                Sqlpara[7] = new MySqlParameter("@p_Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511", DisposalOfComlaintObj.Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511);
                Sqlpara[8] = new MySqlParameter("@p_CreatedOn", DisposalOfComlaintObj.CreatedOn);
                Sqlpara[9] = new MySqlParameter("@p_CreatedBy", DisposalOfComlaintObj.CreatedBy);
                Sqlpara[10] = new MySqlParameter("@p_CreatedByIP", DisposalOfComlaintObj.CreatedByIP);
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateDisposalOfComplaints", Sqlpara);
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
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDynamicDigitalPresence", Sqlpara);

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
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_CvoId", cvoid);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDynamicDigitalPresenceByCVOID", Sqlpara);

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
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", ID);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDynamicDigitalPresence", Sqlpara);

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

                MySqlParameter[] Sqlpara = new MySqlParameter[12];
                Sqlpara[0] = new MySqlParameter("@p_VAW_Year", DynamicDigital.VAW_Year);
                Sqlpara[1] = new MySqlParameter("@p_UniqueTransactionId", DynamicDigital.UniqueTransactionId);
                Sqlpara[2] = new MySqlParameter("@p_CvoOrgCode", DynamicDigital.CvoOrgCode);
                Sqlpara[3] = new MySqlParameter("@p_CvoId", DynamicDigital.CvoId);
                Sqlpara[4] = new MySqlParameter("@p_WhetherRegularMaintenanceOfWebsiteUpdationDone", DynamicDigital.WhetherRegularMaintenanceOfWebsiteUpdationDone);
                Sqlpara[5] = new MySqlParameter("@p_SystemIntroducedForUpdationAndReview", DynamicDigital.SystemIntroducedForUpdationAndReview);
                Sqlpara[6] = new MySqlParameter("@p_WhetherAdditionalAreas_Activities_ServicesBroughtOnline", DynamicDigital.WhetherAdditionalAreas_Activities_ServicesBroughtOnline);
                Sqlpara[7] = new MySqlParameter("@p_DetailsOfAdditionalActivities", DynamicDigital.DetailsOfAdditionalActivities);
                Sqlpara[8] = new MySqlParameter("@p_CreatedOn", DynamicDigital.CreatedOn);
                Sqlpara[9] = new MySqlParameter("@p_CreatedBy", DynamicDigital.CreatedBy);
                Sqlpara[10] = new MySqlParameter("@p_CreatedByIP", DynamicDigital.CreatedByIP);
                Sqlpara[11] = new MySqlParameter("@p_CreatedBySession", DynamicDigital.CreatedBySession);
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateDynamicDigitalPresence", Sqlpara);
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
                MySqlParameter[] Sqlpara = new MySqlParameter[9];
                Sqlpara[0] = new MySqlParameter("@p_Record_ID", DynamicDigital.Record_ID);
                Sqlpara[1] = new MySqlParameter("@p_VAW_Year", DynamicDigital.VAW_Year);               
                Sqlpara[2] = new MySqlParameter("@p_WhetherRegularMaintenanceOfWebsiteUpdationDone", DynamicDigital.WhetherRegularMaintenanceOfWebsiteUpdationDone);
                Sqlpara[3] = new MySqlParameter("@p_SystemIntroducedForUpdationAndReview", DynamicDigital.SystemIntroducedForUpdationAndReview);
                Sqlpara[4] = new MySqlParameter("@p_WhetherAdditionalAreas_Activities_ServicesBroughtOnline", DynamicDigital.WhetherAdditionalAreas_Activities_ServicesBroughtOnline);
                Sqlpara[5] = new MySqlParameter("@p_DetailsOfAdditionalActivities", DynamicDigital.DetailsOfAdditionalActivities);
                Sqlpara[6] = new MySqlParameter("@p_CreatedOn", DynamicDigital.CreatedOn);
                Sqlpara[7] = new MySqlParameter("@p_CreatedBy", DynamicDigital.CreatedBy);
                Sqlpara[8] = new MySqlParameter("@p_CreatedByIP", DynamicDigital.CreatedByIP);                
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateDynamicDigitalPresence", Sqlpara);
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
