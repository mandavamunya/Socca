using System.Collections.Generic;

namespace Socca.Stadium.Domain.Interfaces
{
    public interface IStadiumRepository
    {
        IEnumerable<Entities.Stadium> GetStadium();
        void Add(Entities.Stadium stadium);
    }
}
