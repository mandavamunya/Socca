using Socca.Domain.Core.Commands;

namespace Socca.FootballClub.Domain.Commands
{
    public abstract class LinkToStadiumCommand: Command
    {
        public int FootballClubId { get; set; }
        public int StadiumId { get; set; }
    }
}
