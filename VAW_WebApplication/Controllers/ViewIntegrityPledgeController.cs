using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VAW_WebApplication.Models;

namespace VAW_WebApplication.Controllers
{
    public class ViewIntegrityPledgeController : Controller
    {
        // GET: ViewIntegrityPledge
        public ActionResult Index()
        {
            ViewIntegrityPledgeViewModel viewModel = new ViewIntegrityPledgeViewModel();
            return View(viewModel);
        }
    }
}