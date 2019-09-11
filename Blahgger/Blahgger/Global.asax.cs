using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Blahgger
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Add global filters
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
            GlobalFilters.Filters.Add(new System.Web.Mvc.AuthorizeAttribute());
        }
        
        //protected void Application_OnPostAuthenticateRequest()
        //{
        //    IPrincipal user = HttpContext.Current.User;

        //    if (user.Identity.IsAuthenticated)
        //    {
        //        FormsIdentity formsIdentity = (FormsIdentity)user.Identity;
        //        FormsAuthenticationTicket ticket = formsIdentity.Ticket;

        //    }
        //}
    }
}
