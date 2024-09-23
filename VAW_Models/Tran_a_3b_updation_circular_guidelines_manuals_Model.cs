using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VAW_Models
{
    public class Tran_a_3b_updation_circular_guidelines_manuals_Model : CommonModel
    {
        public string VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string WhetherUpdatedDuingCampaign { get; set; }
        public string BriefDetails { get; set; }
    }
}
