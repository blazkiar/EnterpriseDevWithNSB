using System;
using Messages;
using NServiceBus;

namespace Server
{
    public class DeferredMessageHandler : IHandleMessages<DeferredMessage>
    {
        public void Handle(DeferredMessage message)
        {
            Console.WriteLine(string.Format("{0} - {1}", DateTime.Now.ToLongTimeString(), "Deferred message processed"));
        }
    }
}