namespace Socca.FootballClub.Domain.Entities
{
    public class FootballClub
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

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
