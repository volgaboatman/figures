using Moq;
using System;
using Xunit;

namespace ru.figure.handlers.tests
{
    public class CreateTriangleTest
    {
        [Fact]
        public async System.Threading.Tasks.Task CreateCircleCommandShouldCalcAreaAsync()
        {
            // Arrange
            var mock = new Mock<IHandlersPort>();
            var handler = new CreateTriangleHandler(mock.Object);
            // Act
            await handler.Handle(new CreateTriangleCommand() { A = 100, B = 50, Angle = 45 }, new System.Threading.CancellationToken());
            //Assert
            mock.Verify(repo => repo.SaveFigureAsync(It.IsAny<Guid>(), 3535.533905932738));
        }
    }
}
