using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class Tran_2a_orgactivities_conductofcompetitions_ViewModel
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

        [Required(ErrorMessage = "Please enter name of State.")]
        [Display(Name = "Name of State")]
        public string NameOfState { get; set; }

        [Required(ErrorMessage = "Please enter name of City.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please select a program.")]
        [Display(Name = "Specific Program")]
        public string SpecificProgram { get; set; }

        [Required(ErrorMessage = "Please enter no. of participants.")]
        [Display(Name = "No of Participants")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Entry should be Number ")]
        public int NoOfParticipant { get; set; }

        [Required(ErrorMessage = "Please enter Remarks")]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
    }
}