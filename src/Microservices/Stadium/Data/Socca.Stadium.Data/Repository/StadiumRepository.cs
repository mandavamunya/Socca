using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Socca.Stadium.Data.Context;
using Socca.Stadium.Domain.Interfaces;

namespace Socca.Stadium.Data.Repository
{
    public class StadiumRepository: IStadiumRepository
    {
        private readonly StadiumDbContext _context;
        public StadiumRepository(StadiumDbContext context)
        {
            _context = context;
        }

        public async Task Add(Domain.Entities.Stadium stadium)
        {
            await _context.AddAsync(stadium);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Stadium>> GetStadium()
        {
            return await _context.Stadiums.ToListAsync();
        }
    }
}
