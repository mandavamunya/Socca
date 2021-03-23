namespace Socca.FootballClubStadium.Domain.Entities
{
    public class FootballClubStadium
    {
        public FootballClubStadium()
        {
        }
        public FootballClubStadium(int footballClubId, int stadiumId)
        {
            FootballClubId = footballClubId;
            StadiumId = stadiumId;
        }

        public int Id { get; set; }
        public int FootballClubId { get; set; }
        public int StadiumId { get; set; }
        // Todo: public DateTime DateCreated { get; set;}
        // Todo: public bool IsCurrent { get; set; }

    }
}
