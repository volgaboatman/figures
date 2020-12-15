using System;

namespace ru.figure.bl
{
    public interface IFigureUseCases
    {
        public Guid Create(Figure figure);

        public Double CalculateArea(Guid id);
    }
}
