using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VAW_BusinessAccessLayer;
using VAW_WebApplication.Models;

namespace VAW_WebApplication.Controllers
{
    public class AdminController : Controller
    {
        IntegrityPledgeManager integrityPledgeManager = new IntegrityPledgeManager();
        CapacityBuildingManager capacityBuildingManager = new CapacityBuildingManager();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewVigilanceAwareness()
        {
            int recId = 0;
            ViewVigilanceAwarenessViewModel modelobj = new ViewVigilanceAwarenessViewModel();
            DataTable CapacityTable = capacityBuildingManager.GetCapacityBuildingRecordByRecordId(recId).Tables[0];
            if (CapacityTable.Rows.Count >= 1)
            {
                foreach (DataRow data in CapacityTable.Rows)
                {
                    Tran_a_1b_capacitybulidingprogram_ViewModel vmobj = new Tran_a_1b_capacitybulidingprogram_ViewModel
                    {
                        VAW_Year = data["VAW_Year"].ToString(),
                        FromDate = Convert.ToDateTime(data["FromDate"].ToString()),
                        ToDate = Convert.ToDateTime(data["ToDate"].ToString()),
                        TrainingName = data["TrainingName"].ToString() == "FRESH" ? "Fresh Inductees" : "Refresher Course",
                        EmployeesTrained = Convert.ToInt32(data["EmployeesTrained"].ToString()),
                        BriefDescription = data["BriefDescription"].ToString(),
                        CvoId= data["CvoId"].ToString(),
                        OrganisationName = data["OrgName"].ToString()

                    };
                    modelobj.CapacityBuiliding_VM.Add(vmobj);
                }
            }

            DataTable SysImpTable = capacityBuildingManager.GetSystemImpRecordByRecordId(recId).Tables[0];
            if (SysImpTable.Rows.Count >= 1)
            {
                foreach (DataRow data in SysImpTable.Rows)
                {
                    Tran_a_2b_sysimp_ViewModel vmobjsysimp = new Tran_a_2b_sysimp_ViewModel
                    {
                        VAW_Year = data["VAW_Year"].ToString(),
                        CvoId = data["CvoId"].ToString(),
                        OrganisationName = data["OrgName"].ToString(),
                        FromDate = Convert.ToDateTime(data["FromDate"].ToString()),
                        ToDate = Convert.ToDateTime(data["ToDate"].ToString()),
                        Sys_Imp_Implemented_During_Campaign = data["Sys_Imp_Implemented_During_Campaign"].ToString(),
                        Sys_Imp_Suggested_Last_5_Years_But_Pending = data["Sys_Imp_Suggested_Last_5_Years_But_Pending"].ToString()
                    };
                    modelobj.Sys_Improvement_VM.Add(vmobjsysimp);
                }
            }

            DataTable CircularTable = capacityBuildingManager.GetCircularsRecordByRecordId(recId).Tables[0];
            if (CircularTable.Rows.Count >= 1)
            {
                foreach (DataRow data in CircularTable.Rows)
                {
                    Tran_a_3b_updation_circular_guidelines_manuals_ViewModel vmobjCircular = new Tran_a_3b_updation_circular_guidelines_manuals_ViewModel
                    {
                        VAW_Year = data["VAW_Year"].ToString(),
                        FromDate = Convert.ToDateTime(data["FromDate"].ToString()),
                        ToDate = Convert.ToDateTime(data["ToDate"].ToString()),
                        WhetherUpdatedDuingCampaign = data["WhetherUpdatedDuingCampaign"].ToString(),
                        BriefDetails = data["BriefDetails"].ToString(),
                        CvoId = data["CvoId"].ToString(),
                        OrganisationName = data["OrgName"].ToString()
                    };
                    modelobj.UpdationCirculars_VM.Add(vmobjCircular);
                }
            }


            //Disposal Of Complaint
            DataTable DisposalOfComplaintTable = capacityBuildingManager.GetDisposalOfComplaintByRecordId(recId).Tables[0];

            if (DisposalOfComplaintTable.Rows.Count >= 1)
            {
                foreach (DataRow data in DisposalOfComplaintTable.Rows)
                {
                    Tran_a_4b_disposalofcomplaints_ViewModel vmobjDisposal = new Tran_a_4b_disposalofcomplaints_ViewModel
                    {
                        VAW_Year = data["VAW_Year"].ToString(),
                        NoOf_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608 = int.Parse(data["NoOf_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608"].ToString()),
                        Remarks_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608 = data["Remarks_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608"].ToString(),
                        NoOf_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign = int.Parse(data["NoOf_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign"].ToString()),
                        Remarks_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign = data["Remarks_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign"].ToString(),
                        NoOf_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511 = int.Parse(data["NoOf_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511"].ToString()),
                        Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511 = data["Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511"].ToString(),
                        CvoId = data["CvoId"].ToString(),
                        OrganisationName = data["OrgName"].ToString()
                    };
                    modelobj.DisposalComplaints_VM.Add(vmobjDisposal);
                }
            }


            //Digital Dyanamic
            DataTable DynamicdigitalTable = capacityBuildingManager.GetDynamicDigitalPresenceByRecordId(recId).Tables[0];

            if (DynamicdigitalTable.Rows.Count >= 1)
            {
                foreach (DataRow data in DynamicdigitalTable.Rows)
                {
                    Tran_a_5b_dynamicdigitalpresence_ViewModel vmobjDynamicdigital = new Tran_a_5b_dynamicdigitalpresence_ViewModel
                    {

                        VAW_Year = data["VAW_Year"].ToString(),
                        WhetherRegularMaintenanceOfWebsiteUpdationDone = data["WhetherRegularMaintenanceOfWebsiteUpdationDone"].ToString(),
                        SystemIntroducedForUpdationAndReview = data["SystemIntroducedForUpdationAndReview"].ToString(),
                        WhetherAdditionalAreas_Activities_ServicesBroughtOnline = data["WhetherAdditionalAreas_Activities_ServicesBroughtOnline"].ToString(),
                        DetailsOfAdditionalActivities = data["DetailsOfAdditionalActivities"].ToString(),
                        CvoId = data["CvoId"].ToString(),
                        OrganisationName = data["OrgName"].ToString()
                    };
                    modelobj.DynamicDigitalPresence_VM.Add(vmobjDynamicdigital);
                }
            }

            return View(modelobj);
        }

        public ActionResult ViewIntegrityPledge()
        {
            int recId = 0;
            ViewIntegrityPledgeViewModel viewModel = new ViewIntegrityPledgeViewModel();
            DataTable integrityTable = integrityPledgeManager.GetIntegrityPledgeByRecordId(recId).Tables[0];
            DataTable conductTable = integrityPledgeManager.GetConductOfCompetitionsByRecordId(recId).Tables[0];
            DataTable activitiesOthActivitiesTable = integrityPledgeManager.GetActivitiesOtherActivitiesByRecordId(recId).Tables[0];
            DataTable outreachSchoolStudentsTable = integrityPledgeManager.GetInvolvingSchoolStudentsByRecordId(recId).Tables[0];
            DataTable outreachCollegeStudentsTable = integrityPledgeManager.GetInvolvingCollegeStudentsByRecordId(recId).Tables[0];
            DataTable outreachAwarenessTable = integrityPledgeManager.GetOutreachAwarenessByRecordId(recId).Tables[0];
            DataTable seminarsWorkshopsTable = integrityPledgeManager.GetSeminarsWorkshopsByRecordId(recId).Tables[0];
            DataTable otherActivitiesTable = integrityPledgeManager.GetOtherActivitiesByRecordId(recId).Tables[0];
            DataTable detailsOfPhotosTable = integrityPledgeManager.GetDetailsOfPhotosByRecordId(recId).Tables[0];
            DataTable OtherRelatedInfo = integrityPledgeManager.GetOtherRelevantInformationByRecordId(recId).Tables[0];

            if (integrityTable.Rows.Count >= 1)
            {
                foreach (DataRow dr in integrityTable.Rows)
                {
                    Tran_1a_integritypledge_ViewModel vmobj = new Tran_1a_integritypledge_ViewModel
                    {
                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        TotalNoOfEmployees_UndertakenPledge = Convert.ToInt32(dr["TotalNoOfEmployees_UndertakenPledge"].ToString()),
                        TotalNoOfCustomers_UndertakenPledge = Convert.ToInt32(dr["TotalNoOfCustomers_UndertakenPledge"].ToString()),
                        TotalNoOfCitizen_UndertakenPledge = Convert.ToInt32(dr["TotalNoOfCitizen_UndertakenPledge"].ToString()),
                        OrganisationName = dr["OrgName"].ToString(),
                    };
                    viewModel.IntegrityPledges.Add(vmobj);
                }
            }

            if (conductTable.Rows.Count >= 1)
            {
                foreach (DataRow dr in conductTable.Rows)
                {
                    Tran_2a_orgactivities_conductofcompetitions_ViewModel vmobj = new Tran_2a_orgactivities_conductofcompetitions_ViewModel
                    {
                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        NameOfState = dr["NameOfState"].ToString(),
                        City = dr["City"].ToString(),
                        SpecificProgram = dr["SpecificProgram"].ToString(),
                        NoOfParticipant = Convert.ToInt32(dr["NoOfParticipant"].ToString()),
                        Remarks = dr["Remarks"].ToString(),
                        OrganisationName = dr["OrgName"].ToString()
                    };
                    viewModel.OrgActivities_ConductOfCompetitions.Add(vmobj);
                }
            }

            if (activitiesOthActivitiesTable.Rows.Count >= 1)
            {
                foreach (DataRow dr in activitiesOthActivitiesTable.Rows)
                {
                    Tran_2b_orgactivities_otheractivities_ViewModel vmobj = new Tran_2b_orgactivities_otheractivities_ViewModel
                    {

                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        DistributionOfPamphletsAndBanners_Details = dr["DistributionOfPamphletsAndBanners_Details"].ToString(),
                        ConductOfWorkshopAndSensitizationProgram_Details = dr["ConductOfWorkshopAndSensitizationProgram_Details"].ToString(),
                        IssueOfJornalAndNwesletter_Details = dr["IssueOfJornalAndNwesletter_Details"].ToString(),
                        AnyOtherActivities_Details = dr["AnyOtherActivities_Details"].ToString(),
                        OrganisationName = dr["OrgName"].ToString()
                    };
                    viewModel.OrgActivities_OtherActivities.Add(vmobj);
                }
            }

            if (outreachSchoolStudentsTable.Rows.Count >= 1)
            {
                foreach (DataRow dr in outreachSchoolStudentsTable.Rows)
                {
                    Tran_3a_outreach_involvingschoolstudents_ViewModel vmobj = new Tran_3a_outreach_involvingschoolstudents_ViewModel
                    {

                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        StateName = dr["StateName"].ToString(),
                        City_Town_Village_Name = dr["City_Town_Village_Name"].ToString(),
                        SchoolName = dr["SchoolName"].ToString(),
                        ActivityDetails = dr["ActivityDetails"].ToString(),
                        NoOfStudentsInvolved = Convert.ToInt32(dr["NoOfStudentsInvolved"].ToString()),
                        OrganisationName = dr["OrgName"].ToString()

                    };
                    viewModel.OutActivities_InvolvingStudentsInSchool.Add(vmobj);
                }
            }

            if (outreachCollegeStudentsTable.Rows.Count >= 1)
            {
                foreach (DataRow dr in outreachCollegeStudentsTable.Rows)
                {
                    Tran_3b_outreach_involvingcollegestudents_ViewModel vmobj = new Tran_3b_outreach_involvingcollegestudents_ViewModel
                    {

                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        StateName = dr["StateName"].ToString(),
                        City_Town_Village_Name = dr["City_Town_Village_Name"].ToString(),
                        SchoolName = dr["SchoolName"].ToString(),
                        ActivityDetails = dr["ActivityDetails"].ToString(),
                        NoOfStudentsInvolved = Convert.ToInt32(dr["NoOfStudentsInvolved"].ToString()),
                        OrganisationName = dr["OrgName"].ToString()
                    };
                    viewModel.OutActivities_InvolvingStudentsInColleges.Add(vmobj);
                }
            }

            if (outreachAwarenessTable.Rows.Count >= 1)
            {
                foreach (DataRow dr in outreachAwarenessTable.Rows)
                {
                    Tran_3c_outreach_awarenessgramsabhas_ViewModel vmobj = new Tran_3c_outreach_awarenessgramsabhas_ViewModel
                    {
                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        StateName = dr["StateName"].ToString(),
                        City_Town_Village_Name = dr["City_Town_Village_Name"].ToString(),
                        NameOfGramPanchayat = dr["NameOfGramPanchayat"].ToString(),
                        ActivityDetails = dr["ActivityDetails"].ToString(),
                        NoOfPublicOrCitizenParticipated = Convert.ToInt32(dr["NoOfPublicOrCitizenParticipated"].ToString()),
                        OrganisationName = dr["OrgName"].ToString()
                    };
                    viewModel.OutActivities_AwarenesGramSabha.Add(vmobj);
                }
            }

            if (seminarsWorkshopsTable.Rows.Count >= 1)
            {
                foreach (DataRow dr in seminarsWorkshopsTable.Rows)
                {
                    Tran_3d_outreach_seminarsworkshops_ViewModel vmobj = new Tran_3d_outreach_seminarsworkshops_ViewModel
                    {
                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        StateName = dr["StateName"].ToString(),
                        City_Town_Village_Name = dr["City_Town_Village_Name"].ToString(),
                        NoOfSeminarsWorkshops = Convert.ToInt32(dr["NoOfSeminarsWorkshops"].ToString()),
                        ActivityDetails = dr["ActivityDetails"].ToString(),
                        NoOfPublicOrCitizenParticipated = Convert.ToInt32(dr["NoOfPublicOrCitizenParticipated"].ToString()),
                        OrganisationName = dr["OrgName"].ToString()
                    };
                    viewModel.OutActivities_SeminarsWorkshops.Add(vmobj);
                }
            }

            if (otherActivitiesTable.Rows.Count >= 1)
            {
                foreach (DataRow dr in otherActivitiesTable.Rows)
                {
                    Tran_4_otheractivities_ViewModel vmobj = new Tran_4_otheractivities_ViewModel
                    {
                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        DisplayOfBannerPosterDetails = dr["DisplayOfBannerPosterDetails"].ToString(),
                        NoOfGrievanceRedressalCampsHeld = Convert.ToInt32(dr["NoOfGrievanceRedressalCampsHeld"].ToString()),
                        UserOfScocialMedia = dr["UserOfScocialMedia"].ToString(),
                        OrganisationName = dr["OrgName"].ToString()
                    };
                    viewModel.OtherActivities.Add(vmobj);
                }
            }

            if (detailsOfPhotosTable.Rows.Count >= 1)
            {
                foreach (DataRow dr in detailsOfPhotosTable.Rows)
                {
                    Tran_5_detailsofphotos_ViewModel vmobj = new Tran_5_detailsofphotos_ViewModel
                    {
                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        NameOfActivity = dr["NameOfActivity"].ToString(),
                        NoOfPhotos = Convert.ToInt32(dr["NoOfPhotos"].ToString()),
                        WhetherPhotosSentAsSoftCopyOrHardCopy = dr["WhetherPhotosSentAsSoftCopyOrHardCopy"].ToString(),
                        SoftCopy_NoOfCd = Convert.ToInt32(dr["SoftCopy_NoOfCd"].ToString()),
                        OrganisationName = dr["OrgName"].ToString()
                    };
                    viewModel.DetailsOfPhotos.Add(vmobj);
                }
            }

            if (OtherRelatedInfo.Rows.Count >= 1)
            {
                foreach (DataRow dr in OtherRelatedInfo.Rows)
                {
                    Tran_6_otherinformation_ViewModel vmobj = new Tran_6_otherinformation_ViewModel
                    {
                        VAW_Year = dr["VAW_Year"].ToString(),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        DetailsOfActivity = dr["DetailsOfActivity"].ToString(),
                        OrganisationName = dr["OrgName"].ToString()
                    };
                    viewModel.OtherInformations.Add(vmobj);
                }
            }

            return View(viewModel);
        }
    }
}