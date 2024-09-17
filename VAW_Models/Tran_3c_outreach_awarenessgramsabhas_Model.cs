using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VAW_Models
{
    public class Tran_3c_outreach_awarenessgramsabhas_Model : CommonModel
    {
        public string VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }
        public string DateOfActivity { get; set; }
        public string StateName { get; set; }
        public string City_Town_Village_Name { get; set; }
        public string NameOfGramPanchayat { get; set; }
        public string ActivityDetails { get; set; }
        public string NoOfPublicOrCitizenParticipated { get; set; }
    }
}
