using System;
using System.Threading.Tasks;

namespace ru.figure.handlers
{
    public interface IHandlersPort
    {
        Task SaveFigureAsync(Guid id, Double area);

        Task<Double> GetAreaAsync(Guid id);
    }
}
