using System.Threading.Tasks;
using Socca.FootballClub.Application.Models;

namespace Socca.FootballClub.Application.Interfaces
{
    public interface IFootballClubService
    {
        Task AssignToStadium(AssignToStadium assignToStadium);
    }
}
