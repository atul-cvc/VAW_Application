using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class Tran_a_2b_sysimp_ViewModel
    {
        public string VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Sys_Imp_Implemented_During_Campaign { get; set; }
        public string Sys_Imp_Suggested_Last_5_Years_But_Pending { get; set; }
    }
}