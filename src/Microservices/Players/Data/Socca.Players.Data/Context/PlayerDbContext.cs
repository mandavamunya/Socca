using Microsoft.EntityFrameworkCore;
using Socca.Players.Domain.Entities;

namespace Socca.Players.Data.Context
{
    public class PlayerDbContext : DbContext
    {
        public PlayerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; } 
    }
}
