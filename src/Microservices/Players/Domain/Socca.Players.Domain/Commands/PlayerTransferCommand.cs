using Socca.Domain.Core.Commands;

namespace Socca.Players.Domain.Commands
{

    public abstract class PlayerTransferCommand : Command
    {
        public int From { get; protected set; }
        public int To { get; protected set; }
        public int PlayerId { get; protected set; }
    }
}
