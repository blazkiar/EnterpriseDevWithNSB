using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace Messages
{
    public class Query : IMessage
    {
        public int NumberOfResponses { get; set; }
    }
}
