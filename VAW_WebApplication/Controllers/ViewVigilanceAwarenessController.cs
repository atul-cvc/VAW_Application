using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;
using System.Xml.Linq;
using VAW_BusinessAccessLayer;
using VAW_Models;
using VAW_WebApplication.Models;

namespace VAW_WebApplication.Controllers
{
    public class ViewVigilanceAwarenessController : Controller
    {
        CapacityBuildingManager capacityBuildingManager = new CapacityBuildingManager();
        string IPAddress = null;
        // GET: ViewVigilanceAwareness
        public ActionResult Index()
        {
            try
            {
                ViewVigilanceAwarenessViewModel modelobj = new ViewVigilanceAwarenessViewModel();
                List<Tran_a_1b_capacitybulidingprogram_ViewModel> ListofCapBuilding = new List<Tran_a_1b_capacitybulidingprogram_ViewModel>();    
               DataTable CapacityTable= capacityBuildingManager.GetCapacityBuildingRecordByCVOID("CVO_SBI").Tables[0];

                if (CapacityTable.Rows.Count >= 1)
                {
                    foreach (DataRow data in CapacityTable.Rows)
                    {
                        Tran_a_1b_capacitybulidingprogram_ViewModel vmobj = new Tran_a_1b_capacitybulidingprogram_ViewModel
                        {                            
                            VAW_Year = data["VAW_Year"].ToString(),
                            FromDate = Convert.ToDateTime(data["FromDate"].ToString()),
                            ToDate = Convert.ToDateTime(data["ToDate"].ToString()),
                            TrainingName = data["TrainingName"].ToString()== "FRESH" ? "Fresh Inductees" : "Refresher Course",
                            EmployeesTrained = Convert.ToInt32(data["EmployeesTrained"].ToString()),
                            BriefDescription = data["BriefDescription"].ToString()
                        };
                        ListofCapBuilding.Add(vmobj);
                    }
                }
                modelobj.CapacityBuiliding_VM = ListofCapBuilding;
                return View(modelobj);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateCapacityBuilding()
        {
            Tran_a_1b_capacitybulidingprogram_ViewModel vmdata = new Tran_a_1b_capacitybulidingprogram_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year.ToString();
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.FromDate = DateTime.Now;
            vmdata.ToDate = DateTime.Now;
            vmdata.TrainingNameList = new List<SelectListItem> {
                new SelectListItem { Value = "FRESH", Text = "Fresh Inductees" },
                new SelectListItem { Value = "REFRESH", Text = "Refresher Course" }
            };
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateCapacityBuilding(Tran_a_1b_capacitybulidingprogram_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_a_1b_capacitybulidingprogram_Model Capbulidobj = new Tran_a_1b_capacitybulidingprogram_Model();    
                    string ipadd;
                    GetIpAddress(out ipadd);
                    Capbulidobj.CreatedByIP = ipadd;
                    Capbulidobj.CreatedBy= VmData.CvoId;
                    Capbulidobj.CvoId = VmData.CvoId;
                    Capbulidobj.CvoOrgCode = VmData.CvoOrgCode;
                    Capbulidobj.VAW_Year = VmData.VAW_Year;
                    Capbulidobj.FromDate = VmData.FromDate;
                    Capbulidobj.ToDate = VmData.ToDate;
                    Capbulidobj.TrainingName = VmData.TrainingName;
                    Capbulidobj.EmployeesTrained = VmData.EmployeesTrained;
                    Capbulidobj.BriefDescription = VmData.BriefDescription;
                    Capbulidobj.UniqueTransactionId =Guid.NewGuid().ToString()+"_"+ VmData.VAW_Year;
                    Capbulidobj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    Capbulidobj.CreatedBySession = Session.SessionID;
                    int result = capacityBuildingManager.SaveCapacityBuilding(Capbulidobj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");                        
                    }
                }
            }
            catch (Exception ex)
            {

            }
            Tran_a_1b_capacitybulidingprogram_ViewModel vmdata = new Tran_a_1b_capacitybulidingprogram_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year.ToString();
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.FromDate = DateTime.Now;
            vmdata.ToDate = DateTime.Now;
            vmdata.TrainingNameList = new List<SelectListItem> {
            new SelectListItem { Value = "FRESH", Text = "Fresh Inductees" },
            new SelectListItem { Value = "REFRESH", Text = "Refresher Course" }
            };
            return View(vmdata);
        }

        [HttpGet]
        public ActionResult CreateIdentificationAndImplementation()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateIdentificationAndImplementation(Tran_a_2b_sysimp_ViewModel VmData)
        {
            return View();
        }


        [HttpGet]
        public ActionResult CreateUpdationOfCirculars()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateUpdationOfCirculars(Tran_a_3b_updation_circular_guidelines_manuals_ViewModel VmData)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateDisposalOfComplaints()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateDisposalOfComplaints(Tran_a_4b_disposalofcomplaints_ViewModel VmData)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateDigitalDynamicPresence()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateDigitalDynamicPresence(Tran_a_5b_dynamicdigitalpresence_ViewModel VmData)
        {
            return View();
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