using ru.figure.handlers;
using System;
using System.Threading.Tasks;

namespace ru.figure.db
{
    public class DBHandlersPort : IHandlersPort
    {
        public async Task<Double> GetAreaAsync(Guid id)
        {
            using (var db = new FigureContext())
            {
                var figure = await db.Figures.FindAsync(id);
                if (figure == null)
                    throw new BusinessLogicException($"Figure {id} not found");
                return figure.Area;
            }
        }

        public async Task SaveFigureAsync(Guid id, double area)
        {
            using (var db = new FigureContext())
            {
                db.Add(new db.Figure()
                {
                    Id = id,
                    Area = area
                });
                await db.SaveChangesAsync();
            }
        }
    }
}
