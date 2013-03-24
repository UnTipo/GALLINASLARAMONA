using CocheAmigos2.Handler;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CocheAmigos2
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "Default", // Nombre de ruta
            //    "{controller}/{action}/{id}", // URL con parámetros
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new UnencriptedRouteHandler()// Valores predeterminados de parámetro
            //);


            routes.Add(
    "Default",
    new Route("{controller}/{action}/{id}",// URL con parámetros
                new RouteValueDictionary(new { controller = "Home", action = "Index", id = UrlParameter.Optional }),// Valores predeterminados de parámetro
                new UnencriptedRouteHandler())
);

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Usar LocalDB para Entity Framework de manera predeterminada
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}