using NServiceBus;
using NServiceBus.Config;
using NServiceBus.MessageMutator;
using NServiceBus.Unicast.Transport;

namespace MvcApplication1
{
    public class AuthenticationMutator : IMutateOutgoingTransportMessages, INeedInitialization
    {
        public void MutateOutgoing(object[] message, TransportMessage transportMessage)
        {
            transportMessage.Headers["user"] = "udi";
        }

        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<AuthenticationMutator>(DependencyLifecycle.InstancePerCall);
        }
    }
}