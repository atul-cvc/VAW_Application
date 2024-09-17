using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VAW_Models
{
    public class Tran_3d_outreach_seminarsworkshops_Model : CommonModel
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
