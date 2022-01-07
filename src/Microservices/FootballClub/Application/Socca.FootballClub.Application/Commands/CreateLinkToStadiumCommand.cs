namespace Socca.FootballClub.Application.Commands
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
