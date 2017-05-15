using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PLCv4XFiles
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();



            //  defaults: new { controller = "z_PLC_Device", action = "z_PLC_Device", id = RouteParameter.Optional }
            // defaults: new { id = RouteParameter.Optional }
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",

              
                  defaults: new { id = RouteParameter.Optional }


            );
        }
    }
}
