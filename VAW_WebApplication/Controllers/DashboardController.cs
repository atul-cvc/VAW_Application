using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VAW_WebApplication.Common;

namespace VAW_WebApplication.Controllers
{
    //[Authorize(Roles = "CVO_USER")]
    [CustomAuthorize(Roles = "CVO_USER")]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        
    }
}
