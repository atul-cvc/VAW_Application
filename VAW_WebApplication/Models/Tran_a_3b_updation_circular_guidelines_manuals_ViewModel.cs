﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class Tran_a_3b_updation_circular_guidelines_manuals_ViewModel
    {
        [Required(ErrorMessage = "Please enter year.")]
        [Display(Name = "VAW Year")]
        [RegularExpression(@"^(19|20)\d{2}$", ErrorMessage = "Entry should be a valid year (1900-2099)")]
        public string VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }

        [Required(ErrorMessage = "Choose From date.")]
        [Display(Name = "From Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public string FromDate { get; set; }

        [Required(ErrorMessage = "Choose To date.")]
        [Display(Name = "To Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public string ToDate { get; set; }

        [Required(ErrorMessage = "Please select")]
        [Display(Name = "Whether guidelines/circulars and manual were updated during the campaign period")]
        public string WhetherUpdatedDuingCampaign { get; set; }

        [Required(ErrorMessage = "Please enter Brief Details")]
        [Display(Name = "Brief Details")]
        public string BriefDetails { get; set; }
    }
}