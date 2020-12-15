using Newtonsoft.Json;
using ru.figure.bl;
using System;

namespace ru.figure.db
{
    public class DBFigurePort : IFigurePort
    {
        public bl.Figure Load(Guid id)
        {
            using (var db = new FigureContext())
            {
                var figure = db.Figures.Find(id);
                if (figure == null)
                    return null;
                return JsonConvert.DeserializeObject<bl.Figure>(figure.Data, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            }
        }

        public void Save(bl.Figure figure)
        {
            using (var db = new FigureContext())
            {
                db.Add(new db.Figure()
                {
                    Id = figure.Id,
                    Data = JsonConvert.SerializeObject(figure, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })
                });
                db.SaveChanges();
            }
        }
    }
}
