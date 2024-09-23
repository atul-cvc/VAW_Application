using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using VAW_BusinessAccessLayer;
using VAW_Models;
using VAW_WebApplication.Models;

namespace VAW_WebApplication.Controllers
{
    public class ViewIntegrityPledgeController : Controller
    {
        IntegrityPledgeManager integrityPledgeManager = new IntegrityPledgeManager();
        string IPAddress = null;

        // GET: ViewIntegrityPledge
        public ActionResult Index()
        {
            ViewIntegrityPledgeViewModel viewModel = new ViewIntegrityPledgeViewModel();
            DataTable integrityTable = integrityPledgeManager.GetIntegrityPledgeByCVOID("CVO_SBI").Tables[0]; //GetIntegrityPledge
            DataTable conductTable = integrityPledgeManager.GetConductOfCompetitionsByCVOID("CVO_SBI").Tables[0]; //GetIntegrityPledge
            //List<>

            if (integrityTable.Rows.Count >= 1)
            {
                foreach (DataRow dr in integrityTable.Rows)
                {
                    Tran_1a_integritypledge_ViewModel vmobj = new Tran_1a_integritypledge_ViewModel
                    {
                        VAW_Year = dr["VAW_Year"].ToString(),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        TotalNoOfEmployees_UndertakenPledge = Convert.ToInt32(dr["TotalNoOfEmployees_UndertakenPledge"].ToString()),
                        TotalNoOfCustomers_UndertakenPledge = Convert.ToInt32(dr["TotalNoOfCustomers_UndertakenPledge"].ToString()),
                        TotalNoOfCitizen_UndertakenPledge = Convert.ToInt32(dr["TotalNoOfCitizen_UndertakenPledge"].ToString())
                    };
                    viewModel.IntegrityPledges.Add(vmobj);
                }
            }

            if(conductTable.Rows.Count >= 1)
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
                    };
                    viewModel.OrgActivities_ConductOfCompetitions.Add(vmobj);
                }
            }



            return View(viewModel);
        }


        [HttpGet]
        public ActionResult CreateIntegrityPledge()
        {
            Tran_1a_integritypledge_ViewModel vmdata = new Tran_1a_integritypledge_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year.ToString();
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
            if(StateTable.Rows.Count > 0)
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
            return View("Index");
        }

        [HttpGet]
        public ActionResult CreateActivitiesOtherActivities()
        {
            Tran_2b_orgactivities_otheractivities_ViewModel vmdata = new Tran_2b_orgactivities_otheractivities_ViewModel();
            //vmdata.VAW_Year = Convert.ToInt32(DateTime.Now.Year.ToString());
            //vmdata.CvoId = "CVO_SBI";
            //vmdata.CvoOrgCode = "I61";
            //vmdata.DateOfActivity = DateTime.Now;
            //vmdata.
            
            return View(vmdata);
            //return View();
        }

        [HttpPost]
        public ActionResult CreateActivitiesOtherActivities(Tran_2b_orgactivities_otheractivities_ViewModel vmData)
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult CreateOutreachInvolvingSchoolStudents()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOutreachInvolvingSchoolStudents(Tran_3a_outreach_involvingschoolstudents_ViewModel vmData)
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult CreateOutreachInvolvingCollegeStudents()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOutreachInvolvingCollegeStudents(Tran_3b_outreach_involvingcollegestudents_ViewModel vmData)
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult CreateOutreachAwarenessGramSabhas()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOutreachAwarenessGramSabhas(Tran_3c_outreach_awarenessgramsabhas_ViewModel vmData)
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult CreateOutreachSeminars()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOutreachSeminars(Tran_3d_outreach_seminarsworkshops_ViewModel vmData)
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult CreateOtherActivities()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOtherActivities(Tran_4_otheractivities_ViewModel vmData)
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult CreateDetailsOfPhotos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDetailsOfPhotos(Tran_5_detailsofphotos_ViewModel vmData)
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult CreateAnyOtherRelevantInformation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAnyOtherRelevantInformation(Tran_6_otherinformation_ViewModel vmData)
        {
            return View("Index");
        }

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