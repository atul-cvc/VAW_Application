using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult CreateCapacityBuilding()
        {
            return View();
        }
    }
}