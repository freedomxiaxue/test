using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace tcpjw3.oa
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "SuperDog",
                routeTemplate: "api/{controller}/{action}/{*p}",
                defaults: new { p = RouteParameter.Optional });
        }
    }
}