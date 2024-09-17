using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VAW_Models
{
    public class Tran_a_4b_disposalofcomplaints_Model : CommonModel
    {
        public string VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }
        public string NoOf_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608 { get; set; }
        public string Remarks_ComplaintsRecvd_OnOrBefore_3006_Pending_AsOn_1608 { get; set; }
        public string NoOf_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign { get; set; }
        public string Remarks_ComplaintsRecvd_OnOrBefore_3006_DisposedDuringCampaign { get; set; }
        public string NoOf_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511 { get; set; }
        public string Remarks_ComplaintsRecvd_OnOrBefore_3006_PendingAsOn_1511 { get; set; }
    }
}
