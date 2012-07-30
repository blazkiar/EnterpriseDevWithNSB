using System.Globalization;
using System.Threading;
using log4net.Core;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.Integration.Azure;
using StructureMap;

namespace Cashier
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
            ObjectFactory.Initialize(x => x.AddRegistry(new CashierRegistry()));
        }

        private static void BootstrapNServiceBus()
        {
            Configure.With()
                .Log4Net()
                .StructureMapBuilder(ObjectFactory.Container)

                .AzureMessageQueue().JsonSerializer()
                .AzureSubcriptionStorage()
                .Sagas().AzureSagaPersister().NHibernateUnitOfWork()

                .UnicastBus()
                .LoadMessageHandlers()
                .IsTransactional(true)
                .CreateBus()
                .Start();
        }
    }
}
