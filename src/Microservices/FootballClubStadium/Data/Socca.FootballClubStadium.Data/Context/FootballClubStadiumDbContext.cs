using Microsoft.EntityFrameworkCore;

namespace Socca.FootballClubStadium.Data.Context
{
    public class FootballClubStadiumDbContext: DbContext
    {
        public FootballClubStadiumDbContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Domain.Entities.FootballClubStadium> FootballClubStadiums { get; set; }
    }
}
