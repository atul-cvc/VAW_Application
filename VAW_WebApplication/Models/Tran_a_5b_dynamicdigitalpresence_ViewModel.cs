using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class Tran_a_5b_dynamicdigitalpresence_ViewModel
    {
        [Required(ErrorMessage = "The VAW Year is required.")]
        [Display(Name = "VAW Year")]
        public string VAW_Year { get; set; }

        [Required(ErrorMessage = "The Unique Transaction Id is required.")]
        [Display(Name = "Unique Transaction Id")]
        public string UniqueTransactionId { get; set; }

        [Required(ErrorMessage = "The CVO Org Code is required.")]
        [Display(Name = "CVO Org Code")]
        public string CvoOrgCode { get; set; }

        [Required(ErrorMessage = "The CVO Id is required.")]
        [Display(Name = "CVO Id")]
        public string CvoId { get; set; }

        [Required(ErrorMessage = "Whether Regular Maintenance Of Website Updation Done is required.")]
        [Display(Name = "Whether Regular Maintenance Of Website Updation Done")]
        public string WhetherRegularMaintenanceOfWebsiteUpdationDone { get; set; }

        [Required(ErrorMessage = "The System Introduced For Updation And Review is required.")]
        [Display(Name = "System Introduced For Updation And Review")]
        public string SystemIntroducedForUpdationAndReview { get; set; }

        [Required(ErrorMessage = "Whether Additional Areas, Activities, or Services Brought Online is required.")]
        [Display(Name = "Whether Additional Areas, Activities, or Services Brought Online")]
        public string WhetherAdditionalAreas_Activities_ServicesBroughtOnline { get; set; }

        [Required(ErrorMessage = "Details Of Additional Activities are required.")]
        [Display(Name = "Details Of Additional Activities")]
        public string DetailsOfAdditionalActivities { get; set; }
    }
}