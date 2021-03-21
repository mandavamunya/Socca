using System.Collections.Generic;
using Socca.Stadium.Domain.Interfaces;

namespace Socca.Stadium.Data.Repository
{
    public class StadiumRepository: IStadiumRepository
    {
        public StadiumRepository()
        {
        }

        public void Add(Domain.Entities.Stadium stadium)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Domain.Entities.Stadium> GetStadium()
        {
            throw new System.NotImplementedException();
        }
    }
}
