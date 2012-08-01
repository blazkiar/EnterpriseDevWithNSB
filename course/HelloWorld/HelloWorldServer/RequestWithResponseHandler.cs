using System.Threading;
using Messages;
using NServiceBus;

public class RequestWithResponseHandler : IHandleMessages<RequestWithResponse>
{
    public IBus Bus { get; set; }

    public void Handle(RequestWithResponse message)
    {
        Thread.Sleep(5000);
        Bus.Return(message.SaySomething.Value.Length % 2);
    }
}
