using Xunit;

namespace Socca.FootballClubStadium.UnitTests.DomainTests
{
    public class AddFootballClubStadium
    {
        private int _footballClubId = 3;
        private int _stadiumId = 4;

        [Fact]
        public void AddNewFootballClubStadium()
        {
            var footballClubStadium = new Domain.Entities.FootballClubStadium(_footballClubId, _stadiumId);
            Assert.Equal(_footballClubId, footballClubStadium.FootballClubId);
            Assert.Equal(_stadiumId, footballClubStadium.StadiumId);
        }
    }
}
