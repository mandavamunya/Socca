namespace Socca.Players.Domain.Entities
{
    public class Player
    {
        public Player()
        {
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
    }
}
