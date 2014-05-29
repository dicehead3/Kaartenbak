using System.Web.Http;
using System.Web.Mvc;
using Web.IoC;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Web.App_Start.Activator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.App_Start.Activator), "Stop")]

namespace Web.App_Start
{
    public static class Activator
    {
        public static void Start()
        {
            var resolver = new WebDependencyResolver();
            var dependencies = resolver.GetDependencies();

            DependencyResolver.SetResolver(dependencies.HttpDependencyResolver);
            GlobalConfiguration.Configuration.DependencyResolver = dependencies.HttpDependencyResolver;
        }

        public static void Stop()
        {
            
        }
    }
}