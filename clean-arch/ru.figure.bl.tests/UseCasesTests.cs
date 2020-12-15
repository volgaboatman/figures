using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ru.figure.bl.tests
{
    public class UseCasesTests
    {
        [Fact]
        public void CreateAndCalculateTest()
        {
            var cases = new FigureUseCases(new TestFigurePort());
            var id = cases.Create(new Circle() { Radius = 100 });
            var area = cases.CalculateArea(id);
            Assert.Equal(31415.926535897932, area);
        }

        [Fact]
        public void NotFoundTest()
        {
            var cases = new FigureUseCases(new TestFigurePort());
            var id = Guid.NewGuid();
            Assert.Throws<BusinessLogicException>(() => cases.CalculateArea(id));
        }
    }

    class TestFigurePort : IFigurePort
    {
        private List<Figure> _figures = new List<Figure>();
        public Figure Load(Guid id)
        {
            return _figures.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Save(Figure figure)
        {
            _figures.Add(figure);
        }
    }
}
