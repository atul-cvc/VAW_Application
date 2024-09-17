using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VAW_Models
{
    public class Tran_2b_orgactivities_otheractivities_Model : CommonModel
    {
          public string VAW_Year { get; set; }
          public string UniqueTransactionId {get;set;}
          public string CvoOrgCode {get;set;}
          public string CvoId {get;set;}
          public string DateOfActivity {get;set;}
          public string DistributionOfPamphletsAndBanners_Details {get;set;}
          public string ConductOfWorkshopAndSensitizationProgram_Details {get;set;}
          public string IssueOfJornalAndNwesletter_Details {get;set;}
          public string AnyOtherActivities_Details {get;set;}
    }
}
