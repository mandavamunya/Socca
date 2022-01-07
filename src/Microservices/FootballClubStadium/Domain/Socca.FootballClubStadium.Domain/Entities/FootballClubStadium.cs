using Socca.Domain.Core.Entities;

namespace Socca.FootballClubStadium.Domain.Entities
{
    public class FootballClubStadium : BaseEntity
    {
        public FootballClubStadium()
        {
        }

        public FootballClubStadium(int footballClubId, int stadiumId)
        {
            FootballClubId = footballClubId;
            StadiumId = stadiumId;
        }

        public int FootballClubId { get; set; }
        public int StadiumId { get; set; }
    }
}
