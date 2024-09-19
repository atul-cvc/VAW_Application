using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class Tran_3a_outreach_involvingschoolstudents_ViewModel
    {
        [Required(ErrorMessage = "Please enter year.")]
        [Display(Name = "VAW Year")]
        [RegularExpression(@"^(19|20)\d{2}$", ErrorMessage = "Entry should be a valid year (1900-2099)")]
        public string VAW_Year { get; set; }
        public string UniqueTransactionId { get; set; }
        public string CvoOrgCode { get; set; }
        public string CvoId { get; set; }

        [Required(ErrorMessage = "Choose From date.")]
        [Display(Name = "Date of Activity")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public string DateOfActivity { get; set; }

        [Required(ErrorMessage = "Please enter name of State.")]
        [Display(Name = "Name of State")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "Please enter name of City/Town/Village.")]
        [Display(Name = "Name of City/Town/Village")]
        public string City_Town_Village_Name { get; set; }

        [Required(ErrorMessage = "Please enter name of School.")]
        [Display(Name = "Name of School")]
        public string SchoolName { get; set; }

        [Required(ErrorMessage = "Please enter Activity Details.")]
        [Display(Name = "Details of Activities Conducted")]
        public string ActivityDetails { get; set; }

        [Required(ErrorMessage = "Please enter no. of students involved.")]
        [Display(Name = "No of Students Involved")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Entry should be Number ")]
        public int NoOfStudentsInvolved { get; set; }
    }
}