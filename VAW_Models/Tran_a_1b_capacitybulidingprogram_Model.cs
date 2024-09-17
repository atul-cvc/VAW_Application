﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VAW_Models
{
    public class Tran_a_1b_capacitybulidingprogram_Model : CommonModel
    {
        public string VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string TrainingName { get; set; }
        public string EmployeesTrained { get; set; }
        public string BriefDescription { get; set; }
    }
}
