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
                DataTable CapacityTable = capacityBuildingManager.GetCapacityBuildingRecordByCVOID("CVO_SBI").Tables[0];

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
                            BriefDescription = data["BriefDescription"].ToString()
                        };
                        ListofCapBuilding.Add(vmobj);
                    }
                }

                //System Improvement               
                List<Tran_a_2b_sysimp_ViewModel> Listofsysimp = new List<Tran_a_2b_sysimp_ViewModel>();
                DataTable SysImpTable = capacityBuildingManager.GetSystemImpRecordByCVOID("CVO_SBI").Tables[0];

                if (CapacityTable.Rows.Count >= 1)
                {
                    foreach (DataRow data in SysImpTable.Rows)
                    {
                        Tran_a_2b_sysimp_ViewModel vmobjsysimp = new Tran_a_2b_sysimp_ViewModel
                        {
                            VAW_Year = data["VAW_Year"].ToString(),
                            FromDate = Convert.ToDateTime(data["FromDate"].ToString()),
                            ToDate = Convert.ToDateTime(data["ToDate"].ToString()),
                            Sys_Imp_Implemented_During_Campaign = data["Sys_Imp_Implemented_During_Campaign"].ToString(),
                            Sys_Imp_Suggested_Last_5_Years_But_Pending = data["Sys_Imp_Suggested_Last_5_Years_But_Pending"].ToString()

                        };
                        Listofsysimp.Add(vmobjsysimp);
                    }
                }


                //circulars Binding               
                List<Tran_a_3b_updation_circular_guidelines_manuals_ViewModel> ListofCircular = new List<Tran_a_3b_updation_circular_guidelines_manuals_ViewModel>();
                DataTable CircularTable = capacityBuildingManager.GetCircularsRecordByCVOID("CVO_SBI").Tables[0];

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
                            BriefDetails = data["BriefDetails"].ToString()

                        };
                        ListofCircular.Add(vmobjCircular);
                    }
                }


                //Disposal Of Complaint
                List<Tran_a_4b_disposalofcomplaints_ViewModel> ListofDisposalOfComplaint = new List<Tran_a_4b_disposalofcomplaints_ViewModel>();
                DataTable DisposalOfComplaintTable = capacityBuildingManager.GetDisposalOfComplaintByCVOID("CVO_SBI").Tables[0];

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
                            Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511 = data["Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511"].ToString()
                        };
                        ListofDisposalOfComplaint.Add(vmobjDisposal);
                    }
                }


                //Digital Dyanamic
                List<Tran_a_5b_dynamicdigitalpresence_ViewModel> ListofDynamicdigital = new List<Tran_a_5b_dynamicdigitalpresence_ViewModel>();
                DataTable DynamicdigitalTable = capacityBuildingManager.GetDynamicDigitalPresenceByCVOID("CVO_SBI").Tables[0];

                if (DisposalOfComplaintTable.Rows.Count >= 1)
                {
                    foreach (DataRow data in DynamicdigitalTable.Rows)
                    {
                        Tran_a_5b_dynamicdigitalpresence_ViewModel vmobjDynamicdigital = new Tran_a_5b_dynamicdigitalpresence_ViewModel
                        {

                            VAW_Year = data["VAW_Year"].ToString(),
                            WhetherRegularMaintenanceOfWebsiteUpdationDone = data["WhetherRegularMaintenanceOfWebsiteUpdationDone"].ToString(),
                            SystemIntroducedForUpdationAndReview = data["SystemIntroducedForUpdationAndReview"].ToString(),
                            WhetherAdditionalAreas_Activities_ServicesBroughtOnline = data["WhetherAdditionalAreas_Activities_ServicesBroughtOnline"].ToString(),
                            DetailsOfAdditionalActivities= data["DetailsOfAdditionalActivities"].ToString()                           
                        };
                        ListofDynamicdigital.Add(vmobjDynamicdigital);
                    }
                }

                




                modelobj.CapacityBuiliding_VM = ListofCapBuilding;
                modelobj.Sys_Improvement_VM = Listofsysimp;
                modelobj.UpdationCirculars_VM = ListofCircular;
                modelobj.DisposalComplaints_VM = ListofDisposalOfComplaint;
                modelobj.DynamicDigitalPresence_VM = ListofDynamicdigital;
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
                    Capbulidobj.CreatedBy = VmData.CvoId;
                    Capbulidobj.CvoId = VmData.CvoId;
                    Capbulidobj.CvoOrgCode = VmData.CvoOrgCode;
                    Capbulidobj.VAW_Year = VmData.VAW_Year;
                    Capbulidobj.FromDate = VmData.FromDate;
                    Capbulidobj.ToDate = VmData.ToDate;
                    Capbulidobj.TrainingName = VmData.TrainingName;
                    Capbulidobj.EmployeesTrained = VmData.EmployeesTrained;
                    Capbulidobj.BriefDescription = VmData.BriefDescription;
                    Capbulidobj.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
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
            Tran_a_2b_sysimp_ViewModel vmmodal = new Tran_a_2b_sysimp_ViewModel();
            vmmodal.VAW_Year = DateTime.Now.Year.ToString();
            vmmodal.CvoId = "CVO_SBI";
            vmmodal.CvoOrgCode = "I61";
            vmmodal.FromDate = DateTime.Now;
            vmmodal.ToDate = DateTime.Now;
            return View(vmmodal);
        }

        [HttpPost]
        public ActionResult CreateIdentificationAndImplementation(Tran_a_2b_sysimp_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_a_2b_sysimp_Model vmmodal = new Tran_a_2b_sysimp_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    vmmodal.CreatedByIP = ipadd;
                    vmmodal.CreatedBy = VmData.CvoId;
                    vmmodal.CvoId = VmData.CvoId;
                    vmmodal.CvoOrgCode = VmData.CvoOrgCode;
                    vmmodal.VAW_Year = VmData.VAW_Year;
                    vmmodal.FromDate = VmData.FromDate;
                    vmmodal.ToDate = VmData.ToDate;
                    vmmodal.Sys_Imp_Implemented_During_Campaign = VmData.Sys_Imp_Implemented_During_Campaign;
                    vmmodal.Sys_Imp_Suggested_Last_5_Years_But_Pending = VmData.Sys_Imp_Suggested_Last_5_Years_But_Pending;
                    vmmodal.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    vmmodal.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    vmmodal.CreatedBySession = Session.SessionID;
                    int result = capacityBuildingManager.SaveIdentificationAndImplimentation(vmmodal);
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
        public ActionResult CreateUpdationOfCirculars()
        {
            Tran_a_3b_updation_circular_guidelines_manuals_ViewModel vmdata = new Tran_a_3b_updation_circular_guidelines_manuals_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year.ToString();
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.FromDate = DateTime.Now;
            vmdata.ToDate = DateTime.Now;
            vmdata.YesNoOptions = new List<SelectListItem> {
                new SelectListItem { Value = "YES", Text = "YES" },
                new SelectListItem { Value = "NO", Text = "NO" }
            };
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateUpdationOfCirculars(Tran_a_3b_updation_circular_guidelines_manuals_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_a_3b_updation_circular_guidelines_manuals_Model Circularobj = new Tran_a_3b_updation_circular_guidelines_manuals_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    Circularobj.CreatedByIP = ipadd;
                    Circularobj.CreatedBy = VmData.CvoId;
                    Circularobj.CvoId = VmData.CvoId;
                    Circularobj.CvoOrgCode = VmData.CvoOrgCode;
                    Circularobj.VAW_Year = VmData.VAW_Year;
                    Circularobj.FromDate = VmData.FromDate;
                    Circularobj.ToDate = VmData.ToDate;
                    Circularobj.WhetherUpdatedDuingCampaign = VmData.WhetherUpdatedDuingCampaign;
                    Circularobj.BriefDetails = VmData.BriefDetails;
                    Circularobj.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    Circularobj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    Circularobj.CreatedBySession = Session.SessionID;
                    int result = capacityBuildingManager.SaveCirculars(Circularobj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }

            }
            catch (Exception ex)
            {

            }
            Tran_a_3b_updation_circular_guidelines_manuals_ViewModel vmdata = new Tran_a_3b_updation_circular_guidelines_manuals_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year.ToString();
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.FromDate = DateTime.Now;
            vmdata.ToDate = DateTime.Now;
            vmdata.YesNoOptions = new List<SelectListItem> {
                new SelectListItem { Value = "YES", Text = "YES" },
                new SelectListItem { Value = "NO", Text = "NO" }
            };
            return View(vmdata);
        }

        [HttpGet]
        public ActionResult CreateDisposalOfComplaints()
        {
            Tran_a_4b_disposalofcomplaints_ViewModel vmmodal = new Tran_a_4b_disposalofcomplaints_ViewModel();
            vmmodal.VAW_Year = DateTime.Now.Year.ToString();
            vmmodal.CvoId = "CVO_SBI";
            vmmodal.CvoOrgCode = "I61";
            return View(vmmodal);
        }

        [HttpPost]
        public ActionResult CreateDisposalOfComplaints(Tran_a_4b_disposalofcomplaints_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_a_4b_disposalofcomplaints_Model vmmodal = new Tran_a_4b_disposalofcomplaints_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    vmmodal.CreatedByIP = ipadd;
                    vmmodal.CreatedBy = VmData.CvoId;
                    vmmodal.CvoId = VmData.CvoId;
                    vmmodal.CvoOrgCode = VmData.CvoOrgCode;
                    vmmodal.VAW_Year = VmData.VAW_Year;
                    vmmodal.NoOf_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608 = VmData.NoOf_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608;
                    vmmodal.Remarks_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608 = VmData.Remarks_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608;
                    vmmodal.NoOf_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign = VmData.NoOf_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign;
                    vmmodal.Remarks_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign = VmData.Remarks_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign;
                    vmmodal.NoOf_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511 = VmData.NoOf_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511;
                    vmmodal.Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511 = VmData.Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511;
                    vmmodal.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    vmmodal.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    vmmodal.CreatedBySession = Session.SessionID;
                    int result = capacityBuildingManager.SaveDisposalOfComplaint(vmmodal);

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
        public ActionResult CreateDigitalDynamicPresence()
        {
            Tran_a_5b_dynamicdigitalpresence_ViewModel vmdata = new Tran_a_5b_dynamicdigitalpresence_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year.ToString();
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.YesNoOptions = new List<SelectListItem> {
                new SelectListItem { Value = "YES", Text = "YES" },
                new SelectListItem { Value = "NO", Text = "NO" }
            };
            vmdata.YesNoOptionsforAdditionalAreas = new List<SelectListItem> {
                new SelectListItem { Value = "YES", Text = "YES" },
                new SelectListItem { Value = "NO", Text = "NO" }
            };
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateDigitalDynamicPresence(Tran_a_5b_dynamicdigitalpresence_ViewModel VmData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tran_a_5b_dynamicdigitalpresence_Model dynamicdigitalpresenceObj = new Tran_a_5b_dynamicdigitalpresence_Model();
                    string ipadd;
                    GetIpAddress(out ipadd);
                    dynamicdigitalpresenceObj.CreatedByIP = ipadd;
                    dynamicdigitalpresenceObj.CreatedBy = VmData.CvoId;
                    dynamicdigitalpresenceObj.CvoId = VmData.CvoId;
                    dynamicdigitalpresenceObj.CvoOrgCode = VmData.CvoOrgCode;
                    dynamicdigitalpresenceObj.VAW_Year = VmData.VAW_Year;
                    dynamicdigitalpresenceObj.WhetherRegularMaintenanceOfWebsiteUpdationDone = VmData.WhetherRegularMaintenanceOfWebsiteUpdationDone;
                    dynamicdigitalpresenceObj.SystemIntroducedForUpdationAndReview = VmData.SystemIntroducedForUpdationAndReview;
                    dynamicdigitalpresenceObj.WhetherAdditionalAreas_Activities_ServicesBroughtOnline = VmData.WhetherAdditionalAreas_Activities_ServicesBroughtOnline;
                    dynamicdigitalpresenceObj.DetailsOfAdditionalActivities = VmData.DetailsOfAdditionalActivities;
                    dynamicdigitalpresenceObj.UniqueTransactionId = Guid.NewGuid().ToString() + "_" + VmData.VAW_Year;
                    dynamicdigitalpresenceObj.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    dynamicdigitalpresenceObj.CreatedBySession = Session.SessionID;
                    int result = capacityBuildingManager.SaveDynamicDigitalPresence(dynamicdigitalpresenceObj);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                }


            }
            catch (Exception ex)
            {

            }

            Tran_a_5b_dynamicdigitalpresence_ViewModel vmdata = new Tran_a_5b_dynamicdigitalpresence_ViewModel();
            vmdata.VAW_Year = DateTime.Now.Year.ToString();
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.YesNoOptions = new List<SelectListItem> {
                new SelectListItem { Value = "YES", Text = "YES" },
                new SelectListItem { Value = "NO", Text = "NO" }
            };
            vmdata.YesNoOptionsforAdditionalAreas = new List<SelectListItem> {
                new SelectListItem { Value = "YES", Text = "YES" },
                new SelectListItem { Value = "NO", Text = "NO" }
            };
            return View(vmdata);

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