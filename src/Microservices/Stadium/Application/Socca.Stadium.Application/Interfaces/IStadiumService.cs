using System.Collections.Generic;
using System.Threading.Tasks;

namespace Socca.Stadium.Application.Interfaces
{
    public interface IStadiumService
    {
        Task AddStadium(Domain.Entities.Stadium stadium);
        Task<IEnumerable<Domain.Entities.Stadium>> GetStadiums();
    }
}
