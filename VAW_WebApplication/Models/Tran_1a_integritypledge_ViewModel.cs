using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class Tran_1a_integritypledge_ViewModel
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
        public DateTime DateOfActivity { get; set; }

        [Display(Name = "Total No Of Employees Undertaken Pledge")]
        [Required(ErrorMessage = "Enter Total No of Employees Undertaken Pledge")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Entry should be Number ")]
        public int TotalNoOfEmployees_UndertakenPledge { get; set; }

        [Display(Name = "Total No Of Customers Undertaken Pledge")]
        [Required(ErrorMessage = "Enter Total No of Customers Undertaken Pledge")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Entry should be Number ")]
        public int TotalNoOfCustomers_UndertakenPledge { get; set; }

        [Display(Name = "Total No Of Citizens Undertaken Pledge")]
        [Required(ErrorMessage = "Enter Total No of Citizens Undertaken Pledge")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Entry should be Number ")]
        public int TotalNoOfCitizen_UndertakenPledge { get; set; }
    }
}