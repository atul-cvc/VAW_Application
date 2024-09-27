using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using VAW_DataAccessLayer;
using VAW_Models;
namespace VAW_BusinessAccessLayer
{
    public class IntegrityPledgeManager
    {
        IntegrityPledgeDAL IntegrityPledgeDAL = new IntegrityPledgeDAL();
        public DataSet GetIntegrityPledgeByRecordId(int id)
        {
            return IntegrityPledgeDAL.GetIntegrityPledgeByRecordId(id);
        }
        public DataSet GetIntegrityPledgeByCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetIntegrityPledgeBYCVOID(cvoid);
        }

        public int SaveIntegrityPledge(Tran_1a_integritypledge_Model obj)
        {
            return IntegrityPledgeDAL.SaveIntegrityPledge(obj);
        }
        public int UpdateIntegrityPledge(Tran_1a_integritypledge_Model obj)
        {
            return IntegrityPledgeDAL.UpdateIntegrityPledge(obj);
        }

        public DataSet GetConductOfCompetitionsByRecordId(int id)
        {
            return IntegrityPledgeDAL.GetConductOfCompetitionsByRecordId(id);
        }
        public DataSet GetConductOfCompetitionsByCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetConductOfCompetitionsBYCVOID(cvoid);
        }
        public int EditConductOfCompetitions(Tran_2a_orgactivities_conductofcompetitions_Model obj)
        {
            return IntegrityPledgeDAL.EditConductOfCompetitions(obj);
        }
        public int SaveConductOfCompetitions(Tran_2a_orgactivities_conductofcompetitions_Model obj)
        {
            return IntegrityPledgeDAL.SaveConductOfCompetitions(obj);
        }
        public DataSet GetActivitiesOtherActivitiesByRecordId(int id)
        {
            return IntegrityPledgeDAL.GetActivitiesOtherActivitiesByRecordId(id);
        }
        public DataSet GetActivitiesOtherActivities(string cvoid)
        {
            return IntegrityPledgeDAL.GetActivitiesOtherActivitiesBYCVOID(cvoid);
        }
        public int SaveActivitiesOtherActivities(Tran_2b_orgactivities_otheractivities_Model obj)
        {
            return IntegrityPledgeDAL.SaveActivitiesOtherActivities(obj);
        }
        public int EditActivitiesOtherActivities(Tran_2b_orgactivities_otheractivities_Model obj)
        {
            return IntegrityPledgeDAL.EditActivitiesOtherActivities(obj);
        }

        #region 3. OUTREACH ACTIVITIES

        #region 3.1. OutreachInvolvingSchoolStudents
        public DataSet GetInvolvingSchoolStudentsByRecordId(int id)
        {
            return IntegrityPledgeDAL.GetInvolvingSchoolStudentsByRecordId(id);
        }
        public DataSet GetInvolvingSchoolStudentsBYCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetInvolvingSchoolStudentsBYCVOID(cvoid);
        }
        public int SaveInvolvingSchoolStudents(Tran_3a_outreach_involvingschoolstudents_Model obj)
        {
            return IntegrityPledgeDAL.SaveInvolvingSchoolStudents(obj);
        }
        public int UpdateInvolvingSchoolStudents(Tran_3a_outreach_involvingschoolstudents_Model obj)
        {
            return IntegrityPledgeDAL.UpdateInvolvingSchoolStudents(obj);
        }
            #endregion

            #region 3.2. OutreachInvolvingCollegeStudents
            public DataSet GetInvolvingCollegeStudentsByRecordId(int id)
        {
            return IntegrityPledgeDAL.GetInvolvingCollegeStudentsByRecordId(id);
        }
        public DataSet GetInvolvingCollegeStudentsBYCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetInvolvingCollegeStudentsBYCVOID(cvoid);
        }
        public int SaveInvolvingCollegeStudents(Tran_3b_outreach_involvingcollegestudents_Model obj)
        {
            return IntegrityPledgeDAL.SaveInvolvingCollegeStudents(obj);
        }
        public int UpdateInvolvingCollegeStudents(Tran_3b_outreach_involvingcollegestudents_Model obj) 
        {
            return IntegrityPledgeDAL.UpdateInvolvingCollegeStudents(obj);
        }
        #endregion

        #region 3.3. OutreachAwarenessGramSabhas
        public DataSet GetOutreachAwarenessByRecordId(int id)
        {
            return IntegrityPledgeDAL.GetOutreachAwarenessByRecordId(id);
        }
        public DataSet GetOutreachAwarenessBYCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetOutreachAwarenessBYCVOID(cvoid);
        }
        public int SaveOutreachAwareness(Tran_3c_outreach_awarenessgramsabhas_Model obj)
        {
            return IntegrityPledgeDAL.SaveOutreachAwareness(obj);
        }
        public int UpdateOutreachAwareness(Tran_3c_outreach_awarenessgramsabhas_Model obj)
        {
            return IntegrityPledgeDAL.UpdateOutreachAwareness(obj);
        }
        #endregion

        #region 3.4. OutreachSeminars
        public DataSet GetSeminarsWorkshopsByRecordId(int id)
        {
            return IntegrityPledgeDAL.GetSeminarsWorkshopsByRecordId(id);
        }
        public DataSet GetSeminarsWorkshopsBYCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetSeminarsWorkshopsBYCVOID(cvoid);
        }
        public int SaveSeminarsWorkshops(Tran_3d_outreach_seminarsworkshops_Model obj)
        {
            return IntegrityPledgeDAL.SaveSeminarsWorkshops(obj);
        }
        public int UpdateSeminarsWorkshops(Tran_3d_outreach_seminarsworkshops_Model obj)
        {
            return IntegrityPledgeDAL.UpdateSeminarsWorkshops(obj);
        }
        #endregion
        #endregion





        #region 4. OTHER ACTIVITIES
        public DataSet GetOtherActivitiesByRecordId(int id)
        {
            return IntegrityPledgeDAL.GetOtherActivitiesByRecordId(id);
        }
        public DataSet GetOtherActivitiesBYCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetOtherActivitiesBYCVOID(cvoid);
        }
        public int SaveOtherActivities(Tran_4_otheractivities_Model obj)
        {
            return IntegrityPledgeDAL.SaveOtherActivities(obj);
        }
        public int UpdateOtherActivities(Tran_4_otheractivities_Model obj)
        {
            return IntegrityPledgeDAL.UpdateOtherActivities(obj);
        }
        #endregion

        #region 5. DETAILS OF PHOTOS ENCLOSED
        public DataSet GetDetailsOfPhotosByRecordId(int id)
        {
            return IntegrityPledgeDAL.GetDetailsOfPhotosByRecordId(id);
        }
        public DataSet GetDetailsOfPhotosBYCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetDetailsOfPhotosBYCVOID(cvoid);
        }
        public int SaveDetailsOfPhotos(Tran_5_detailsofphotos_Model obj)
        {
            return IntegrityPledgeDAL.SaveDetailsOfPhotos(obj);
        }
        public int UpdateDetailsOfPhotos(Tran_5_detailsofphotos_Model obj)
        {
            return IntegrityPledgeDAL.UpdateDetailsOfPhotos(obj);
        }
        #endregion
        public DataSet GetStateList()
        {
            return IntegrityPledgeDAL.GetStateList();
        }

        #region 6. ANY OTHER RELEVANT INFORMATION, IF ANY
        public DataSet GetOtherRelevantInformationByRecordId(int id)
        {
            return IntegrityPledgeDAL.GetOtherRelevantInformationByrecordId(id);
        }
        public DataSet GetOtherRelevantInformationBYCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetOtherRelevantInformationBYCVOID(cvoid);
        }
        public int SaveAnyOtherRelevantInformation(Tran_6_otherinformation_Model obj)
        {
            return IntegrityPledgeDAL.SaveAnyOtherRelevantInformation(obj);
        }

        public int UpdateAnyOtherRelevantInformation(Tran_6_otherinformation_Model obj)
        {
            return IntegrityPledgeDAL.UpdateAnyOtherRelevantInformation(obj);
        }
        #endregion
    }
}
