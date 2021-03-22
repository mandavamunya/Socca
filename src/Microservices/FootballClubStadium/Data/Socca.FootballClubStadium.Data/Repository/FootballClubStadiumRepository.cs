using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Socca.FootballClubStadium.Data.Context;
using Socca.FootballClubStadium.Domain.Interfaces;

namespace Socca.FootballClubStadium.Data.Repository
{
    public class FootballClubStadiumRepository: IFootballClubStadiumRepository
    {
        private readonly FootballClubStadiumDbContext _context;
        public FootballClubStadiumRepository(FootballClubStadiumDbContext context)
        {
            _context = context;
        }

        public async Task Add(Domain.Entities.FootballClubStadium stadium)
        {
            await _context.AddAsync(stadium);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.FootballClubStadium>> Get()
        {
          return await _context.FootballClubStadiums.ToListAsync();
        }
    }
}
