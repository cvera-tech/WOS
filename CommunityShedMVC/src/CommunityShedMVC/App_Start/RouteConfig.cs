using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
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

            routes.MapRoute(
                name: "Community",
                url: "Community/{communityid}/{action}",
                defaults: new { controller = "Community", action = "Details" },
                constraints: new { communityid = new IntRouteConstraint() }
            );

            //routes.MapRoute(
            //    name: "Community",
            //    url: "Community/{communityid}/{controller}/{action}/{id}",
            //    defaults: new { controller = "Community", action = "Details", id = UrlParameter.Optional },
            //    constraints: new { communityid = new IntRouteConstraint() }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
