using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Messages;
using NServiceBus.Testing;
using NUnit.Framework;

namespace HelloWorld.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestRequestHandler()
        {
            Test.Initialize();

            Test.Handler<RequestWithResponseHandler>()
                .ExpectReturn<int>(i => i ==0)
                .OnMessage<RequestWithResponse>(m => m.SaySomething = "");
        }
    }
}
