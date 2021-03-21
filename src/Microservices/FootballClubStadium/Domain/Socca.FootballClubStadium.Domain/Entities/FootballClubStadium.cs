namespace Socca.FootballClubStadium.Domain.Entities
{
    public class FootballClubStadium
    {
        public FootballClubStadium()
        {
        }
        public int Id { get; set; }
        public int FootballClubId { get; set; }
        public int StadiumId { get; set; }
    }
}
