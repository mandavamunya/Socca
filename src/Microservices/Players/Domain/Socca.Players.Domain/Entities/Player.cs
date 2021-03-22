namespace Socca.Players.Domain.Entities
{
    public class Player
    {
        public Player()
        {
        }
        public Player(string firstName, string lastName, string position)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
    }
}
