using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace VAW_WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        //protected void Application_Error()
        //{
        //    Exception exception = Server.GetLastError();
        //    Response.Clear();
        //    Server.ClearError();
        //    // Log the exception (optional)
        //    // Redirect to the NotFound page
        //    Response.Redirect("/Error/NotFound");
        //}

    }
}
