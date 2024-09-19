﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class Tran_2b_orgactivities_otheractivities_ViewModel
    {
        [Required(ErrorMessage = "Please enter year.")]
        [Display(Name = "VAW Year")]
        public string VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }

        [Required(ErrorMessage = "Choose From date.")]
        [Display(Name = "Date of Activity")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public string DateOfActivity { get; set; }

        [Required(ErrorMessage = "Please enter details regarding distribution of pamphlets and banners.")]
        [Display(Name = "Distribution of Pamphlets / Banners")]
        public string DistributionOfPamphletsAndBanners_Details { get; set; }

        [Required(ErrorMessage = "Please enter details regarding Conduct of Workshops/Sensitization programmes.")]
        [Display(Name = "Conduct of Workshops/Sensitization programmes")]
        public string ConductOfWorkshopAndSensitizationProgram_Details { get; set; }

        [Required(ErrorMessage = "Please enter details regarding Issue Of Journal And Newsletter Details.")]
        [Display(Name = "Issue Of Journal And Newsletter Details")]
        public string IssueOfJornalAndNwesletter_Details { get; set; }

        [Required(ErrorMessage = "Please enter details regarding Any Other Activities Details.")]
        [Display(Name = "Any Other Activities Details")]
        public string AnyOtherActivities_Details { get; set; }
    }
}