using Infrastructure.Services;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;

namespace Infrastructure.IoC
{
    public class InfrastructureRegistry: Registry
    {
        public InfrastructureRegistry(InfrastructureRegistryParameters configuration = null)
        {
            if (configuration == null)
            {
                configuration = new InfrastructureRegistryParameters
                {
                    LifeCycle = Lifecycles.ThreadLocal
                };
            }
            
            For<ILoginService>().Use<LoginService>();
            For<IUserService>().Use<UserService>();
        }
    }
}
