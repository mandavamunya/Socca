using Socca.Domain.Core.Entities;

namespace Socca.PlayerTransfers.Domain.Entities
{
    public class PlayerTransfer: BaseEntity
    {
        public int FromTeam { get; set; }
        public int ToTeam { get; set; }
        public int PlayerId { get; set; }
    }
}
