using Socca.Domain.Core.Entities;

namespace Socca.FootballClub.Domain.Entities
{
    public class FootballClub : BaseEntity
    {
        public FootballClub()
        {
        }

        public FootballClub(string name, string location, string description, string image)
        {
            Name = name;
            Location = location;
            Description = description;
            Image = image;
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
