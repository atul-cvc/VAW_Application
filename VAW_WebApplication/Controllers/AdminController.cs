using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VAW_BusinessAccessLayer;
using VAW_WebApplication.Models;

namespace VAW_WebApplication.Controllers
{
    public class AdminController : Controller
    {
        IntegrityPledgeManager integrityPledgeManager = new IntegrityPledgeManager();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewVigilanceAwareness()
        {
            return View();
        }

        public ActionResult ViewIntegrityPledge()
        {
            ViewIntegrityPledgeViewModel viewModel = new ViewIntegrityPledgeViewModel();
            DataTable integrityTable = integrityPledgeManager.GetIntegrityPledgeByRecordId(0).Tables[0];
            DataTable conductTable = integrityPledgeManager.GetConductOfCompetitionsByRecordId(0).Tables[0];
            DataTable activitiesOthActivitiesTable = integrityPledgeManager.GetActivitiesOtherActivitiesByRecordId(0).Tables[0];

            if (integrityTable.Rows.Count >= 1)
            {
                foreach (DataRow dr in integrityTable.Rows)
                {
                    Tran_1a_integritypledge_ViewModel vmobj = new Tran_1a_integritypledge_ViewModel
                    {
                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        TotalNoOfEmployees_UndertakenPledge = Convert.ToInt32(dr["TotalNoOfEmployees_UndertakenPledge"].ToString()),
                        TotalNoOfCustomers_UndertakenPledge = Convert.ToInt32(dr["TotalNoOfCustomers_UndertakenPledge"].ToString()),
                        TotalNoOfCitizen_UndertakenPledge = Convert.ToInt32(dr["TotalNoOfCitizen_UndertakenPledge"].ToString()),
                        OrganisationName = dr["OrgName"].ToString()
                    };
                    viewModel.IntegrityPledges.Add(vmobj);
                }
            }

            if (conductTable.Rows.Count >= 1)
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
                        OrganisationName = dr["OrgName"].ToString()
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

                        VAW_Year = Convert.ToInt32(dr["VAW_Year"].ToString()),
                        UniqueTransactionId = dr["UniqueTransactionId"].ToString(),
                        CvoOrgCode = dr["CvoOrgCode"].ToString(),
                        CvoId = dr["CvoId"].ToString(),
                        DateOfActivity = Convert.ToDateTime(dr["DateOfActivity"].ToString()),
                        DistributionOfPamphletsAndBanners_Details = dr["DistributionOfPamphletsAndBanners_Details"].ToString(),
                        ConductOfWorkshopAndSensitizationProgram_Details = dr["ConductOfWorkshopAndSensitizationProgram_Details"].ToString(),
                        IssueOfJornalAndNwesletter_Details = dr["IssueOfJornalAndNwesletter_Details"].ToString(),
                        AnyOtherActivities_Details = dr["AnyOtherActivities_Details"].ToString(),
                        OrganisationName = dr["OrgName"].ToString()
                    };
                    viewModel.OrgActivities_OtherActivities.Add(vmobj);
                }
            }

            return View(viewModel);
        }
    }
}