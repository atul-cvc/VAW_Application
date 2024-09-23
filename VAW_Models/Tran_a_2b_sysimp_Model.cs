using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VAW_Models
{
    public class Tran_a_2b_sysimp_Model : CommonModel
    {
        public string VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Sys_Imp_Implemented_During_Campaign { get; set; }
        public string Sys_Imp_Suggested_Last_5_Years_But_Pending { get; set; }
    }
}
