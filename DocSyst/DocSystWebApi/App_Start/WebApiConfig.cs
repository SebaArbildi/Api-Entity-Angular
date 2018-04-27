using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystDependencyResolver;
using System;
using System.Configuration;
using System.Web.Http;
using Unity;


namespace DocSystWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();

#if DEBUG
            ComponentLoader.LoadContainer(container, AppDomain.CurrentDomain.BaseDirectory + @"..\DocSystBusinessLogicImplementation\bin\Debug\", "*.dll");
            ComponentLoader.LoadContainer(container, AppDomain.CurrentDomain.BaseDirectory + @"..\DocSystDataAccessImplementation\bin\Debug\", "*.dll");
#else
            ComponentLoader.LoadContainer(container, ConfigurationManager.AppSettings["LogicAssemblyPath"], "*.dll");

#endif

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Controllers with Actions

        }
    }
}
