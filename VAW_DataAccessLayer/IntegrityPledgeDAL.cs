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
                Sqlpara[9] = new MySqlParameter("@p_CreatedBy", obj.CreatedBy); // Replace with actual user
                Sqlpara[10] = new MySqlParameter("@p_CreatedByIP", obj.CreatedByIP); // Replace with actual IP
                Sqlpara[11] = new MySqlParameter("@p_CreatedBySession", obj.CreatedBySession); // Replace with actual session
                Sqlpara[12] = new MySqlParameter("@p_UpdatedOn", DateTime.Now);
                Sqlpara[13] = new MySqlParameter("@p_UpdatedBy", obj.UpdatedBy);
                Sqlpara[14] = new MySqlParameter("@p_UpdatedByIp", obj.UpdatedByIp);

                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateIntegrityPledge", Sqlpara);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        public DataSet GetConductOfCompetitionsBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_CvoId", cvoid);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadConductOfCompetitionsByCVOID", Sqlpara);
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
                MySqlParameter[] sqlParams = new MySqlParameter[14];
                sqlParams[0] = new MySqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new MySqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new MySqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new MySqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new MySqlParameter("@p_DateOfActivity", Convert.ToDateTime(obj.DateOfActivity));
                sqlParams[5] = new MySqlParameter("@p_NameOfState", obj.NameOfState);
                sqlParams[6] = new MySqlParameter("@p_City", obj.City);
                sqlParams[7] = new MySqlParameter("@p_SpecificProgram", obj.SpecificProgram);
                sqlParams[8] = new MySqlParameter("@p_NoOfParticipant", Convert.ToInt32(obj.NoOfParticipant));
                sqlParams[9] = new MySqlParameter("@p_Remarks", obj.Remarks);
                sqlParams[10] = new MySqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[11] = new MySqlParameter("@p_CreatedBy", obj.CreatedBy); // Replace with actual user
                sqlParams[12] = new MySqlParameter("@p_CreatedByIP", obj.CreatedByIP); // Replace with actual IP
                sqlParams[13] = new MySqlParameter("@p_CreatedBySession", obj.CreatedBySession); // Replace with actual session


                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateOrgActivitiesCompetition", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        public DataSet GetActivitiesOtherActivitiesBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_CvoId", cvoid);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadActivitiesOtherActivitiesCVOID", Sqlpara);
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
                MySqlParameter[] sqlParams = new MySqlParameter[15];
                sqlParams[0] = new MySqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new MySqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new MySqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new MySqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new MySqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[5] = new MySqlParameter("@p_DistributionOfPamphletsAndBanners_Details", obj.DistributionOfPamphletsAndBanners_Details);
                sqlParams[6] = new MySqlParameter("@p_ConductOfWorkshopAndSensitizationProgram_Details", obj.ConductOfWorkshopAndSensitizationProgram_Details);
                sqlParams[7] = new MySqlParameter("@p_IssueOfJornalAndNwesletter_Details", obj.IssueOfJornalAndNwesletter_Details);
                sqlParams[8] = new MySqlParameter("@p_AnyOtherActivities_Details", obj.AnyOtherActivities_Details);
                sqlParams[9] = new MySqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[10] = new MySqlParameter("@p_CreatedBy", obj.CreatedBy); // Replace with actual user
                sqlParams[11] = new MySqlParameter("@p_CreatedByIP", obj.CreatedByIP); // Replace with actual IP
                sqlParams[12] = new MySqlParameter("@p_CreatedBySession", obj.CreatedBySession); // Replace with actual session

                // Execute the stored procedure
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateOrgActivitiesOtherActivities", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        public DataSet GetInvolvingSchoolStudentsBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_CvoId", cvoid);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachInvolvingSchoolStudentsByCVOID", Sqlpara);
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
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_CvoId", cvoid);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachInvolvingCollegeStudentsByCVOID", Sqlpara);
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
                MySqlParameter[] sqlParams = new MySqlParameter[14];
                sqlParams[0] = new MySqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new MySqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new MySqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new MySqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new MySqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[5] = new MySqlParameter("@p_StateName", obj.StateName);
                sqlParams[6] = new MySqlParameter("@p_City_Town_Village_Name", obj.City_Town_Village_Name);
                sqlParams[7] = new MySqlParameter("@p_SchoolName", obj.SchoolName);
                sqlParams[8] = new MySqlParameter("@p_ActivityDetails", obj.ActivityDetails);
                sqlParams[9] = new MySqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[10] = new MySqlParameter("@p_CreatedBy", obj.CreatedBy); // Replace with actual user
                sqlParams[11] = new MySqlParameter("@p_CreatedByIP", obj.CreatedByIP); // Replace with actual IP
                sqlParams[12] = new MySqlParameter("@p_CreatedBySession", obj.CreatedBySession); // Replace with actual session
                sqlParams[13] = new MySqlParameter("@p_NoOfStudentsInvolved", obj.NoOfStudentsInvolved);

                // Execute the stored procedure
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateOutreachInvolvingSchoolStudents", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
        public int SaveInvolvingCollegeStudents(Tran_3b_outreach_involvingcollegestudents_Model obj)
        {
            int EffectedRows = 0;
            try
            {
                MySqlParameter[] sqlParams = new MySqlParameter[14];
                sqlParams[0] = new MySqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new MySqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new MySqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new MySqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new MySqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[5] = new MySqlParameter("@p_StateName", obj.StateName);
                sqlParams[6] = new MySqlParameter("@p_City_Town_Village_Name", obj.City_Town_Village_Name);
                sqlParams[7] = new MySqlParameter("@p_SchoolName", obj.SchoolName);
                sqlParams[8] = new MySqlParameter("@p_ActivityDetails", obj.ActivityDetails);
                sqlParams[9] = new MySqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[10] = new MySqlParameter("@p_CreatedBy", obj.CreatedBy); // Replace with actual user
                sqlParams[11] = new MySqlParameter("@p_CreatedByIP", obj.CreatedByIP); // Replace with actual IP
                sqlParams[12] = new MySqlParameter("@p_CreatedBySession", obj.CreatedBySession); // Replace with actual session
                sqlParams[13] = new MySqlParameter("@p_NoOfStudentsInvolved", obj.NoOfStudentsInvolved);

                // Execute the stored procedure
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateOutreachInvolvingCollegeStudents", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        public DataSet GetOutreachAwarenessBYCVOID(string cvoid)
        {
            DataSet DS = new DataSet();
            try
            {
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_CvoId", cvoid);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOutreachAwarenessGramSabhasByCVOID", Sqlpara);
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
                MySqlParameter[] sqlParams = new MySqlParameter[14];
                sqlParams[0] = new MySqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new MySqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new MySqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new MySqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new MySqlParameter("@p_DateOfActivity", obj.DateOfActivity);
                sqlParams[5] = new MySqlParameter("@p_StateName", obj.StateName);
                sqlParams[6] = new MySqlParameter("@p_City_Town_Village_Name", obj.City_Town_Village_Name);
                sqlParams[7] = new MySqlParameter("@p_NameOfGramPanchayat", obj.NameOfGramPanchayat);
                sqlParams[8] = new MySqlParameter("@p_ActivityDetails", obj.ActivityDetails);
                sqlParams[9] = new MySqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[10] = new MySqlParameter("@p_CreatedBy", obj.CreatedBy); // Replace with actual user
                sqlParams[11] = new MySqlParameter("@p_CreatedByIP", obj.CreatedByIP); // Replace with actual IP
                sqlParams[12] = new MySqlParameter("@p_CreatedBySession", obj.CreatedBySession); // Replace with actual session
                sqlParams[13] = new MySqlParameter("@p_NoOfPublicOrCitizenParticipated", obj.NoOfPublicOrCitizenParticipated);

                // Execute the stored procedure
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateOutreachAwarenessGramSabhas", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }

        public DataSet GetStateList()
        {
            DataSet DS = new DataSet();
            try
            {
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_GetState");
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
                MySqlParameter[] Sqlpara = new MySqlParameter[1];
                Sqlpara[0] = new MySqlParameter("@p_CvoId", cvoid);
                DS = MySqlHelperCls.ExecuteDataset(SqlConnection, CommandType.StoredProcedure, "sp_ReadOtherInformationByCVOID", Sqlpara);
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
                MySqlParameter[] sqlParams = new MySqlParameter[10];
                sqlParams[0] = new MySqlParameter("@p_VAW_Year", Convert.ToInt32(obj.VAW_Year));
                sqlParams[1] = new MySqlParameter("@p_UniqueTransactionId", obj.UniqueTransactionId);
                sqlParams[2] = new MySqlParameter("@p_CvoOrgCode", obj.CvoOrgCode);
                sqlParams[3] = new MySqlParameter("@p_CvoId", obj.CvoId);
                sqlParams[4] = new MySqlParameter("@p_DateOfActivity", obj.DateOfActivity);              
                sqlParams[5] = new MySqlParameter("@p_DetailsOfActivity", obj.DetailsOfActivity);
                sqlParams[6] = new MySqlParameter("@p_CreatedOn", obj.CreatedOn);
                sqlParams[7] = new MySqlParameter("@p_CreatedBy", obj.CreatedBy); // Replace with actual user
                sqlParams[8] = new MySqlParameter("@p_CreatedByIP", obj.CreatedByIP); // Replace with actual IP
                sqlParams[9] = new MySqlParameter("@p_CreatedBySession", obj.CreatedBySession); // Replace with actual session                

                // Execute the stored procedure
                EffectedRows = MySqlHelperCls.ExecuteNonQuery(SqlConnection, CommandType.StoredProcedure, "sp_CreateOtherInformation", sqlParams);
            }
            catch (Exception ex)
            {
                errolog.WriteErrorLog(ex);
            }
            return EffectedRows;
        }
     }
}
