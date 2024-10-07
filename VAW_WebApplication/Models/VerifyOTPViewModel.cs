using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class VerifyOTPViewModel
    {
        [Required(ErrorMessage ="Please enter OTP")]
        [Display(Name ="Enter OTP : ")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Entry should be Number ")]
        public string OTP {  get; set; }
    }
}