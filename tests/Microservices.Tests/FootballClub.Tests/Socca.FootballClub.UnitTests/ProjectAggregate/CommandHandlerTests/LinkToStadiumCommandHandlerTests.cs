using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using Socca.Domain.Core.Bus;
using Socca.FootballClub.Domain.ProjectAggregate.Commands;
using Socca.FootballClub.Domain.ProjectAggregate.Events;
using Xunit;
using Socca.FootballClub.Domain.ProjectAggregate.CommandHandlers;

namespace Socca.FootballClub.UnitTests.ProjectAggregate.CommandHandlerTests
{
    public class LinkToStadiumCommandHandlerTests
    {
        Mock<IEventBus> busMock;
        Mock<IConfiguration> configMock;

        public LinkToStadiumCommandHandlerTests()
        {
            busMock = new Mock<IEventBus>();
            configMock = new Mock<IConfiguration>();
        }

        private int footballClubId = 1;
        private int stadiumId = 2;

        [Fact]
        public void HandleTests()
        {
            var command = new CreateLinkToStadiumCommand(footballClubId: footballClubId, stadiumId: stadiumId);
            busMock.Setup(x => x.Publish(It.IsAny<LinkToStadiumCreatedEvent>(), It.IsAny<string>()));

            var commandHandler = new LinkToStadiumCommandHandler(busMock.Object, configMock.Object);
            var task = commandHandler.Handle(command, new CancellationToken());

            Assert.Equal(1, command.FootballClubId);
            Assert.Equal(2, command.StadiumId);
            Assert.True(command.Timestamp > new DateTime());

            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
        }
    }
}

