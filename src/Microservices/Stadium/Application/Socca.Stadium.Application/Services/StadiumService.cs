using System.Collections.Generic;
using Socca.Stadium.Application.Interfaces;

namespace Socca.Stadium.Application.Services
{
    public class StadiumService: IStadiumService
    {
        public StadiumService()
        {
        }

        public void AddStadium(Domain.Entities.Stadium stadium)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Domain.Entities.Stadium> GetStadiums()
        {
            throw new System.NotImplementedException();
        }
    }
}
