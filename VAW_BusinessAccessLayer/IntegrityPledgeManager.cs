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
        public DataSet GetIntegrityPledgeByCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetIntegrityPledgeBYCVOID(cvoid);
        }

        public int SaveIntegrityPledge(Tran_1a_integritypledge_Model obj)
        {
            return IntegrityPledgeDAL.SaveIntegrityPledge(obj);
        }

        public DataSet GetConductOfCompetitionsByCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetConductOfCompetitionsBYCVOID(cvoid);
        }
        public int SaveConductOfCompetitions(Tran_2a_orgactivities_conductofcompetitions_Model obj)
        {
            return IntegrityPledgeDAL.SaveConductOfCompetitions(obj);
        }
        public DataSet GetActivitiesOtherActivities(string cvoid)
        {
            return IntegrityPledgeDAL.GetActivitiesOtherActivitiesBYCVOID(cvoid);
        }
        public int SaveActivitiesOtherActivities(Tran_2b_orgactivities_otheractivities_Model obj)
        {
            return IntegrityPledgeDAL.SaveActivitiesOtherActivities(obj);
        }
        public DataSet GetInvolvingSchoolStudentsBYCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetInvolvingSchoolStudentsBYCVOID(cvoid);
        }
        public int SaveInvolvingSchoolStudents(Tran_3a_outreach_involvingschoolstudents_Model obj)
        {
            return IntegrityPledgeDAL.SaveInvolvingSchoolStudents(obj);
        }
        public DataSet GetInvolvingCollegeStudentsBYCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetInvolvingCollegeStudentsBYCVOID(cvoid);
        }
        public int SaveInvolvingCollegeStudents(Tran_3b_outreach_involvingcollegestudents_Model obj)
        {
            return IntegrityPledgeDAL.SaveInvolvingCollegeStudents(obj);
        }
        public DataSet GetOutreachAwarenessBYCVOID(string cvoid)
        {
            return IntegrityPledgeDAL.GetOutreachAwarenessBYCVOID(cvoid);
        }
        public int SaveOutreachAwareness(Tran_3c_outreach_awarenessgramsabhas_Model obj)
        {
            return IntegrityPledgeDAL.SaveOutreachAwareness(obj);
        }
        public DataSet GetStateList()
        {
            return IntegrityPledgeDAL.GetStateList();
        }

    }
}
