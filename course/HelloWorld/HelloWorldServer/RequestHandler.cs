using log4net;
using Messages;
using NServiceBus;

namespace HelloWorldServer
{
    class RequestHandler : IHandleMessages<Request>
    {
        public void Handle(Request message)
        {
            LogManager.GetLogger("RequestHandler").Info(message.SaySomething);
        }
    }
}
