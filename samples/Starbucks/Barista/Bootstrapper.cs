using NServiceBus;
using StructureMap;

namespace Barista
{
    public class Bootstrapper
    {
        private Bootstrapper()
        {}

        public static void Bootstrap()
        {
            BootstrapStructureMap();
            BootstrapNServiceBus();
        }

        private static void BootstrapStructureMap()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new BaristaRegistry()));
        }
       
        private static void BootstrapNServiceBus()
        {
            Configure.With()
                .Log4Net()
                .StructureMapBuilder(ObjectFactory.Container)
                .RunTimeoutManagerWithInMemoryPersistence()
                .MsmqSubscriptionStorage()
                .XmlSerializer()
                // For sagas
                .Sagas()
                .InMemorySagaPersister()
                //.RavenSagaPersister()
                // End
                .MsmqTransport()
                    .IsTransactional(true)
                    .PurgeOnStartup(false)
                .UnicastBus()
                    .ImpersonateSender(false)
                    .LoadMessageHandlers()
                .CreateBus()
                .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());
        }
    }
}
