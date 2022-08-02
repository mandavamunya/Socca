using Socca.Domain.Core.Events;

namespace Socca.Players.Domain.Events
{
    public class PlayerTransferCreatedEvent: Event
    {
        public int From { get; private set; }
        public int To { get; private set; }
        public int PlayerId { get; private set; }


        public PlayerTransferCreatedEvent(int from, int to, int playerId)
        {
            From = from;
            To = to;
            PlayerId = playerId;
        }
    }
}
