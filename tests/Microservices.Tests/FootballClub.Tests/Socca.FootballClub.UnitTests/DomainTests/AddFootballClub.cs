using Xunit;

namespace Socca.FootballClub.UnitTests.DomainTests
{
    public class AddFootballClub
    {
        private string _name = "Arsenal";
        private string _location = "London Borough of Islington, London, United Kingdom";

        [Fact]
        public void AddNewFootballClub()
        {
            var footballClub = new Domain.Entities.FootballClub(_name, _location);
            Assert.Equal(_name, footballClub.Name);
            Assert.Equal(_location, footballClub.Location);
        }
    }
}
