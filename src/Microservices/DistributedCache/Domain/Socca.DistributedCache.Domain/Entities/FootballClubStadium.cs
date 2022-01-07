using System;

namespace Socca.DistributedCache.Domain.Entities
{

    public class FootballClubStadium
    {
        public int FootballClubId { get; set; } 
        public int StadiumId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
