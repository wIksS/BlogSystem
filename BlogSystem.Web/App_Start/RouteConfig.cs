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
                url: "{user}/Page/{pageTitle}",
                defaults: new {user="viktor",controller = "Pages", action = "Index"},
                namespaces: new string[] { "BlogSystem.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "api/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "BlogSystem.Web.Controllers" }
            );

            routes.MapRoute(
                name: "UserRoute",
                url: "{user}/{controller}/{action}/{id}",
                defaults: new { user="viktor",controller = "Posts", action = "Index",id = UrlParameter.Optional },
                namespaces:new string[] {"BlogSystem.Web.Controllers"}
            );
        }
    }
}
