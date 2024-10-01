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

        public DataSet GetIntegrityPledgeByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadIntegrityPledge", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetIntegrityPledgeByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadIntegrityPledgeByYearAndOrg", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetIntegrityPledgeBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadIntegrityPledgeByCVOID", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetIntegrityPledgeBYCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadIntegrityPledgeByCVOIDAndYEAR", Sqlpara);
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
                SqlParameter[] Sqlpara = new SqlParameter[15];
                Sqlpara[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                Sqlpara[1] = new SqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                Sqlpara[2] = new SqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                Sqlpara[3] = new SqlParameter("@p_CvoId", obj.CvoId);
                Sqlpara[4] = new SqlParameter("@p_DateOfActivity", Convert.ToDateTime(obj.DateOfActivity));
                Sqlpara[5] = new SqlParameter("@p_TotalNoOfEmployees_UndertakenPledge", Convert.ToInt32(obj.TotalNoOfEmployees_UndertakenPledge));
                Sqlpara[6] = new SqlParameter("@p_TotalNoOfCustomers_UndertakenPledge", Convert.ToInt32(obj.TotalNoOfCustomers_UndertakenPledge));
                Sqlpara[7] = new SqlParameter("@p_TotalNoOfCitizen_UndertakenPledge", Convert.ToInt32(obj.TotalNoOfCitizen_UndertakenPledge));
                Sqlpara[8] = new SqlParameter("@p_CreatedOn", DateTime.Now);
                Sqlpara[9] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                Sqlpara[10] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);
                Sqlpara[11] = new SqlParameter("@p_CreatedBySession", obj.CreatedBySession);
                Sqlpara[12] = new SqlParameter("@p_UpdatedOn", DateTime.Now);
                Sqlpara[13] = new SqlParameter("@p_UpdatedBy", obj.UpdatedBy);
                Sqlpara[14] = new SqlParameter("@p_UpdatedByIp", obj.UpdatedByIp);

                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateIntegrityPledge", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int UpdateIntegrityPledge(Tran_1a_integritypledge_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[9];
                Sqlpara[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                Sqlpara[1] = new SqlParameter("@p_Record_ID", obj.Record_ID);
                Sqlpara[2] = new SqlParameter("@p_DateOfActivity", Convert.ToDateTime(obj.DateOfActivity));
                Sqlpara[3] = new SqlParameter("@p_TotalNoOfEmployees_UndertakenPledge", Convert.ToInt32(obj.TotalNoOfEmployees_UndertakenPledge));
                Sqlpara[4] = new SqlParameter("@p_TotalNoOfCustomers_UndertakenPledge", Convert.ToInt32(obj.TotalNoOfCustomers_UndertakenPledge));
                Sqlpara[5] = new SqlParameter("@p_TotalNoOfCitizen_UndertakenPledge", Convert.ToInt32(obj.TotalNoOfCitizen_UndertakenPledge));
                Sqlpara[6] = new SqlParameter("@p_UpdatedOn", obj.UpdatedOn);
                Sqlpara[7] = new SqlParameter("@p_UpdatedBy", obj.UpdatedBy);
                Sqlpara[8] = new SqlParameter("@p_UpdatedByIp", obj.UpdatedByIp);

                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateIntegrityPledge", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        public DataSet GetConductOfCompetitionsByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadConductOfCompetitions", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetConductOfCompetitionsBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadConductOfCompetitionsByCVOID", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetConductOfCompetitionsBYCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadConductOfCompetitionsByCVOIDAndYEAR", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetConductOfCompetitionsByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadConductOfCompetitionsByYearAndOrg", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public int SaveConductOfCompetitions(Tran_2a_orgactivities_conductofcompetitions_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[14];
                sqlParams[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new SqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new SqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new SqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new SqlParameter("@p_DateOfActivity", Convert.ToDateTime(obj.DateOfActivity));
                sqlParams[5] = new SqlParameter("@p_NameOfState", obj.NameOfState);
                sqlParams[6] = new SqlParameter("@p_City", obj.City);
                sqlParams[7] = new SqlParameter("@p_SpecificProgram", obj.SpecificProgram);
                sqlParams[8] = new SqlParameter("@p_NoOfParticipant", Convert.ToInt32(obj.NoOfParticipant));
                sqlParams[9] = new SqlParameter("@p_Remarks", obj.Remarks);
                sqlParams[10] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[11] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[12] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);
                sqlParams[13] = new SqlParameter("@p_CreatedBySession", obj.CreatedBySession);


                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateOrgActivitiesCompetition", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int EditConductOfCompetitions(Tran_2a_orgactivities_conductofcompetitions_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[11];
                sqlParams[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new SqlParameter("@p_Record_ID", obj.Record_ID);
                sqlParams[2] = new SqlParameter("@p_DateOfActivity", Convert.ToDateTime(obj.DateOfActivity));
                sqlParams[3] = new SqlParameter("@p_NameOfState", obj.NameOfState);
                sqlParams[4] = new SqlParameter("@p_City", obj.City);
                sqlParams[5] = new SqlParameter("@p_SpecificProgram", obj.SpecificProgram);
                sqlParams[6] = new SqlParameter("@p_NoOfParticipant", Convert.ToInt32(obj.NoOfParticipant));
                sqlParams[7] = new SqlParameter("@p_Remarks", obj.Remarks);
                sqlParams[8] = new SqlParameter("@p_UpdatedOn", obj.CreatedOn);
                sqlParams[9] = new SqlParameter("@p_UpdatedBy", obj.CreatedBy);
                sqlParams[10] = new SqlParameter("@p_UpdatedByIp", obj.CreatedByIP);

                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateOrgActivitiesCompetition", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        public DataSet GetActivitiesOtherActivitiesByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadActivitiesOtherActivities", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetActivitiesOtherActivitiesBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadActivitiesOtherActivitiesCVOID", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetActivitiesOtherActivitiesBYCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadActivitiesOtherActivitiesCVOIDAndYEAR", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetActivitiesOtherActivitiesByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadActivitiesOtherActivitiesByYearAndOrg", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public int SaveActivitiesOtherActivities(Tran_2b_orgactivities_otheractivities_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[15];
                sqlParams[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new SqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new SqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new SqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[5] = new SqlParameter("@p_DistributionOfPamphletsAndBanners_Details", obj.DistributionOfPamphletsAndBanners_Details);
                sqlParams[6] = new SqlParameter("@p_ConductOfWorkshopAndSensitizationProgram_Details", obj.ConductOfWorkshopAndSensitizationProgram_Details);
                sqlParams[7] = new SqlParameter("@p_IssueOfJornalAndNwesletter_Details", obj.IssueOfJornalAndNwesletter_Details);
                sqlParams[8] = new SqlParameter("@p_AnyOtherActivities_Details", obj.AnyOtherActivities_Details);
                sqlParams[9] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[10] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[11] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);
                sqlParams[12] = new SqlParameter("@p_CreatedBySession", obj.CreatedBySession);

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateOrgActivitiesOtherActivities", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        public int EditActivitiesOtherActivities(Tran_2b_orgactivities_otheractivities_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[10];
                sqlParams[0] = new SqlParameter("@p_Record_ID", Convert.ToInt32(obj.Record_ID));
                sqlParams[1] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[2] = new SqlParameter("@p_UpdatedOn", obj.UpdatedOn);
                sqlParams[3] = new SqlParameter("@p_UpdatedBy", obj.UpdatedBy);
                sqlParams[4] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[5] = new SqlParameter("@p_DistributionOfPamphletsAndBanners_Details", obj.DistributionOfPamphletsAndBanners_Details);
                sqlParams[6] = new SqlParameter("@p_ConductOfWorkshopAndSensitizationProgram_Details", obj.ConductOfWorkshopAndSensitizationProgram_Details);
                sqlParams[7] = new SqlParameter("@p_IssueOfJornalAndNwesletter_Details", obj.IssueOfJornalAndNwesletter_Details);
                sqlParams[8] = new SqlParameter("@p_AnyOtherActivities_Details", obj.AnyOtherActivities_Details);
                sqlParams[9] = new SqlParameter("@p_UpdatedByIp", obj.UpdatedByIp);
                

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateOrgActivitiesOtherActivities", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        #region 3. OUTREACH ACTIVITIES
        #region 3.1. OutreachInvolvingSchoolStudents
        public DataSet GetInvolvingSchoolStudentsByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachInvolvingSchoolStudents", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetInvolvingSchoolStudentsBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachInvolvingSchoolStudentsByCVOID", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetInvolvingSchoolStudentsBYCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachInvolvingSchoolStudentsByCVOIDAndYEAR", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetInvolvingSchoolStudentsByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachInvolvingSchoolStudentsByYearAndOrg", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public int SaveInvolvingSchoolStudents(Tran_3a_outreach_involvingschoolstudents_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[14];
                sqlParams[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new SqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new SqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new SqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[5] = new SqlParameter("@p_StateName", obj.StateName);
                sqlParams[6] = new SqlParameter("@p_City_Town_Village_Name", obj.City_Town_Village_Name);
                sqlParams[7] = new SqlParameter("@p_SchoolName", obj.SchoolName);
                sqlParams[8] = new SqlParameter("@p_ActivityDetails", obj.ActivityDetails);
                sqlParams[9] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[10] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[11] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);
                sqlParams[12] = new SqlParameter("@p_CreatedBySession", obj.CreatedBySession);
                sqlParams[13] = new SqlParameter("@p_NoOfStudentsInvolved", obj.NoOfStudentsInvolved);

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateOutreachInvolvingSchoolStudents", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int UpdateInvolvingSchoolStudents(Tran_3a_outreach_involvingschoolstudents_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[11];
                sqlParams[0] = new SqlParameter("@p_Record_ID", obj.Record_ID);
                sqlParams[1] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[2] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[3] = new SqlParameter("@p_StateName", obj.StateName);
                sqlParams[4] = new SqlParameter("@p_City_Town_Village_Name", obj.City_Town_Village_Name);
                sqlParams[5] = new SqlParameter("@p_SchoolName", obj.SchoolName);
                sqlParams[6] = new SqlParameter("@p_ActivityDetails", obj.ActivityDetails);
                sqlParams[7] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[8] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[9] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);
                sqlParams[10] = new SqlParameter("@p_NoOfStudentsInvolved", obj.NoOfStudentsInvolved);
                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateOutreachInvolvingSchoolStudents", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        #endregion

        #region 3.2. OutreachInvolvingCollegeStudents
        public DataSet GetInvolvingCollegeStudentsByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachInvolvingCollegeStudents", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetInvolvingCollegeStudentsBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachInvolvingCollegeStudentsByCVOID", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetInvolvingCollegeStudentsBYCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachInvolvingCollegeStudentsByCVOIDAndYEAR", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetInvolvingCollegeStudentsByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachInvolvingCollegeStudentsByYearAndOrg", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public int SaveInvolvingCollegeStudents(Tran_3b_outreach_involvingcollegestudents_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[14];
                sqlParams[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new SqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new SqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new SqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[5] = new SqlParameter("@p_StateName", obj.StateName);
                sqlParams[6] = new SqlParameter("@p_City_Town_Village_Name", obj.City_Town_Village_Name);
                sqlParams[7] = new SqlParameter("@p_SchoolName", obj.SchoolName);
                sqlParams[8] = new SqlParameter("@p_ActivityDetails", obj.ActivityDetails);
                sqlParams[9] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[10] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[11] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);
                sqlParams[12] = new SqlParameter("@p_CreatedBySession", obj.CreatedBySession);
                sqlParams[13] = new SqlParameter("@p_NoOfStudentsInvolved", obj.NoOfStudentsInvolved);

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateOutreachInvolvingCollegeStudents", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int UpdateInvolvingCollegeStudents(Tran_3b_outreach_involvingcollegestudents_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[11];
                sqlParams[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new SqlParameter("@p_Record_ID", obj.Record_ID);
                sqlParams[2] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[3] = new SqlParameter("@p_StateName", obj.StateName);
                sqlParams[4] = new SqlParameter("@p_City_Town_Village_Name", obj.City_Town_Village_Name);
                sqlParams[5] = new SqlParameter("@p_SchoolName", obj.SchoolName);
                sqlParams[6] = new SqlParameter("@p_ActivityDetails", obj.ActivityDetails);
                sqlParams[7] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[8] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[9] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);
                sqlParams[10] = new SqlParameter("@p_NoOfStudentsInvolved", obj.NoOfStudentsInvolved);

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateOutreachInvolvingCollegeStudents", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        #endregion

        #region 3.3. OutreachAwarenessGramSabhas
        public DataSet GetOutreachAwarenessByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachAwarenessGramSabhas", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetOutreachAwarenessBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachAwarenessGramSabhasByCVOID", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetOutreachAwarenessBYCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachAwarenessGramSabhasByCVOIDAndYEAR", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetOutreachAwarenessByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachAwarenessGramSabhasByYearAndOrg", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        public int SaveOutreachAwareness(Tran_3c_outreach_awarenessgramsabhas_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[14];
                sqlParams[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new SqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new SqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new SqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[5] = new SqlParameter("@p_StateName", obj.StateName);
                sqlParams[6] = new SqlParameter("@p_City_Town_Village_Name", obj.City_Town_Village_Name);
                sqlParams[7] = new SqlParameter("@p_NameOfGramPanchayat", obj.NameOfGramPanchayat);
                sqlParams[8] = new SqlParameter("@p_ActivityDetails", obj.ActivityDetails);
                sqlParams[9] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[10] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[11] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);
                sqlParams[12] = new SqlParameter("@p_CreatedBySession", obj.CreatedBySession);
                sqlParams[13] = new SqlParameter("@p_NoOfPublicOrCitizenParticipated", obj.NoOfPublicOrCitizenParticipated);

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateOutreachAwarenessGramSabhas", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int UpdateOutreachAwareness(Tran_3c_outreach_awarenessgramsabhas_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[11];
                sqlParams[0] = new SqlParameter("@p_Record_ID", obj.Record_ID);
                sqlParams[1] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));                                
                sqlParams[2] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[3] = new SqlParameter("@p_StateName", obj.StateName);
                sqlParams[4] = new SqlParameter("@p_City_Town_Village_Name", obj.City_Town_Village_Name);
                sqlParams[5] = new SqlParameter("@p_NameOfGramPanchayat", obj.NameOfGramPanchayat);
                sqlParams[6] = new SqlParameter("@p_ActivityDetails", obj.ActivityDetails);
                sqlParams[7] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[8] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[9] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);                
                sqlParams[10] = new SqlParameter("@p_NoOfPublicOrCitizenParticipated", obj.NoOfPublicOrCitizenParticipated);

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateOutreachAwarenessGramSabhas", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        #endregion
        #region 3.4. OutreachSeminars


        public DataSet GetSeminarsWorkshopsByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadSeminarsWorkshops", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetSeminarsWorkshopsBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadSeminarsWorkshopsByCVOID", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetSeminarsWorkshopsBYCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadSeminarsWorkshopsByCVOIDAndYEAR", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetSeminarsWorkshopsByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadSeminarsWorkshopsByYearAndOrg", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        public int SaveSeminarsWorkshops(Tran_3d_outreach_seminarsworkshops_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[14];
                sqlParams[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new SqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new SqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new SqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[5] = new SqlParameter("@p_StateName", obj.StateName);
                sqlParams[6] = new SqlParameter("@p_City_Town_Village_Name", obj.City_Town_Village_Name);
                sqlParams[7] = new SqlParameter("@p_NoOfSeminarsWorkshops", obj.NoOfSeminarsWorkshops);
                sqlParams[8] = new SqlParameter("@p_ActivityDetails", obj.ActivityDetails);
                sqlParams[9] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[10] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[11] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);
                sqlParams[12] = new SqlParameter("@p_CreatedBySession", obj.CreatedBySession);
                sqlParams[13] = new SqlParameter("@p_NoOfPublicOrCitizenParticipated", obj.NoOfPublicOrCitizenParticipated);

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateSeminarsWorkshops", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int UpdateSeminarsWorkshops(Tran_3d_outreach_seminarsworkshops_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[11];
                sqlParams[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new SqlParameter("@p_Record_ID", obj.Record_ID);               
                sqlParams[2] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[3] = new SqlParameter("@p_StateName", obj.StateName);
                sqlParams[4] = new SqlParameter("@p_City_Town_Village_Name", obj.City_Town_Village_Name);
                sqlParams[5] = new SqlParameter("@p_NoOfSeminarsWorkshops", obj.NoOfSeminarsWorkshops);
                sqlParams[6] = new SqlParameter("@p_ActivityDetails", obj.ActivityDetails);
                sqlParams[7] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[8] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[9] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);                
                sqlParams[10] = new SqlParameter("@p_NoOfPublicOrCitizenParticipated", obj.NoOfPublicOrCitizenParticipated);

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateSeminarsWorkshops", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        #endregion
        #endregion
        #region 4. OTHER ACTIVITIES
        public DataSet GetOtherActivitiesByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOtherActivities", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetOtherActivitiesBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOtherActivitiesByCVOID", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetOtherActivitiesBYCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOtherActivitiesByCVOIDAndYEAR", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetOtherActivitiesByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOtherActivitiesByYearAndOrg", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        public int SaveOtherActivities(Tran_4_otheractivities_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[12];
                sqlParams[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new SqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new SqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new SqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[5] = new SqlParameter("@p_DisplayOfBannerPosterDetails", obj.DisplayOfBannerPosterDetails);
                sqlParams[6] = new SqlParameter("@p_NoOfGrievanceRedressalCampsHeld", obj.NoOfGrievanceRedressalCampsHeld);
                sqlParams[7] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[8] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[9] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);
                sqlParams[10] = new SqlParameter("@p_CreatedBySession", obj.CreatedBySession);
                sqlParams[11] = new SqlParameter("@p_UserOfScocialMedia", obj.UserOfScocialMedia);

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateOtherActivities", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int UpdateOtherActivities(Tran_4_otheractivities_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[9];

                sqlParams[0] = new SqlParameter("@p_Record_ID", obj.Record_ID);
                sqlParams[1] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[2] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[3] = new SqlParameter("@p_DisplayOfBannerPosterDetails", obj.DisplayOfBannerPosterDetails);
                sqlParams[4] = new SqlParameter("@p_NoOfGrievanceRedressalCampsHeld", obj.NoOfGrievanceRedressalCampsHeld);
                sqlParams[5] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[6] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[7] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);
                sqlParams[8] = new SqlParameter("@p_UserOfScocialMedia", obj.UserOfScocialMedia);

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateOtherActivities", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        #endregion
        #region 5. DETAILS OF PHOTOS ENCLOSED
        public DataSet GetDetailsOfPhotosByRecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDetailsOfPhotos", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetDetailsOfPhotosBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDetailsOfPhotosByCVOID", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetDetailsOfPhotosBYCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDetailsOfPhotosByCVOIDAndYEAR", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetDetailsOfPhotosByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadDetailsOfPhotosByYearAndOrg", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        public int SaveDetailsOfPhotos(Tran_5_detailsofphotos_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[13];
                sqlParams[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new SqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new SqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new SqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[5] = new SqlParameter("@p_NameOfActivity", obj.NameOfActivity);
                sqlParams[6] = new SqlParameter("@p_NoOfPhotos", obj.NoOfPhotos);
                sqlParams[7] = new SqlParameter("@p_WhetherPhotosSentAsSoftCopyOrHardCopy", obj.WhetherPhotosSentAsSoftCopyOrHardCopy);
                sqlParams[8] = new SqlParameter("@p_SoftCopy_NoOfCd", obj.SoftCopy_NoOfCd);
                sqlParams[9] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[10] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[11] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);
                sqlParams[12] = new SqlParameter("@p_CreatedBySession", obj.CreatedBySession);

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateDetailsOfPhotos", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int UpdateDetailsOfPhotos(Tran_5_detailsofphotos_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[10];
                sqlParams[0] = new SqlParameter("@p_Record_ID", obj.Record_ID);
                sqlParams[1] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[2] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[3] = new SqlParameter("@p_NameOfActivity", obj.NameOfActivity);
                sqlParams[4] = new SqlParameter("@p_NoOfPhotos", obj.NoOfPhotos);
                sqlParams[5] = new SqlParameter("@p_WhetherPhotosSentAsSoftCopyOrHardCopy", obj.WhetherPhotosSentAsSoftCopyOrHardCopy);
                sqlParams[6] = new SqlParameter("@p_SoftCopy_NoOfCd", obj.SoftCopy_NoOfCd);
                sqlParams[7] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[8] = new SqlParameter("@p_CreatedBy", obj.CreatedBy);
                sqlParams[9] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP);


                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateDetailsOfPhotos", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        #endregion

        public DataSet GetStateList()
        {
            DataSet DS = new DataSet();
            try
            {
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_GetState");
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }

        #region 6. ANY OTHER RELEVANT INFORMATION, IF ANY
        public DataSet GetOtherRelevantInformationByrecordId(int id)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_Record_ID", id >= 1 ? (object)id : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOtherInformation", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetOtherRelevantInformationBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[1];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOtherInformationByCVOID", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetOtherRelevantInformationBYCVOIDandYear(string cvoid, string year)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_CvoId", cvoid);
                Sqlpara[1] = new SqlParameter("@p_SelectedYear", Convert.ToInt32(year));
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOtherInformationByCVOIDAndYEAR", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public DataSet GetOtherRelevantInformationByYearAndOrg(string year, string orgCode)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlParameter[] Sqlpara = new SqlParameter[2];
                Sqlpara[0] = new SqlParameter("@p_Year", !string.IsNullOrEmpty(year) ? (object)year : DBNull.Value);
                Sqlpara[1] = new SqlParameter("@p_Org_Code", !string.IsNullOrEmpty(orgCode) ? (object)orgCode : DBNull.Value);
                DS = SqlHelper.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOtherInformationByYearAndOrg", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return DS;
        }
        public int SaveAnyOtherRelevantInformation(Tran_6_otherinformation_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[10];
                sqlParams[0] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new SqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new SqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new SqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[5] = new SqlParameter("@p_DetailsOfActivity", obj.DetailsOfActivity);
                sqlParams[6] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[7] = new SqlParameter("@p_CreatedBy", obj.CreatedBy); // Replace with actual user
                sqlParams[8] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP); // Replace with actual IP
                sqlParams[9] = new SqlParameter("@p_CreatedBySession", obj.CreatedBySession); // Replace with actual session                

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateOtherInformation", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int UpdateAnyOtherRelevantInformation(Tran_6_otherinformation_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[7];
                sqlParams[0] = new SqlParameter("@p_Record_ID", obj.Record_ID);
                sqlParams[1] = new SqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[2] = new SqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[3] = new SqlParameter("@p_DetailsOfActivity", obj.DetailsOfActivity);
                sqlParams[4] = new SqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[5] = new SqlParameter("@p_CreatedBy", obj.CreatedBy); // Replace with actual user
                sqlParams[6] = new SqlParameter("@p_CreatedByIP", obj.CreatedByIP); // Replace with actual IP              

                // Execute the stored procedure
                EffectedRows = SqlHelper.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_UpdateOtherInformation", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        #endregion

    }
}
