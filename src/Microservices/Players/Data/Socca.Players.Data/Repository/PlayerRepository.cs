using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Socca.Players.Data.Context;
using Socca.Players.Domain.Entities;
using Socca.Players.Domain.Interfaces;

namespace Socca.Players.Data.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly PlayerDbContext _context;
        public PlayerRepository(PlayerDbContext context)
        {
            _context = context;
        }

        public async Task Add(Player player)
        {
            await _context.AddAsync(player);
        }

        public async Task<IEnumerable<Player>> Get()
        {
            return await _context.Players.ToListAsync();
        }
    }
}
