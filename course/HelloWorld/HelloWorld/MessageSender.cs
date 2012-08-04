using log4net;
using Messages;
using NServiceBus;

namespace HelloWorld
{
    class MessageSender : IWantToRunAtStartup
    {
        public IBus Bus { get; set; }

        public void Run()
        {
            var message = new Request { SaySomething = "Say something" };
            Bus.Send(message);
            LogManager.GetLogger("helloWorldServer", "MessageSender").Info("Sent message.");
        }

        public void Stop()
        {

        }
    }
}

