using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAW_Models
{
    public class LoginModal
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string userLogin { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public string UserRole { get; set; }
        public string Section { get; set; }
        public string SOID { get; set; }
        public string BOID { get; set; }
        public string ASID { get; set; }
        public string SECID { get; set; }
        public string CVCID { get; set; }
        public string Email { get; set; }
        public int ChangePasswordFlag { get; set; }
        public string userActiveStatus { get; set; }
        public string MappedSection { get; set; }
    }
}
