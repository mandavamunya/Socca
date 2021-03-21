using Microsoft.EntityFrameworkCore;

namespace Socca.Stadium.Data.Context
{
    public class StadiumDbContext: DbContext
    {
        public StadiumDbContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Domain.Entities.Stadium> Stadiums { get; set; }
    }
}
