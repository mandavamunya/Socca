namespace Socca.FootballClub.Domain.Entities
{
    public class FootballClub
    {
        public FootballClub()
        {
        }
        public FootballClub(string name, string location)
        {
            Name = name;
            Location = location;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
