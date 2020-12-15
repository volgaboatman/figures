using Xunit;

namespace ru.figure.bl.tests
{
    public class FigureTests
    {
        [Fact]
        public void CircleTest()
        {
            var figure = new Circle() { Radius = 100 };
            Assert.Equal(31415.926535897932, figure.Area());
        }

        [Fact]
        public void TriangleTest()
        {
            var figure = new Triangle() { A = 100, B = 50, Angle = 45 };
            Assert.Equal(3535.533905932738, figure.Area());
        }

    }
}
