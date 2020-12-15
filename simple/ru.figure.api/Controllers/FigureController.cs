using ru.figure.db;
using ru.figure.api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace ru.figure.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FigureController : ControllerBase
    {
        [HttpPost]
        public ActionResult<IdResponse> Figure([FromBody] Figure figure)
        {
            var id = Guid.NewGuid();
            using (var db = new FigureContext())
            {
                db.Add(new db.Figure() { Id = id, Data = JsonSerializer.Serialize(figure) });
                db.SaveChanges();
            }
            return new IdResponse() { Id = id };
        }

        [HttpGet("{id}")]
        public ActionResult<AreaResponse> Area(Guid id)
        {
            using (var db = new FigureContext())
            {
                var figure = db.Figures.Find(id);
                var model = JsonSerializer.Deserialize<Figure>(figure.Data);
                return new AreaResponse() { Area = model.Area() };
            }
        }
    }
}
