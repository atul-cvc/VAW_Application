using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;
using System.Xml.Linq;
using VAW_BusinessAccessLayer;
using VAW_WebApplication.Models;

namespace VAW_WebApplication.Controllers
{
    public class ViewVigilanceAwarenessController : Controller
    {
        CapacityBuildingManager capacityBuildingManager = new CapacityBuildingManager();
        // GET: ViewVigilanceAwareness
        public ActionResult Index()
        {
            try
            {
                ViewVigilanceAwarenessViewModel vaVM = new ViewVigilanceAwarenessViewModel();
                //vaVM.CapacityBuiliding = new List<Tran_a_1b_capacitybulidingprogram_ViewModel>(); //capacityBuildingManager.GetCapacityBuilding("2024");
                return View(vaVM);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateCapacityBuilding()
        {
            Tran_a_1b_capacitybulidingprogram_ViewModel vmdata=new Tran_a_1b_capacitybulidingprogram_ViewModel();
            vmdata.VAW_Year = "2014";
            vmdata.CvoId = "CVO_SBI";
            vmdata.CvoOrgCode = "I61";
            vmdata.FromDate=DateTime.Now;
            vmdata.ToDate=DateTime.Now;
            vmdata.TrainingNameList = new List<SelectListItem> {
            new SelectListItem { Value = "FRESH", Text = "Fresh Inductees" },
            new SelectListItem { Value = "REFRESH", Text = "Refresher Course" }            
        };
            return View(vmdata);
        }

        [HttpPost]
        public ActionResult CreateCapacityBuilding( Tran_a_1b_capacitybulidingprogram_ViewModel VmData )
        {
            try
            {
                if (ModelState.IsValid)
                {

                }
            }
            catch (Exception ex)
            {

            }
            Tran_a_1b_capacitybulidingprogram_ViewModel vmdata = new Tran_a_1b_capacitybulidingprogram_ViewModel();
            vmdata.VAW_Year = "2014";
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
    }
}