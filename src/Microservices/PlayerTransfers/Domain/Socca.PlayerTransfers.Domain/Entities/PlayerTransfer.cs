namespace Socca.PlayerTransfers.Domain.Entities
{
    public class PlayerTransfer
    {
        public int Id { get; set; }
        public int FromTeam { get; set; }
        public int ToTeam { get; set; }
        public int PlayerId { get; set; }
        // Todo: public DateTime DateCreated { get; set;}
        // Todo: public bool IsCurrent { get; set; }
    }
}
