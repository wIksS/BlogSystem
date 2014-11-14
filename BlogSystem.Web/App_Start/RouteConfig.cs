using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogSystem.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Page",
                url: "Page/{user}/{pageTitle}",
                defaults: new { controller = "Pages", action = "Index", user = "v@g.c"},
                namespaces: new string[] { "BlogSystem.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{user}/{id}",
                defaults: new { controller = "Posts", action = "Index", user="v@g.c",id = UrlParameter.Optional },
                namespaces:new string[] {"BlogSystem.Web.Controllers"}
            );
        }
    }
}
