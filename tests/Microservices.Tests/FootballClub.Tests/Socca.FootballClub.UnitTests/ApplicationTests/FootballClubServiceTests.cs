using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Socca.FootballClub.Application.Interfaces;
using Socca.FootballClub.Domain.Interfaces;
using Xunit;

namespace Socca.FootballClub.UnitTests.ApplicationTests
{
    public class FootballClubServiceTests
    {

        private Mock<IFootballClubRepository> _mockRepo;
        private Mock<IFootballClubService> _mockService;
        public FootballClubServiceTests()
        {
            _mockRepo = new Mock<IFootballClubRepository>();
            _mockService = new Mock<IFootballClubService>();


        }

    }
}
