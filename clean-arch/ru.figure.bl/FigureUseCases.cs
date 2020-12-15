using System;

namespace ru.figure.bl
{
    public class FigureUseCases: IFigureUseCases
    {

        private readonly IFigurePort _figurePort;

        public FigureUseCases(IFigurePort figurePort)
        {
            _figurePort = figurePort;
        }

        public Guid Create(Figure figure)
        {
            figure.Id = Guid.NewGuid();
            _figurePort.Save(figure);
            return figure.Id;
        }

        public Double CalculateArea(Guid id)
        {
            var figure = _figurePort.Load(id);
            if (figure == null)
                throw new BusinessLogicException($"Figure {id} not found");
            return figure.Area();
        }
    }
}
