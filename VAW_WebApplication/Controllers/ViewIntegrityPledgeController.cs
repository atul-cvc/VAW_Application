﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using VAW_BusinessAccessLayer;
using VAW_Models;
using VAW_WebApplication.Models;
using VAW_WebApplication.Util;

namespace VAW_WebApplication.Controllers
{
    public class ViewIntegrityPledgeController : Controller
    {
        IntegrityPledgeManager integrityPledgeManager = new IntegrityPledgeManager();
        YearsBAL yearsBAL = new YearsBAL();
        PDFUtil PdfUtil = new PDFUtil();
        string IPAddress = null;

        // GET: ViewIntegrityPledge
        public ActionResult Index(string selected_year)
        {
            selected_year = !string.IsNullOrEmpty(selected_year) ? selected_year : DateTime.Now.Year.ToString();

            ViewIntegrityPledgeViewModel viewModel = new ViewIntegrityPledgeViewModel();
            viewModel.CurrentYear = !string.IsNullOrEmpty(selected_year) ? Convert.ToInt32(selected_year) : DateTime.Now.Year;
            
            DataTable integrityTable = integrityPledgeManager.GetIntegrityPledgeByCVOIDandYear("CVO_SBI", selected_year).Tables[0]; //GetIntegrityPledge
            DataTable conductTable = integrityPledgeManager.GetConductOfCompetitionsByCVOIDandYear("CVO_SBI", selected_year).Tables[0];
            DataTable activitiesOthActivitiesTable = integrityPledgeManager.GetActivitiesOtherActivitiesandYear("CVO_SBI", selected_year).Tables[0];
            DataTable outreachSchoolStudentsTable = integrityPledgeManager.GetInvolvingSchoolStudentsBYCVOIDandYear("CVO_SBI", selected_year).Tables[0];
            DataTable outreachCollegeStudentsTable = integrityPledgeManager.GetInvolvingCollegeStudentsBYCVOIDandYear("CVO_SBI", selected_year).Tables[0];
            DataTable outreachAwarenessTable = integrityPledgeManager.GetOutreachAwarenessBYCVOIDandYear("CVO_SBI", selected_year).Tables[0];
            DataTable seminarsWorkshopsTable = integrityPledgeManager.GetSeminarsWorkshopsBYCVOIDandYear("CVO_SBI", selected_year).Tables[0];
            DataTable otherActivitiesTable = integrityPledgeManager.GetOtherActivitiesBYCVOIDandYear("CVO_SBI", selected_year).Tables[0];
            DataTable detailsOfPhotosTable = integrityPledgeManager.GetDetailsOfPhotosBYCVOIDandYear("CVO_SBI", selected_year).Tables[0];
            DataTable yearsTable = yearsBAL.GetAllYearsList().Tables[0];



            var yearList = new List<SelectListItem>();
            if (yearsTable.Rows.Count >= 1)
            {                
                foreach (DataRow dr in yearsTable.Rows)
                {
                    yearList.Add(new SelectListItem
                    {
                        Value = dr["Year"].ToString(),
                        Text = dr["Year"].ToString()
                    });
                }
                viewModel.YearsList = yearList;
            }
            else
            {
                Years year = new Years
                {
                    ID = 1,
                    Year = DateTime.Now.Year
                };
                yearList.Add(new SelectListItem { Value = "2024", Text = "2024" });
                viewModel.YearsList = yearList;
            }
            //viewModel.CurrentYear = DateTime.Now.Year;

            DataTable OtherRelatedInfo = integrityPledgeManager.GetOtherRelevantInformationBYCVOIDandYear("CVO_SBI", selected_year).Tables[0];

            List<Tran_1a_integritypledge_ViewModel> pledgeList = new List<Tran_1a_integritypledge_ViewModel>();

            if (integrityTable.Rows.Count >= 1)
            {
                foreach (DataRow dr in integrityTable.Rows)
                {
                    Tran_1a_integritypledge_ViewModel vmobj = new Tran_1a_integritypledge_ViewModel
                    {
                        ID = Convert.ToInt32(dr["Record_Id"].ToString()),
                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        TotalNoOfEmployees_UndertakenPledge = Convert.ToInt32(dr["TotalNoOfEmployees_UndertakenPledge"].ToString()),
                        TotalNoOfCustomers_UndertakenPledge = Convert.ToInt32(dr["TotalNoOfCustomers_UndertakenPledge"].ToString()),
                        TotalNoOfCitizen_UndertakenPledge = Convert.ToInt32(dr["TotalNoOfCitizen_UndertakenPledge"].ToString())
                    };
                    pledgeList.Add(vmobj);
                }
            }
            viewModel.IntegrityPledges = pledgeList;

            if (conductTable.Rows.Count >= 1)
            {
                foreach (DataRow dr in conductTable.Rows)
                {
                    Tran_2a_orgactivities_conductofcompetitions_ViewModel vmobj = new Tran_2a_orgactivities_conductofcompetitions_ViewModel
                    {
                        ID = Convert.ToInt32(dr["Record_Id"].ToString()),
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
                        ID = Convert.ToInt32(dr["Record_Id"].ToString()),
                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        DistributionOfPamphletsAndBanners_Details = dr["DistributionOfPamphletsAndBanners_Details"].ToString(),
                        ConductOfWorkshopAndSensitizationProgram_Details = dr["ConductOfWorkshopAndSensitizationProgram_Details"].ToString(),
                        IssueOfJornalAndNwesletter_Details = dr["IssueOfJornalAndNwesletter_Details"].ToString(),
                        AnyOtherActivities_Details = dr["AnyOtherActivities_Details"].ToString(),
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
                        ID = Convert.ToInt32(dr["Record_Id"].ToString()),
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
                        ID = Convert.ToInt32(dr["Record_Id"].ToString()),
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
                        ID = Convert.ToInt32(dr["Record_Id"].ToString()),
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
                        ID = Convert.ToInt32(dr["Record_Id"].ToString()),
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
                        ID = Convert.ToInt32(dr["Record_Id"].ToString()),
                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        DisplayOfBannerPosterDetails = dr["DisplayOfBannerPosterDetails"].ToString(),
                        NoOfGrievanceRedressalCampsHeld = Convert.ToInt32(dr["NoOfGrievanceRedressalCampsHeld"].ToString()),
                        UserOfScocialMedia = dr["UserOfScocialMedia"].ToString()
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
                        ID = Convert.ToInt32(dr["Record_Id"].ToString()),
                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        NameOfActivity = dr["NameOfActivity"].ToString(),
                        NoOfPhotos = Convert.ToInt32(dr["NoOfPhotos"].ToString()),
                        WhetherPhotosSentAsSoftCopyOrHardCopy = dr["WhetherPhotosSentAsSoftCopyOrHardCopy"].ToString(),
                        SoftCopy_NoOfCd = Convert.ToInt32(dr["SoftCopy_NoOfCd"].ToString())
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
                        ID = Convert.ToInt32(dr["Record_Id"].ToString()),
                        VAW_Year = dr["VAW_Year"].ToString(),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        DetailsOfActivity = dr["DetailsOfActivity"].ToString()

                    };
                    viewModel.OtherInformations.Add(vmobj);
                }
            }



            return View(viewModel);
        }

        #region 1. Integrity Pledge

        [HttpGet]
        public ActionResult CreateIntegrityPledge()
        {
            Tran_1a_integritypledge_ViewModel vmdata = new Tran_1a_integritypledge_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year;
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.DateOfActivity = DateTime.Now;
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateIntegrityPledge(Tran_1a_integritypledge_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_1a_integritypledge_Model obj = new Tran_1a_integritypledge_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CvoId = VmData.CvoId;
                    obj.CvoOrgCode = VmData.CvoOrgCode;
                    obj.TotalNoOfEmployees_UndertakenPledge = VmData.TotalNoOfEmployees_UndertakenPledge;
                    obj.TotalNoOfCustomers_UndertakenPledge = VmData.TotalNoOfCustomers_UndertakenPledge;
                    obj.TotalNoOfCitizen_UndertakenPledge = VmData.TotalNoOfCitizen_UndertakenPledge;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.CreatedBySession = Session.SessionID;
                    obj.UpdatedBy = Session.SessionID;
                    int result = integrityPledgeManager.SaveIntegrityPledge(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult EditIntegrityPledge(int ID)
        {
            Tran_1a_integritypledge_ViewModel vmdata = new Tran_1a_integritypledge_ViewModel();
            DataTable dt = integrityPledgeManager.GetIntegrityPledgeByRecordId(ID).Tables[0];
            vmdata.ID = ID;
            vmdata.VAW_Year = Convert.ToInt32(dt.Rows[0]["VAW_Year"].ToString());
            vmdata.CvoId = dt.Rows[0]["CvoId"].ToString();
            vmdata.CvoOrgCode = dt.Rows[0]["CvoOrgCode"].ToString();
            vmdata.DateOfActivity = Convert.ToDateTime(dt.Rows[0]["DateOfActivity"].ToString());
            vmdata.TotalNoOfEmployees_UndertakenPledge = Convert.ToInt32(dt.Rows[0]["TotalNoOfEmployees_UndertakenPledge"].ToString());
            vmdata.TotalNoOfCustomers_UndertakenPledge = Convert.ToInt32(dt.Rows[0]["TotalNoOfCustomers_UndertakenPledge"].ToString());
            vmdata.TotalNoOfCitizen_UndertakenPledge = Convert.ToInt32(dt.Rows[0]["TotalNoOfCitizen_UndertakenPledge"].ToString());
            vmdata.OrganisationName = dt.Rows[0]["OrgName"].ToString();
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult EditIntegrityPledge(Tran_1a_integritypledge_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_1a_integritypledge_Model obj = new Tran_1a_integritypledge_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.Record_ID = VmData.ID;
                    obj.TotalNoOfEmployees_UndertakenPledge = VmData.TotalNoOfEmployees_UndertakenPledge;
                    obj.TotalNoOfCustomers_UndertakenPledge = VmData.TotalNoOfCustomers_UndertakenPledge;
                    obj.TotalNoOfCitizen_UndertakenPledge = VmData.TotalNoOfCitizen_UndertakenPledge;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.UpdatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.UpdatedBy = VmData.CvoId;
                    obj.UpdatedByIp = ipadd;

                    int result = integrityPledgeManager.UpdateIntegrityPledge(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View("Index");
        }

        #endregion


        #region 2. ACTIVITIES / EVENTS ORGANISED WITHIN THE ORGANISATION

        [HttpGet]
        public ActionResult CreateConductOfCompetitions()
        {
            Tran_2a_orgactivities_conductofcompetitions_ViewModel vmdata = new Tran_2a_orgactivities_conductofcompetitions_ViewModel();
            vmdata.VAW_Year = Convert.ToInt32(DateTime.Now.Year.ToString());
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.DateOfActivity = DateTime.Now;
            vmdata.SpecificProgramList = new List<SelectListItem> {
                new SelectListItem { Value = "Debate", Text = "Debate" },
                new SelectListItem { Value = "Elocution", Text = "Elocution" },
                new SelectListItem { Value = "Panel Discussion", Text = "Panel Discussion" },
                new SelectListItem { Value = "Other", Text = "Other" }
            };
            vmdata.NameOfStateList = new List<SelectListItem>();
            DataTable StateTable = integrityPledgeManager.GetStateList().Tables[0];
            if (StateTable.Rows.Count > 0)
            {
                var stateItemList = new List<SelectListItem>();
                foreach (DataRow dr in StateTable.Rows)
                {
                    stateItemList.Add(new SelectListItem
                    {
                        Value = dr["States"].ToString(),
                        Text = dr["States"].ToString()
                    });
                }
                vmdata.NameOfStateList = stateItemList;
            }
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateConductOfCompetitions(Tran_2a_orgactivities_conductofcompetitions_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_2a_orgactivities_conductofcompetitions_Model obj = new Tran_2a_orgactivities_conductofcompetitions_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CvoId = VmData.CvoId;
                    obj.CvoOrgCode = VmData.CvoOrgCode;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.CreatedBySession = Session.SessionID;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.NameOfState = VmData.NameOfState;
                    obj.City = VmData.City;
                    obj.SpecificProgram = VmData.SpecificProgram;
                    obj.NoOfParticipant = VmData.NoOfParticipant;
                    obj.Remarks = VmData.Remarks;
                    int result = integrityPledgeManager.SaveConductOfCompetitions(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditConductOfCompetitions(int ID)
        {
            DataTable dt = integrityPledgeManager.GetConductOfCompetitionsByRecordId(ID).Tables[0];
            Tran_2a_orgactivities_conductofcompetitions_ViewModel vmdata = new Tran_2a_orgactivities_conductofcompetitions_ViewModel();
            vmdata.VAW_Year = Convert.ToInt32(DateTime.Now.Year.ToString());
            vmdata.ID = Convert.ToInt32(dt.Rows[0]["Record_ID"].ToString());
            vmdata.CvoId = dt.Rows[0]["CvoId"].ToString();
            vmdata.CvoOrgCode = dt.Rows[0]["CvoOrgCode"].ToString();
            vmdata.DateOfActivity = Convert.ToDateTime(dt.Rows[0]["DateOfActivity"].ToString());
            vmdata.SpecificProgramList = new List<SelectListItem> {
                new SelectListItem { Value = "Debate", Text = "Debate" },
                new SelectListItem { Value = "Elocution", Text = "Elocution" },
                new SelectListItem { Value = "Panel Discussion", Text = "Panel Discussion" },
                new SelectListItem { Value = "Other", Text = "Other" }
            };
            vmdata.NameOfStateList = new List<SelectListItem>();
            DataTable StateTable = integrityPledgeManager.GetStateList().Tables[0];
            if (StateTable.Rows.Count > 0)
            {
                var stateItemList = new List<SelectListItem>();
                foreach (DataRow dr in StateTable.Rows)
                {
                    stateItemList.Add(new SelectListItem
                    {
                        Value = dr["States"].ToString(),
                        Text = dr["States"].ToString()
                    });
                }
                vmdata.NameOfStateList = stateItemList;
            }
            vmdata.NameOfState = dt.Rows[0]["NameOfState"].ToString();
            vmdata.City = dt.Rows[0]["City"].ToString();
            vmdata.SpecificProgram = dt.Rows[0]["SpecificProgram"].ToString();
            vmdata.NoOfParticipant = Convert.ToInt32(dt.Rows[0]["NoOfParticipant"].ToString());
            vmdata.Remarks = dt.Rows[0]["Remarks"].ToString();
            vmdata.OrganisationName = dt.Rows[0]["OrgName"].ToString();


            return View(vmdata);
        }

        [HttpPost]
        public ActionResult EditConductOfCompetitions(Tran_2a_orgactivities_conductofcompetitions_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_2a_orgactivities_conductofcompetitions_Model obj = new Tran_2a_orgactivities_conductofcompetitions_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.Record_ID = VmData.ID;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.NameOfState = VmData.NameOfState;
                    obj.City = VmData.City;
                    obj.SpecificProgram = VmData.SpecificProgram;
                    obj.NoOfParticipant = VmData.NoOfParticipant;
                    obj.Remarks = VmData.Remarks;
                    obj.UpdatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.UpdatedByIp = ipadd;
                    obj.UpdatedBy = VmData.CvoId;
                    int result = integrityPledgeManager.EditConductOfCompetitions(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateActivitiesOtherActivities()
        {
            Tran_2b_orgactivities_otheractivities_ViewModel vmdata = new Tran_2b_orgactivities_otheractivities_ViewModel();
            vmdata.VAW_Year = Convert.ToInt32(DateTime.Now.Year.ToString());
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.DateOfActivity = DateTime.Now;
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateActivitiesOtherActivities(Tran_2b_orgactivities_otheractivities_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_2b_orgactivities_otheractivities_Model obj = new Tran_2b_orgactivities_otheractivities_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CvoId = VmData.CvoId;
                    obj.CvoOrgCode = VmData.CvoOrgCode;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.CreatedBySession = Session.SessionID;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.DistributionOfPamphletsAndBanners_Details = VmData.DistributionOfPamphletsAndBanners_Details;
                    obj.ConductOfWorkshopAndSensitizationProgram_Details = VmData.ConductOfWorkshopAndSensitizationProgram_Details;
                    obj.IssueOfJornalAndNwesletter_Details = VmData.IssueOfJornalAndNwesletter_Details;
                    obj.AnyOtherActivities_Details = VmData.AnyOtherActivities_Details;
                    int result = integrityPledgeManager.SaveActivitiesOtherActivities(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditActivitiesOtherActivities(int ID)
        {
            DataTable dt = integrityPledgeManager.GetActivitiesOtherActivitiesByRecordId(ID).Tables[0];
            Tran_2b_orgactivities_otheractivities_ViewModel vmdata = new Tran_2b_orgactivities_otheractivities_ViewModel();
            vmdata.VAW_Year = Convert.ToInt32(DateTime.Now.Year.ToString());
            vmdata.ID = Convert.ToInt32(dt.Rows[0]["Record_ID"].ToString());
            vmdata.CvoId = dt.Rows[0]["CvoId"].ToString();
            vmdata.CvoOrgCode = dt.Rows[0]["CvoOrgCode"].ToString();
            vmdata.DistributionOfPamphletsAndBanners_Details = dt.Rows[0]["DistributionOfPamphletsAndBanners_Details"].ToString();
            vmdata.ConductOfWorkshopAndSensitizationProgram_Details = dt.Rows[0]["ConductOfWorkshopAndSensitizationProgram_Details"].ToString();
            vmdata.IssueOfJornalAndNwesletter_Details = dt.Rows[0]["IssueOfJornalAndNwesletter_Details"].ToString();
            vmdata.AnyOtherActivities_Details = dt.Rows[0]["AnyOtherActivities_Details"].ToString();
            vmdata.OrganisationName = dt.Rows[0]["OrgName"].ToString();
            vmdata.DateOfActivity = Convert.ToDateTime(dt.Rows[0]["DateOfActivity"].ToString());
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult EditActivitiesOtherActivities(Tran_2b_orgactivities_otheractivities_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_2b_orgactivities_otheractivities_Model obj = new Tran_2b_orgactivities_otheractivities_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.Record_ID = VmData.ID;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.DistributionOfPamphletsAndBanners_Details = VmData.DistributionOfPamphletsAndBanners_Details;
                    obj.ConductOfWorkshopAndSensitizationProgram_Details = VmData.ConductOfWorkshopAndSensitizationProgram_Details;
                    obj.IssueOfJornalAndNwesletter_Details = VmData.IssueOfJornalAndNwesletter_Details;
                    obj.AnyOtherActivities_Details = VmData.AnyOtherActivities_Details;
                    obj.UpdatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.UpdatedBy = VmData.CvoId;
                    obj.UpdatedByIp = ipadd;
                    int result = integrityPledgeManager.EditActivitiesOtherActivities(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }

        #endregion


        #region 3. OUTREACH ACTIVITIES

        #region 3.1. OutreachInvolvingSchoolStudents
        [HttpGet]
        public ActionResult CreateOutreachInvolvingSchoolStudents()
        {
            Tran_3a_outreach_involvingschoolstudents_ViewModel vmdata = new Tran_3a_outreach_involvingschoolstudents_ViewModel();
            vmdata.VAW_Year = Convert.ToInt32(DateTime.Now.Year.ToString());
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.DateOfActivity = DateTime.Now;

            vmdata.StateNameList = new List<SelectListItem>();
            DataTable StateTable = integrityPledgeManager.GetStateList().Tables[0];
            if (StateTable.Rows.Count > 0)
            {
                var stateItemList = new List<SelectListItem>();
                foreach (DataRow dr in StateTable.Rows)
                {
                    stateItemList.Add(new SelectListItem
                    {
                        Value = dr["States"].ToString(),
                        Text = dr["States"].ToString()
                    });
                }
                vmdata.StateNameList = stateItemList;
            }
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateOutreachInvolvingSchoolStudents(Tran_3a_outreach_involvingschoolstudents_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_3a_outreach_involvingschoolstudents_Model obj = new Tran_3a_outreach_involvingschoolstudents_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CvoId = VmData.CvoId;
                    obj.CvoOrgCode = VmData.CvoOrgCode;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.CreatedBySession = Session.SessionID;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.StateName = VmData.StateName;
                    obj.City_Town_Village_Name = VmData.City_Town_Village_Name;
                    obj.SchoolName = VmData.SchoolName;
                    obj.ActivityDetails = VmData.ActivityDetails;
                    obj.NoOfStudentsInvolved = VmData.NoOfStudentsInvolved;
                    int result = integrityPledgeManager.SaveInvolvingSchoolStudents(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditOutreachInvolvingSchoolStudents(int ID)
        {
            DataTable outreachSchoolStudentsTable = integrityPledgeManager.GetInvolvingSchoolStudentsByRecordId(ID).Tables[0];
            Tran_3a_outreach_involvingschoolstudents_ViewModel vmdata = new Tran_3a_outreach_involvingschoolstudents_ViewModel();

            vmdata.ID = Convert.ToInt32(outreachSchoolStudentsTable.Rows[0]["Record_Id"].ToString());
            vmdata.VAW_Year = Convert.ToInt32(outreachSchoolStudentsTable.Rows[0]["VAW_Year"].ToString());
            vmdata.CvoId = outreachSchoolStudentsTable.Rows[0]["CvoId"].ToString();
            vmdata.DateOfActivity = Convert.ToDateTime(outreachSchoolStudentsTable.Rows[0]["DateOfActivity"].ToString());
            vmdata.StateName = outreachSchoolStudentsTable.Rows[0]["StateName"].ToString();
            vmdata.City_Town_Village_Name = outreachSchoolStudentsTable.Rows[0]["City_Town_Village_Name"].ToString();
            vmdata.SchoolName = outreachSchoolStudentsTable.Rows[0]["SchoolName"].ToString();
            vmdata.ActivityDetails = outreachSchoolStudentsTable.Rows[0]["ActivityDetails"].ToString();
            vmdata.NoOfStudentsInvolved = Convert.ToInt32(outreachSchoolStudentsTable.Rows[0]["NoOfStudentsInvolved"].ToString());

            vmdata.StateNameList = new List<SelectListItem>();
            DataTable StateTable = integrityPledgeManager.GetStateList().Tables[0];
            if (StateTable.Rows.Count > 0)
            {
                var stateItemList = new List<SelectListItem>();
                foreach (DataRow dr in StateTable.Rows)
                {
                    stateItemList.Add(new SelectListItem
                    {
                        Value = dr["States"].ToString(),
                        Text = dr["States"].ToString()
                    });
                }
                vmdata.StateNameList = stateItemList;
            }
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult EditOutreachInvolvingSchoolStudents(Tran_3a_outreach_involvingschoolstudents_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_3a_outreach_involvingschoolstudents_Model obj = new Tran_3a_outreach_involvingschoolstudents_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.Record_ID = VmData.ID;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.StateName = VmData.StateName;
                    obj.City_Town_Village_Name = VmData.City_Town_Village_Name;
                    obj.SchoolName = VmData.SchoolName;
                    obj.ActivityDetails = VmData.ActivityDetails;
                    obj.NoOfStudentsInvolved = VmData.NoOfStudentsInvolved;
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    int result = integrityPledgeManager.UpdateInvolvingSchoolStudents(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }

        #endregion


        #region 3.2. OutreachInvolvingCollegeStudents
        [HttpGet]
        public ActionResult CreateOutreachInvolvingCollegeStudents()
        {
            Tran_3b_outreach_involvingcollegestudents_ViewModel vmdata = new Tran_3b_outreach_involvingcollegestudents_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year;
            vmdata.DateOfActivity = DateTime.Now;
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.StateNameList = new List<SelectListItem>();
            DataTable StateTable = integrityPledgeManager.GetStateList().Tables[0];
            if (StateTable.Rows.Count > 0)
            {
                var stateItemList = new List<SelectListItem>();
                foreach (DataRow dr in StateTable.Rows)
                {
                    stateItemList.Add(new SelectListItem
                    {
                        Value = dr["States"].ToString(),
                        Text = dr["States"].ToString()
                    });
                }
                vmdata.StateNameList = stateItemList;
            }
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateOutreachInvolvingCollegeStudents(Tran_3b_outreach_involvingcollegestudents_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_3b_outreach_involvingcollegestudents_Model obj = new Tran_3b_outreach_involvingcollegestudents_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CvoId = VmData.CvoId;
                    obj.CvoOrgCode = VmData.CvoOrgCode;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.CreatedBySession = Session.SessionID;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.StateName = VmData.StateName;
                    obj.City_Town_Village_Name = VmData.City_Town_Village_Name;
                    obj.SchoolName = VmData.SchoolName;
                    obj.ActivityDetails = VmData.ActivityDetails;
                    obj.NoOfStudentsInvolved = VmData.NoOfStudentsInvolved;
                    int result = integrityPledgeManager.SaveInvolvingCollegeStudents(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditOutreachInvolvingCollegeStudents(int ID)
        {
            DataTable outreachCollegeStudentsTable = integrityPledgeManager.GetInvolvingCollegeStudentsByRecordId(ID).Tables[0];
            Tran_3b_outreach_involvingcollegestudents_ViewModel vmdata = new Tran_3b_outreach_involvingcollegestudents_ViewModel();
            vmdata.ID = Convert.ToInt32(outreachCollegeStudentsTable.Rows[0]["Record_Id"].ToString());
            vmdata.VAW_Year = Convert.ToInt32(outreachCollegeStudentsTable.Rows[0]["VAW_Year"].ToString());
            vmdata.CvoId = outreachCollegeStudentsTable.Rows[0]["CvoId"].ToString();
            vmdata.DateOfActivity = Convert.ToDateTime(outreachCollegeStudentsTable.Rows[0]["DateOfActivity"].ToString());
            vmdata.StateName = outreachCollegeStudentsTable.Rows[0]["StateName"].ToString();
            vmdata.City_Town_Village_Name = outreachCollegeStudentsTable.Rows[0]["City_Town_Village_Name"].ToString();
            vmdata.SchoolName = outreachCollegeStudentsTable.Rows[0]["SchoolName"].ToString();
            vmdata.ActivityDetails = outreachCollegeStudentsTable.Rows[0]["ActivityDetails"].ToString();
            vmdata.NoOfStudentsInvolved = Convert.ToInt32(outreachCollegeStudentsTable.Rows[0]["NoOfStudentsInvolved"].ToString());
            vmdata.StateNameList = new List<SelectListItem>();
            DataTable StateTable = integrityPledgeManager.GetStateList().Tables[0];
            if (StateTable.Rows.Count > 0)
            {
                var stateItemList = new List<SelectListItem>();
                foreach (DataRow dr in StateTable.Rows)
                {
                    stateItemList.Add(new SelectListItem
                    {
                        Value = dr["States"].ToString(),
                        Text = dr["States"].ToString()
                    });
                }
                vmdata.StateNameList = stateItemList;
            }
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult EditOutreachInvolvingCollegeStudents(Tran_3b_outreach_involvingcollegestudents_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_3b_outreach_involvingcollegestudents_Model obj = new Tran_3b_outreach_involvingcollegestudents_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.Record_ID = VmData.ID;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.StateName = VmData.StateName;
                    obj.City_Town_Village_Name = VmData.City_Town_Village_Name;
                    obj.SchoolName = VmData.SchoolName;
                    obj.ActivityDetails = VmData.ActivityDetails;
                    obj.NoOfStudentsInvolved = VmData.NoOfStudentsInvolved;
                    int result = integrityPledgeManager.UpdateInvolvingCollegeStudents(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region 3.3. OutreachAwarenessGramSabhas
        [HttpGet]
        public ActionResult CreateOutreachAwarenessGramSabhas()
        {
            Tran_3c_outreach_awarenessgramsabhas_ViewModel vmdata = new Tran_3c_outreach_awarenessgramsabhas_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year;
            vmdata.DateOfActivity = DateTime.Now;
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.StateNameList = new List<SelectListItem>();
            DataTable StateTable = integrityPledgeManager.GetStateList().Tables[0];
            if (StateTable.Rows.Count > 0)
            {
                var stateItemList = new List<SelectListItem>();
                foreach (DataRow dr in StateTable.Rows)
                {
                    stateItemList.Add(new SelectListItem
                    {
                        Value = dr["States"].ToString(),
                        Text = dr["States"].ToString()
                    });
                }
                vmdata.StateNameList = stateItemList;
            }
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateOutreachAwarenessGramSabhas(Tran_3c_outreach_awarenessgramsabhas_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_3c_outreach_awarenessgramsabhas_Model obj = new Tran_3c_outreach_awarenessgramsabhas_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CvoId = VmData.CvoId;
                    obj.CvoOrgCode = VmData.CvoOrgCode;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.CreatedBySession = Session.SessionID;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.StateName = VmData.StateName;
                    obj.City_Town_Village_Name = VmData.City_Town_Village_Name;
                    obj.NameOfGramPanchayat = VmData.NameOfGramPanchayat;
                    obj.ActivityDetails = VmData.ActivityDetails;
                    obj.NoOfPublicOrCitizenParticipated = VmData.NoOfPublicOrCitizenParticipated;
                    int result = integrityPledgeManager.SaveOutreachAwareness(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditOutreachAwarenessGramSabhas(int ID)
        {
            DataTable outreachAwarenessTable = integrityPledgeManager.GetOutreachAwarenessByRecordId(ID).Tables[0];
            Tran_3c_outreach_awarenessgramsabhas_ViewModel vmdata = new Tran_3c_outreach_awarenessgramsabhas_ViewModel();
            vmdata.ID = Convert.ToInt32(outreachAwarenessTable.Rows[0]["Record_Id"].ToString());
            vmdata.VAW_Year = Convert.ToInt32(outreachAwarenessTable.Rows[0]["VAW_Year"].ToString());
            vmdata.CvoId = outreachAwarenessTable.Rows[0]["CvoId"].ToString();
            vmdata.DateOfActivity = Convert.ToDateTime(outreachAwarenessTable.Rows[0]["DateOfActivity"].ToString());
            vmdata.StateName = outreachAwarenessTable.Rows[0]["StateName"].ToString();
            vmdata.City_Town_Village_Name = outreachAwarenessTable.Rows[0]["City_Town_Village_Name"].ToString();
            vmdata.NameOfGramPanchayat = outreachAwarenessTable.Rows[0]["NameOfGramPanchayat"].ToString();
            vmdata.ActivityDetails = outreachAwarenessTable.Rows[0]["ActivityDetails"].ToString();
            vmdata.NoOfPublicOrCitizenParticipated = Convert.ToInt32(outreachAwarenessTable.Rows[0]["NoOfPublicOrCitizenParticipated"].ToString());
            vmdata.StateNameList = new List<SelectListItem>();
            DataTable StateTable = integrityPledgeManager.GetStateList().Tables[0];
            if (StateTable.Rows.Count > 0)
            {
                var stateItemList = new List<SelectListItem>();
                foreach (DataRow dr in StateTable.Rows)
                {
                    stateItemList.Add(new SelectListItem
                    {
                        Value = dr["States"].ToString(),
                        Text = dr["States"].ToString()
                    });
                }
                vmdata.StateNameList = stateItemList;
            }
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult EditOutreachAwarenessGramSabhas(Tran_3c_outreach_awarenessgramsabhas_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_3c_outreach_awarenessgramsabhas_Model obj = new Tran_3c_outreach_awarenessgramsabhas_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.Record_ID = VmData.ID;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.StateName = VmData.StateName;
                    obj.City_Town_Village_Name = VmData.City_Town_Village_Name;
                    obj.NameOfGramPanchayat = VmData.NameOfGramPanchayat;
                    obj.ActivityDetails = VmData.ActivityDetails;
                    obj.NoOfPublicOrCitizenParticipated = VmData.NoOfPublicOrCitizenParticipated;
                    int result = integrityPledgeManager.UpdateOutreachAwareness(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region 3.4. OutreachSeminars
        [HttpGet]
        public ActionResult CreateOutreachSeminars()
        {
            Tran_3d_outreach_seminarsworkshops_ViewModel vmdata = new Tran_3d_outreach_seminarsworkshops_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year;
            vmdata.DateOfActivity = DateTime.Now;
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.StateNameList = new List<SelectListItem>();
            DataTable StateTable = integrityPledgeManager.GetStateList().Tables[0];
            if (StateTable.Rows.Count > 0)
            {
                var stateItemList = new List<SelectListItem>();
                foreach (DataRow dr in StateTable.Rows)
                {
                    stateItemList.Add(new SelectListItem
                    {
                        Value = dr["States"].ToString(),
                        Text = dr["States"].ToString()
                    });
                }
                vmdata.StateNameList = stateItemList;
            }
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateOutreachSeminars(Tran_3d_outreach_seminarsworkshops_ViewModel VmData)
        {
            //SaveSeminarsWorkshops
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_3d_outreach_seminarsworkshops_Model obj = new Tran_3d_outreach_seminarsworkshops_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CvoId = VmData.CvoId;
                    obj.CvoOrgCode = VmData.CvoOrgCode;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.CreatedBySession = Session.SessionID;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.StateName = VmData.StateName;
                    obj.City_Town_Village_Name = VmData.City_Town_Village_Name;
                    obj.NoOfSeminarsWorkshops = VmData.NoOfSeminarsWorkshops;
                    obj.ActivityDetails = VmData.ActivityDetails;
                    obj.NoOfPublicOrCitizenParticipated = VmData.NoOfPublicOrCitizenParticipated;
                    int result = integrityPledgeManager.SaveSeminarsWorkshops(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditOutreachSeminars(int ID)
        {
            DataTable seminarsWorkshopsTable = integrityPledgeManager.GetSeminarsWorkshopsByRecordId(ID).Tables[0];
            Tran_3d_outreach_seminarsworkshops_ViewModel vmdata = new Tran_3d_outreach_seminarsworkshops_ViewModel();
            vmdata.ID = Convert.ToInt32(seminarsWorkshopsTable.Rows[0]["Record_Id"].ToString());
            vmdata.VAW_Year = Convert.ToInt32(seminarsWorkshopsTable.Rows[0]["VAW_Year"].ToString());
            vmdata.CvoId = seminarsWorkshopsTable.Rows[0]["CvoId"].ToString();
            vmdata.DateOfActivity = Convert.ToDateTime(seminarsWorkshopsTable.Rows[0]["DateOfActivity"].ToString());
            vmdata.StateName = seminarsWorkshopsTable.Rows[0]["StateName"].ToString();
            vmdata.City_Town_Village_Name = seminarsWorkshopsTable.Rows[0]["City_Town_Village_Name"].ToString();
            vmdata.NoOfSeminarsWorkshops = Convert.ToInt32(seminarsWorkshopsTable.Rows[0]["NoOfSeminarsWorkshops"].ToString());
            vmdata.ActivityDetails = seminarsWorkshopsTable.Rows[0]["ActivityDetails"].ToString();
            vmdata.NoOfPublicOrCitizenParticipated = Convert.ToInt32(seminarsWorkshopsTable.Rows[0]["NoOfPublicOrCitizenParticipated"].ToString());
            vmdata.StateNameList = new List<SelectListItem>();
            DataTable StateTable = integrityPledgeManager.GetStateList().Tables[0];
            if (StateTable.Rows.Count > 0)
            {
                var stateItemList = new List<SelectListItem>();
                foreach (DataRow dr in StateTable.Rows)
                {
                    stateItemList.Add(new SelectListItem
                    {
                        Value = dr["States"].ToString(),
                        Text = dr["States"].ToString()
                    });
                }
                vmdata.StateNameList = stateItemList;
            }
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult EditOutreachSeminars(Tran_3d_outreach_seminarsworkshops_ViewModel VmData)
        {
            //SaveSeminarsWorkshops
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_3d_outreach_seminarsworkshops_Model obj = new Tran_3d_outreach_seminarsworkshops_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.Record_ID = VmData.ID;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.StateName = VmData.StateName;
                    obj.City_Town_Village_Name = VmData.City_Town_Village_Name;
                    obj.NoOfSeminarsWorkshops = VmData.NoOfSeminarsWorkshops;
                    obj.ActivityDetails = VmData.ActivityDetails;
                    obj.NoOfPublicOrCitizenParticipated = VmData.NoOfPublicOrCitizenParticipated;
                    int result = integrityPledgeManager.UpdateSeminarsWorkshops(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }
        #endregion

        #endregion


        #region 4. OTHER ACTIVITIES

        [HttpGet]
        public ActionResult CreateOtherActivities()
        {
            Tran_4_otheractivities_ViewModel vmdata = new Tran_4_otheractivities_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year;
            vmdata.DateOfActivity = DateTime.Now;
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";

            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateOtherActivities(Tran_4_otheractivities_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_4_otheractivities_Model obj = new Tran_4_otheractivities_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CvoId = VmData.CvoId;
                    obj.CvoOrgCode = VmData.CvoOrgCode;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    obj.DisplayOfBannerPosterDetails = VmData.DisplayOfBannerPosterDetails;
                    obj.NoOfGrievanceRedressalCampsHeld = VmData.NoOfGrievanceRedressalCampsHeld;
                    obj.UserOfScocialMedia = VmData.UserOfScocialMedia;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.CreatedBySession = Session.SessionID;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    int result = integrityPledgeManager.SaveOtherActivities(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditOtherActivities(int ID)
        {
            DataTable otherActivitiesTable = integrityPledgeManager.GetOtherActivitiesByRecordId(ID).Tables[0];
            Tran_4_otheractivities_ViewModel vmdata = new Tran_4_otheractivities_ViewModel();
            vmdata.ID = Convert.ToInt32(otherActivitiesTable.Rows[0]["Record_Id"].ToString());
            vmdata.VAW_Year = Convert.ToInt32(otherActivitiesTable.Rows[0]["VAW_Year"].ToString());
            vmdata.CvoId = otherActivitiesTable.Rows[0]["CvoId"].ToString();
            vmdata.DateOfActivity = Convert.ToDateTime(otherActivitiesTable.Rows[0]["DateOfActivity"].ToString());
            vmdata.DisplayOfBannerPosterDetails = otherActivitiesTable.Rows[0]["DisplayOfBannerPosterDetails"].ToString();
            vmdata.NoOfGrievanceRedressalCampsHeld = Convert.ToInt32(otherActivitiesTable.Rows[0]["NoOfGrievanceRedressalCampsHeld"].ToString());
            vmdata.UserOfScocialMedia = otherActivitiesTable.Rows[0]["UserOfScocialMedia"].ToString();
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult EditOtherActivities(Tran_4_otheractivities_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_4_otheractivities_Model obj = new Tran_4_otheractivities_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.Record_ID = VmData.ID;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.DisplayOfBannerPosterDetails = VmData.DisplayOfBannerPosterDetails;
                    obj.NoOfGrievanceRedressalCampsHeld = VmData.NoOfGrievanceRedressalCampsHeld;
                    obj.UserOfScocialMedia = VmData.UserOfScocialMedia;
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    int result = integrityPledgeManager.UpdateOtherActivities(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }

        #endregion


        #region 5. DETAILS OF PHOTOS ENCLOSED

        [HttpGet]
        public ActionResult CreateDetailsOfPhotos()
        {
            Tran_5_detailsofphotos_ViewModel vmdata = new Tran_5_detailsofphotos_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year;
            vmdata.DateOfActivity = DateTime.Now;
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateDetailsOfPhotos(Tran_5_detailsofphotos_ViewModel VmData)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Tran_5_detailsofphotos_Model obj = new Tran_5_detailsofphotos_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CvoId = VmData.CvoId;
                    obj.CvoOrgCode = VmData.CvoOrgCode;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    obj.NameOfActivity = VmData.NameOfActivity;
                    obj.NoOfPhotos = VmData.NoOfPhotos;
                    obj.WhetherPhotosSentAsSoftCopyOrHardCopy = VmData.WhetherPhotosSentAsSoftCopyOrHardCopy;
                    obj.SoftCopy_NoOfCd = VmData.SoftCopy_NoOfCd;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.CreatedBySession = Session.SessionID;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    int result = integrityPledgeManager.SaveDetailsOfPhotos(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditDetailsOfPhotos(int ID)
        {
            DataTable PhotosTable = integrityPledgeManager.GetDetailsOfPhotosByRecordId(ID).Tables[0];
            Tran_5_detailsofphotos_ViewModel vmdata = new Tran_5_detailsofphotos_ViewModel();
            vmdata.ID = Convert.ToInt32(PhotosTable.Rows[0]["Record_Id"].ToString());
            vmdata.VAW_Year = Convert.ToInt32(PhotosTable.Rows[0]["VAW_Year"].ToString());
            vmdata.CvoId = PhotosTable.Rows[0]["CvoId"].ToString();
            vmdata.DateOfActivity = Convert.ToDateTime(PhotosTable.Rows[0]["DateOfActivity"].ToString());
            vmdata.NameOfActivity = PhotosTable.Rows[0]["NameOfActivity"].ToString();
            vmdata.NoOfPhotos = Convert.ToInt32(PhotosTable.Rows[0]["NoOfPhotos"].ToString());
            vmdata.WhetherPhotosSentAsSoftCopyOrHardCopy = PhotosTable.Rows[0]["WhetherPhotosSentAsSoftCopyOrHardCopy"].ToString();
            vmdata.SoftCopy_NoOfCd = Convert.ToInt32(PhotosTable.Rows[0]["SoftCopy_NoOfCd"].ToString());
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult EditDetailsOfPhotos(Tran_5_detailsofphotos_ViewModel VmData)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Tran_5_detailsofphotos_Model obj = new Tran_5_detailsofphotos_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.Record_ID = VmData.ID;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.NameOfActivity = VmData.NameOfActivity;
                    obj.NoOfPhotos = VmData.NoOfPhotos;
                    obj.WhetherPhotosSentAsSoftCopyOrHardCopy = VmData.WhetherPhotosSentAsSoftCopyOrHardCopy;
                    obj.SoftCopy_NoOfCd = VmData.SoftCopy_NoOfCd;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    int result = integrityPledgeManager.UpdateDetailsOfPhotos(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }

        #endregion


        #region 6. ANY OTHER RELEVANT INFORMATION, IF ANY

        [HttpGet]
        public ActionResult CreateAnyOtherRelevantInformation()
        {
            Tran_6_otherinformation_ViewModel vmdata = new Tran_6_otherinformation_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year.ToString();
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.DateOfActivity = DateTime.Now;
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateAnyOtherRelevantInformation(Tran_6_otherinformation_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_6_otherinformation_Model obj = new Tran_6_otherinformation_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.CreatedByIP = ipadd;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CvoId = VmData.CvoId;
                    obj.CvoOrgCode = VmData.CvoOrgCode;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.DetailsOfActivity = VmData.DetailsOfActivity;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    obj.CreatedBySession = Session.SessionID;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    int result = integrityPledgeManager.SaveAnyOtherRelevantInformation(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return View();
        }

        [HttpGet]
        public ActionResult EditAnyOtherRelevantInformation(int ID)
        {
            Tran_6_otherinformation_ViewModel vmdata = new Tran_6_otherinformation_ViewModel();
            DataTable otherActivitiesTable = integrityPledgeManager.GetOtherRelevantInformationByRecordId(ID).Tables[0];
            vmdata.ID = Convert.ToInt32(otherActivitiesTable.Rows[0]["Record_Id"].ToString());
            vmdata.VAW_Year = otherActivitiesTable.Rows[0]["VAW_Year"].ToString();
            vmdata.CvoId = otherActivitiesTable.Rows[0]["CvoId"].ToString();
            vmdata.DateOfActivity = Convert.ToDateTime(otherActivitiesTable.Rows[0]["DateOfActivity"].ToString());
            vmdata.DetailsOfActivity = otherActivitiesTable.Rows[0]["DetailsOfActivity"].ToString();
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult EditAnyOtherRelevantInformation(Tran_6_otherinformation_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_6_otherinformation_Model obj = new Tran_6_otherinformation_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    obj.Record_ID = VmData.ID;
                    obj.VAW_Year = VmData.VAW_Year;
                    obj.DateOfActivity = VmData.DateOfActivity;
                    obj.DetailsOfActivity = VmData.DetailsOfActivity;
                    obj.CreatedBy = VmData.CvoId;
                    obj.CreatedByIP = ipadd;
                    obj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    int result = integrityPledgeManager.UpdateAnyOtherRelevantInformation(obj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return View();
        }

        #endregion


        // DO NOT DELETE THIS METHOD
        //[HttpGet]        
        //public ActionResult UploadPDF()
        //{
        //    return View() ;
        //}
        //[HttpPost]
        //public ActionResult UploadPDF(HttpPostedFileBase pdfFile)
        //{
        //    string res = PdfUtil.SavePDF(pdfFile);
        //    return RedirectToAction("UploadPDF");
        //}

        private void GetIpAddress(out string userip)
        {
            userip = Request.UserHostAddress;
            if (Request.UserHostAddress != null)
            {
                Int64 macinfo = new Int64();
                string macSrc = macinfo.ToString("X");
                if (macSrc == "0")
                {
                    if (userip == "127.0.0.1")
                    {
                        Response.Write("visited Localhost!");
                    }
                    else
                    {
                        IPAddress = userip;
                    }
                }
            }
        }
    }

}