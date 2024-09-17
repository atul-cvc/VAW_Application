using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class Tran_1a_integritypledge_ViewModel
    {
        public string VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }
        public string DateOfActivity { get; set; }
        public string TotalNoOfEmployees_UndertakenPledge { get; set; }
        public string TotalNoOfCustomers_UndertakenPledge { get; set; }
        public string TotalNoOfCitizen_UndertakenPledge { get; set; }
    }
}