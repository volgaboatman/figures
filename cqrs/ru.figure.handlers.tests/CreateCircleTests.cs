using Moq;
using System;
using Xunit;

namespace ru.figure.handlers.tests
{
    public class CreateCircleTests
    {
        [Fact]
        public async System.Threading.Tasks.Task CreateCircleCommandShouldCalcAreaAsync()
        {
            // Arrange
            var mock = new Mock<IHandlersPort>();
            var handler = new CreateCircleHandler(mock.Object);
            // Act
            await handler.Handle(new CreateCircleCommand() { Radius = 100 }, new System.Threading.CancellationToken());
            //Assert
            mock.Verify(repo => repo.SaveFigureAsync(It.IsAny<Guid>(), 31415.926535897932));
        }
    }
}
