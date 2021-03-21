using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.Stadium.Domain.Interfaces;

namespace Socca.Stadium.Data.Repository
{
    public class StadiumRepository: IStadiumRepository
    {
        public StadiumRepository()
        {
        }

        public Task Add(Domain.Entities.Stadium stadium)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Domain.Entities.Stadium>> GetStadium()
        {
            throw new System.NotImplementedException();
        }
    }
}
