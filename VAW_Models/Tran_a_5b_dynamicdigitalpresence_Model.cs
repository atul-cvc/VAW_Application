using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VAW_Models
{
    public class Tran_a_5b_dynamicdigitalpresence_Model : CommonModel
    {
        public string VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }
        public string WhetherRegularMaintenanceOfWebsiteUpdationDone { get; set; }
        public string SystemIntroducedForUpdationAndReview { get; set; }
        public string WhetherAdditionalAreas_Activities_ServicesBroughtOnline { get; set; }
        public string DetailsOfAdditionalActivities { get; set; }
    }
}
