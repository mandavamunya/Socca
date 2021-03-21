using System.Collections.Generic;

namespace Socca.Stadium.Application.Interfaces
{
    public interface IStadiumService
    {
        void AddStadium(Domain.Entities.Stadium stadium);
        IEnumerable<Domain.Entities.Stadium> GetStadiums();
    }
}
