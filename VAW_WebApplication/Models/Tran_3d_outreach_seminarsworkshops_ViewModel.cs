using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class Tran_3d_outreach_seminarsworkshops_ViewModel
    {
        public string VAW_Year { get; }
        public string UniqueTransactionId { get; }
        public string CvoOrgCode { get; }
        public string CvoId { get; }
        public string DateOfActivity { get; }
        public string StateName { get; }
        public string City_Town_Village_Name { get; }
        public string NoOfSeminarsWorkshops { get; }
        public string ActivityDetails { get; }
        public string NoOfPublicOrCitizenParticipated { get; }
    }
}