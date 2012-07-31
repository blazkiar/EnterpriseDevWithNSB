using NServiceBus;
using log4net;

namespace HelloWorld
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client {}
}
