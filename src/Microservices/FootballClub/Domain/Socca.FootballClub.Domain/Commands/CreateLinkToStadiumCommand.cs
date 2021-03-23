namespace Socca.FootballClub.Domain.Commands
{
    public class CreateLinkToStadiumCommand: LinkToStadiumCommand
    {

        public CreateLinkToStadiumCommand(int footballClubId, int stadiumId)
        {
            FootballClubId = footballClubId;
            StadiumId = stadiumId;
        }
    }
}
