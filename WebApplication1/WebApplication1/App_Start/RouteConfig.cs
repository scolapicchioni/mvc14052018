using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "age",
                url: "people/{age}",
                defaults: new { controller = "people", action = "GetPeopleByAge" },
                constraints: new { age = @"^\d?$" }
            );

            routes.MapRoute(
                name: "name",
                url: "people/name/{name}",
                defaults: new { controller = "people", action = "GetPeopleByName" }
            );

            //routes.MapRoute(
            //    name: "surname",
            //    url: "people/surname/{surname}",
            //    defaults: new { controller = "people", action = "GetPeopleBySurname" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
