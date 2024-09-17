﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VAW_Models
{
    public class Tran_5_detailsofphotos_Model : CommonModel
    {
        public string VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }
        public string DateOfActivity { get; set; }
        public string NameOfActivity { get; set; }
        public string NoOfPhotos { get; set; }
        public string WhetherPhotosSentAsSoftCopyOrHardCopy { get; set; }
        public string SoftCopy_NoOfCd { get; set; }
    }
}
