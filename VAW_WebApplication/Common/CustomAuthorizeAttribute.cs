using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace VAW_WebApplication.Common
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }


            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult( new System.Web.Routing.RouteValueDictionary     {
                { "controller", "Account" },
                { "action", "Denied" }
            });
                
                //filterContext.Result = new RedirectResult("~/Account/Denied");
            }
        }


    }
        

}