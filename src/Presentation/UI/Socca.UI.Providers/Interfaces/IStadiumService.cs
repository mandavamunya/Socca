using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.UI.Providers.DTOs;

namespace Socca.UI.Providers.Interfaces
{
    public interface IStadiumService
    {
        Task<List<Stadium>> GetStadiums();
        Task<string> AddStadium(Stadium stadium);
    }
}
