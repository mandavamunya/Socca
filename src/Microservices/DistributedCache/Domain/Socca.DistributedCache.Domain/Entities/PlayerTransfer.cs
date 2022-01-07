using System;

namespace Socca.DistributedCache.Domain.Entities
{
    public class PlayerTransfer
    {
        public int FromTeam { get; set; }
        public int ToTeam { get; set; }
        public int PlayerId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
