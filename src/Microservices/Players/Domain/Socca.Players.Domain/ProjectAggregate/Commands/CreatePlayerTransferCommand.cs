namespace Socca.Players.Domain.ProjectAggregate.Commands
{
    public class CreatePlayerTransferCommand : PlayerTransferCommand
    {
        public CreatePlayerTransferCommand(int from, int to, int playerId)
        {
            From = from;
            To = to;
            PlayerId = playerId;
        }
    }
}
