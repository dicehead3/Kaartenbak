using Infrastructure.Services;
using Infrastructure.Services.Login;
using Infrastructure.Services.User;
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
