using NServiceBus;

namespace HelloWorldQueryServer
{
    public class EndpointConfig: IConfigureThisEndpoint, AsA_Client, IWantCustomInitialization
    {
        public void Init()
        {
            NServiceBus.Configure.With()
                .DefaultBuilder()
                .XmlSerializer("http://acme.com");
        }
    }
}
