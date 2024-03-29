﻿using System.Web.Mvc;
using System.Web.Routing;

namespace InvoiceMaker.Initialization
{
    public static class RouteConfiguration
    {
        public static void AddRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Invoices",
                    action = "Index",
                    id = UrlParameter.Optional
                });
        }
    }
}