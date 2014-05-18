using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;
using Utilities.ApplicationSettings;
using Utilities.Encryption;
using Utilities.Policies;

namespace Infrastructure.IoC
{
    public class UtilitiesRegistry: Registry
    {
        public UtilitiesRegistry(UtilitiesRegistryParameters configuration = null)
        {
            if (configuration == null)
            {
                configuration = new UtilitiesRegistryParameters
                {
                    LifeCycle = Lifecycles.ThreadLocal
                };
            }

            For<IApplicationSettings>().Use<ApplicationSettings>();
            For<IStaticApplicationSettings>().Use<StaticApplicationSettings>();

            For<IEncryptor>().LifecycleIs(configuration.LifeCycle).Use<Encryptor>();

            For<IPasswordPolicy>().Use<PasswordPolicy>();
        }
    }
}
