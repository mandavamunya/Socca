using Microsoft.EntityFrameworkCore;

namespace Socca.FootballClub.Data.Context
{
    public class FootballClubDbContext : DbContext
    {
        public FootballClubDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Domain.Entities.FootballClub> FootballClubs { get; set; }
    }
}
