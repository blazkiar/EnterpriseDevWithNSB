using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace HelloWorldServer
{
    public class EndpointConfig: IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            NServiceBus.Configure.With()
                .DefaultBuilder()
                .XmlSerializer("http://acme.com");
        }
    }
}
