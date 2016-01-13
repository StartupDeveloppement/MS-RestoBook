using LowercaseRoutesMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RestoBook
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRouteLowercase(
            //    name: "SearchVille",
            //    url: "Restaurant/{action}/Ville/{search}",
            //    defaults: new { controller = "Restaurant", action = "Lister", search = UrlParameter.Optional }
            //);

            //routes.MapRouteLowercase(
            //    name: "SearccC",
            //    url: "Restaurant/{search}/{action}",
            //    defaults: new { controller = "Restaurant", action = "Lister", search = UrlParameter.Optional }
            //);

            routes.MapRouteLowercase(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
