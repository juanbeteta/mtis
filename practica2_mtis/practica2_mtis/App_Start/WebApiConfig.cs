using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace practica2_mtis
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			RAML.WebApiExplorer.DocumentationProviderConfig.IncludeXmlComments();
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            config.Formatters.Add(new RAML.Api.Core.XmlSerializerFormatter());
			config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}