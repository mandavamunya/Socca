using System;
using Socca.Domain.Core.Events;

namespace Socca.Domain.Core.Commands
{
    public abstract class Command: Message
    {
        public DateTime Timestamp { get; protected set; }
        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
