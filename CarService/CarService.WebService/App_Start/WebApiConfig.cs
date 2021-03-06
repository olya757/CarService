﻿using System.Web.Http;

namespace CarService.WebService.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            
            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{Source}/{id}",
                defaults: new { id = RouteParameter.Optional, Source=1 }
            );
            
        }
    }
}
