using Newtonsoft.Json;
using ru.figure.bl;
using System;
using Xunit;

namespace ru.figure.db.tests
{
    public class SerializeTest
    {
        // Немного не правильно, но тут должны быть тесты именно логики преобразования фигуры в DB-формат и для этого надо хитрый сервис делать. 
        [Fact]
        public void SerializeCircleTest()
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            Figure figure = new Circle() { Id = Guid.NewGuid(), Radius = 10 };
            var json = JsonConvert.SerializeObject(figure, settings);
            Figure back = JsonConvert.DeserializeObject<Figure>(json, settings);

            Assert.True(back is Circle);
            var circle = back as Circle;
            Assert.Equal(figure.Id, circle.Id);
            Assert.Equal(10, circle.Radius);
        }

        [Fact]
        public void SerializeTriangleTest()
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            Figure figure = new Triangle() { Id = Guid.NewGuid(), A = 10, B = 20, Angle = 30 };
            var json = JsonConvert.SerializeObject(figure, settings);
            Figure back = JsonConvert.DeserializeObject<Figure>(json, settings);

            Assert.True(back is Triangle);
            var triangle = back as Triangle;
            Assert.Equal(figure.Id, triangle.Id);
            Assert.Equal(10, triangle.A);
            Assert.Equal(20, triangle.B);
            Assert.Equal(30, triangle.Angle);
        }
    }
}
