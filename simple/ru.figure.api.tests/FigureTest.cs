using System.Text.Json;
using Xunit;

namespace ru.figure.api.tests
{
    public class FigureTest
    {
        [Fact]
        public void TestSerializeCircle()
        {
            var jsonString = "{\"Type\": \"Circle\", \"Circle\": {\"Radius\":100}}";
            var figure = JsonSerializer.Deserialize<Figure>(jsonString);
            Assert.False(figure.Circle == null);
            Assert.True(figure.Triangle == null);
            Assert.Equal(100, figure.Circle.Radius);

            Assert.Equal(31415.926535897932, figure.Area());
        }

        [Fact]
        public void TestSerializeTriangle()
        {
            var jsonString = "{\"Type\": \"Triangle\", \"Triangle\": {\"A\":100, \"B\":50, \"Angle\": 45}}";
            var figure = JsonSerializer.Deserialize<Figure>(jsonString);
            Assert.True(figure.Circle == null);
            Assert.False(figure.Triangle == null);
            Assert.Equal(100, figure.Triangle.A);
            Assert.Equal(50, figure.Triangle.B);
            Assert.Equal(45, figure.Triangle.Angle);
            Assert.Equal(3535.533905932738, figure.Area());
        }

    }
}
