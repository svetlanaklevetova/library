using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyBooks.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: null, url: "", defaults: new { controller = "Home", action = "Index", genre = (string)null, bookPage = 1, authorPage=1 });

            //routes.MapRoute(
            //    name: null,
            //    url: "страница_книги{bookPage}/страница_автора{authorPage}",
            //    defaults: new { controller = "Home", action = "Index", genre = (string)null });

            routes.MapRoute(null, "{genre}", new { controller = "Home", action = "Index" });
            routes.MapRoute(
                name: "Auth",
                url: "{controller}/{action}/{author}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
