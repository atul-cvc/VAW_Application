using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VAW_Models
{
    public class Tran_2a_orgactivities_conductofcompetitions_Model : CommonModel
    {
        public string VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }
        public string DateOfActivity { get; set; }
        public string NameOfState { get; set; }
        public string City { get; set; }
        public string SpecificProgram { get; set; }
        public string NoOfParticipant { get; set; }
        public string Remarks { get; set; }
    }
}
