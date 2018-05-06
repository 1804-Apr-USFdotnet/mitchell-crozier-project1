using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebClient
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

//           routes.MapRoute(
//                name: "Sort",
//                url: "{controller}/{action}/{search}",
//                defaults: new
//                {
//                    controller = "Restaurant",
//                    action = "SortByNameAscending",
//                    search = UrlParameter.Optional
//                }
//            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Restaurant",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
            

        }
    }
}
