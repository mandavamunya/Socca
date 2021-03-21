using System.Collections.Generic;
using System.Threading.Tasks;

namespace Socca.Stadium.Domain.Interfaces
{
    public interface IStadiumRepository
    {
        Task<IEnumerable<Entities.Stadium>> GetStadium();
        Task Add(Entities.Stadium stadium);
    }
}
