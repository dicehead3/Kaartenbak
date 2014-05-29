using Infrastructure.IoC;
using StructureMap;

namespace Web.IoC
{
    public sealed class WebDependencyResolver
    {
        private IContainer Container { get; set; }

        public WebDependencyResolver()
        {
            Container = new Container(config =>
            {
                config.AddRegistry(new InfrastructureRegistry());

                config.AddRegistry(new UtilitiesRegistry());

                config.AddRegistry<DomainRegistry>();

                config.AddRegistry<WebRegistry>();
            });
        }

        public WebDependencies GetDependencies()
        {
            return Container.GetInstance<WebDependencies>();
        }
    }
}