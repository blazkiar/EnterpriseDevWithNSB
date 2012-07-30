using NServiceBus;
using log4net;

namespace HelloWorld
{
    public class EndpointConfig : IConfigureThisEndpoint, IWantToRunAtStartup
    {
        public void Run()
        {
            LogManager.GetLogger(GetType()).Info("Hello World!");
        }

        public void Stop()
        {
        }
    }
}
