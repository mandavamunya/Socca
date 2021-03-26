namespace Socca.Players.Application.Commands
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
