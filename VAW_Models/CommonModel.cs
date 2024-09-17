using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VAW_Models
{
    public class CommonModel
    {
        public string Record_ID { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIP { get; set; }
        public string CreatedBySession { get; set; }
        public string UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedByIp { get; set; }
    }
}
