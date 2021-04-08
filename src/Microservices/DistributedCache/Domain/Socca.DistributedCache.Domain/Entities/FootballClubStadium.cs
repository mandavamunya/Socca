namespace Socca.DistributedCache.Domain.Entities
{

    // either FootballClubId or StadiumId
    public class FootballClubStadium
    {
        public int Id { get; set; }
        public int FootballClubId { get; set; } // Key
        public int StadiumId { get; set; } // Key
    }
}
