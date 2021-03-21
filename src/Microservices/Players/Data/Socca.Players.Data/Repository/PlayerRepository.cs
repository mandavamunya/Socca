using System.Collections.Generic;
using System.Threading.Tasks;
using Socca.Players.Domain.Entities;
using Socca.Players.Domain.Interfaces;

namespace Socca.Players.Data.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        public Task Add(Player player)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Player>> GetPlayer()
        {
            throw new System.NotImplementedException();
        }
    }
}
