using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class TokenModel
    {
        public string Email { get; set; }
        public string LoginType { get; set; }
        public string Pass { get; set; }
        public string OrgCode { get; set; }
        public string OrgName { get; set; }
    }
}