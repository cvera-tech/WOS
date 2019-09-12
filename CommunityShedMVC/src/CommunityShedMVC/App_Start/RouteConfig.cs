using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CommunityShedMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Community",
            //    url: "c/{communityid}/{action}/{actionid}",
            //    defaults: new { controller = "Community", action = "Details", actionid = UrlParameter.Optional },
            //    constraints: new { });

            //routes.MapRoute(
            //    name: "Community",
            //    url: "Community/{communityid}/{controller}/{action}/{id}",
            //    defaults: new { action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
