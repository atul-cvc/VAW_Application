using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VAW_BusinessAccessLayer;

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
                var data = capacityBuildingManager.GetCapacityBuilding("2024");
                return View(data);
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