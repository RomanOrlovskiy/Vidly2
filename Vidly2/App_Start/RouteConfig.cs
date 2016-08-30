using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Attribute routes.
            //Anable attribute routes.
            routes.MapMvcAttributeRoutes();

            //Custom route.
            //The order of the routes matters. 
            //Define from the most specific to most generic
            //routes.MapRoute(
            //    name: "MoviesByReleaseDate",
            //    url:  "movies/released/{year}/{month}",
            //    defaults: new { controller = "Movies", action = "ByReleaseDate" },
            //    constraints: new {year = @"2015|2016", month = @"\d{2}"}
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
