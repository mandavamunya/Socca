using Microsoft.EntityFrameworkCore;
using Socca.PlayerTransfers.Domain.Entities;

namespace Socca.PlayerTransfers.Data.Context
{
    public class PlayerTransferDbContext: DbContext
    {
        public PlayerTransferDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PlayerTransfer> PlayerTransfers { get; set; }
    }
}
