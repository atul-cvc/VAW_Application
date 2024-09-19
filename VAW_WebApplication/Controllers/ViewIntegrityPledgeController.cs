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


        [HttpGet]
        public ActionResult CreateIntegrityPledge()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateIntegrityPledge(Tran_1a_integritypledge_ViewModel vmData)
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult CreateConductOfCompetitions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateConductOfCompetitions(Tran_2a_orgactivities_conductofcompetitions_ViewModel vmData)
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult CreateActivitiesOtherActivities()
        {
            return View();
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
    }

}