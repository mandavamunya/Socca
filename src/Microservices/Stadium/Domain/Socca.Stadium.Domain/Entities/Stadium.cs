namespace Socca.Stadium.Domain.Entities
{
    public class Stadium
    {
        public Stadium()
        {
        }
        public Stadium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
