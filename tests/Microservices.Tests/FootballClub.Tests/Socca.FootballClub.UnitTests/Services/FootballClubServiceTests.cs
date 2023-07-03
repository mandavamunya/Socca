using System;
using System.Collections.Generic;
using Moq;
using Socca.Domain.Core.Bus;
using Socca.Domain.Core.Interfaces;
using Socca.FootballClub.Domain.ProjectAggregate.Specifications;
using Socca.FootballClub.Domain.Services;
using Xunit;

namespace Socca.FootballClub.UnitTests.Services
{
    public class FootballClubServiceTests
    {
        Mock<IAsyncRepository<Domain.Entities.FootballClub>> _mockIAsyncRepository;
        Mock<IEventBus> _mockBus;

        public FootballClubServiceTests()
        {
            _mockIAsyncRepository = new Mock<IAsyncRepository<Domain.Entities.FootballClub>>();
            _mockBus = new Mock<IEventBus>();
        }

        [Theory, MemberData(nameof(FootballName_FootballClub_List))]
        public void GetFootballClubByName_Test(int id, Domain.Entities.FootballClub footballClub)
        {
         
            _mockIAsyncRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(footballClub);
            var service = new FootballClubService(_mockIAsyncRepository.Object, _mockBus.Object);
            var task = service.Get(id);

            Assert.NotNull(task);

            if (id == 0)
            {
                Assert.Null(task.Result);
            }
            else
            {
                Assert.Equal(footballClub.Name, task.Result.Name);
                Assert.Equal(footballClub.Location, task.Result.Location);
                Assert.Equal(footballClub.Description, task.Result.Description);
                Assert.Equal(footballClub.Image, task.Result.Image);
            }
        }

        public static IEnumerable<object[]> FootballName_FootballClub_List
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        0, null
                    },
                    new object[]
                    {
                         1, new Domain.Entities.FootballClub(string.Empty, string.Empty, string.Empty, string.Empty)
                    }

                };
            }
        }

    }

}

