using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAW_Models;
using static System.Net.Mime.MediaTypeNames;

namespace VAW_Models
{
    public class Tran_1a_integritypledge_Model : CommonModel
    {
        public int VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }
        public DateTime DateOfActivity { get; set; }
        public int TotalNoOfEmployees_UndertakenPledge { get; set; }
        public int TotalNoOfCustomers_UndertakenPledge { get; set; }
        public int TotalNoOfCitizen_UndertakenPledge { get; set; }
    }
}



