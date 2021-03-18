using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Lec03
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            // Donde se administra las rutas
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                // Aqui estamos dando el tipo de direccion de como se debe comportar
                routeTemplate: "api/{controller}/{id}",
                // Aqui recibe o busca la configuracion que va a utilizar
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
