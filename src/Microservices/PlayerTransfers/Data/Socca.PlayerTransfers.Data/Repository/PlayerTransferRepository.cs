using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Socca.PlayerTransfers.Data.Context;
using Socca.PlayerTransfers.Domain.Entities;
using Socca.PlayerTransfers.Domain.Interfaces;

namespace Socca.PlayerTransfers.Data.Repository
{
    public class PlayerTransferRepository: IPlayerTransferRepository
    {
        private readonly PlayerTransferDbContext _context;
        public PlayerTransferRepository(PlayerTransferDbContext context)
        {
            _context = context;
        }

        public async Task Add(PlayerTransfer playerTransfer)
        {
            await _context.AddAsync(playerTransfer);
            await _context.SaveChangesAsync(); ;
        }

        public async Task<IEnumerable<PlayerTransfer>> Get()
        {
            return await _context.PlayerTransfers.ToListAsync();
        }

        public async Task Update(PlayerTransfer playerTransfer)
        {
            _context.PlayerTransfers.Update(playerTransfer);
            await _context.SaveChangesAsync();
        }
    }
}
