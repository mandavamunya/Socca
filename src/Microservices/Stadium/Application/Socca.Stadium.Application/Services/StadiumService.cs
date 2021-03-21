using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.Stadium.Application.Interfaces;

namespace Socca.Stadium.Application.Services
{
    public class StadiumService: IStadiumService
    {
        public StadiumService()
        {
        }

        public Task AddStadium(Domain.Entities.Stadium stadium)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Domain.Entities.Stadium>> GetStadiums()
        {
            throw new System.NotImplementedException();
        }
    }
}
