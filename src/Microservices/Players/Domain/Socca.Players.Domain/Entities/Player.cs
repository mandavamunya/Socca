using Socca.Domain.Core.Entities;

namespace Socca.Players.Domain.Entities
{
    public class Player: BaseEntity
    {
        public Player()
        {
        }
        public Player(string firstName, string lastName, string position, string image)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            Image = image;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
    }
}
