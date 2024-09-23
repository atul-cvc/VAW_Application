using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VAW_Models
{
    public class Tran_4_otheractivities_Model : CommonModel
    {
        public int VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }
        public DateTime DateOfActivity { get; set; }
        public string DisplayOfBannerPosterDetails { get; set; }
        public int NoOfGrievanceRedressalCampsHeld { get; set; }
        public string UserOfScocialMedia { get; set; }
    }
}
