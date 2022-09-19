using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //HELLOY WORLD!
            //routes.MapRoute(
            //    name: "HW",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "HW", action = "Index" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/",
                defaults: new { controller = "Dict", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
