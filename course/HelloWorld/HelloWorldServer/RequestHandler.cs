using log4net;
using Messages;
using NServiceBus;

namespace HelloWorldServer
{
    class RequestHandler : IHandleMessages<Request>
    {
        public RequestHandler(ISaySomething saySomething)
        {
            saysSomething = saySomething;
        }
        private ISaySomething saysSomething;

        public void Handle(Request message)
        {
            LogManager.GetLogger("RequestHandler").Info(message.SaySomething.Value);
            LogManager.GetLogger("RequestHandler").Info(saysSomething.InResponseTo(message.SaySomething.Value));
        }
    }
}
