using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EDSNCalendar_ProjectBlue
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "RemoveUserRoute",
                "Admin/RemoveUser/{s}",
                new { controller = "Admin", action = "RemoveUser" });

            routes.MapRoute(
                "ConfirmRemoveUserRoute",
                "Admin/ConfirmRemoveUser/{s}",
                new { controller = "Admin", action = "ConfirmRemoveUser", s = UrlParameter.Optional });

            routes.MapRoute(
                "EventsListFilter",
                "Admin/EventList/{published}",
                new { controller = "Admin", action = "EventList" },
                new { published = "All|Submitted|Published" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Calendar", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
