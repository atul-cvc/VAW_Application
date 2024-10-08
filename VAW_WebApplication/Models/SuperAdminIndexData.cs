using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VAW_WebApplication.Models
{
    public class SuperAdminIndexData
    {   
        public List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> AllRoles { get; set; }
        public List<Users_in_Role_ViewModel> AllUserList { get; set; }

        public SuperAdminIndexData()
        {
            AllRoles=new List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>();
            AllUserList=new List<Users_in_Role_ViewModel>();
        }
    }
}