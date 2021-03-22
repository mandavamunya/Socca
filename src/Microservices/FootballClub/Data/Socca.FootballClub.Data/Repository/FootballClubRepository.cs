using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Socca.FootballClub.Data.Context;
using Socca.FootballClub.Domain.Interfaces;

namespace Socca.FootballClub.Data.Repository
{
    public class FootballClubRepository: IFootballClubRepository
    {
        private readonly FootballClubDbContext _context;
        public FootballClubRepository(FootballClubDbContext context)
        {
            _context = context;
        }

        public async Task Add(Domain.Entities.FootballClub footballClub)
        {
            await _context.AddAsync(footballClub);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.FootballClub>> Get()
        {
            return await _context.FootballClubs.ToListAsync();
        }
    }
}
