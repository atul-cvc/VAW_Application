using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class VerifyOTPViewModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please enter OTP.")]
        [Display(Name = "Enter OTP :" )]
        [RegularExpression("([0-9]*)", ErrorMessage = "Entry should be Number.")]
        public string Otp { get; set; }
        public int NoOfAttempt { get; set; }
    }
}