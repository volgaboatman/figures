using System;

namespace ru.figure.bl
{
    public interface IFigurePort
    {
        void Save(Figure figure);
        Figure Load(Guid id);
    }
}
