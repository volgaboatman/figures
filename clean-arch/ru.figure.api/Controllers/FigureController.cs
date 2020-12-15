using ru.figure.api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using ru.figure.bl;

namespace ru.figure.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FigureController : ControllerBase
    {
        private readonly IFigureUseCases _figureUseCases;

        public FigureController(IFigureUseCases figureUseCases)
        {
            _figureUseCases = figureUseCases;
        }

        [HttpPost]
        public ActionResult<IdResponse> Figure([FromBody] Figure figure)
        {
            // TODO По хорошему для этого надо сделать отдельный адаптер и даже тест для него
            bl.Figure entity;
            if (figure.Circle != null) entity = new bl.Circle() { Radius = figure.Circle.Radius };
            else if (figure.Triangle != null) entity = new bl.Triangle() { A = figure.Triangle.A, B = figure.Triangle.B, Angle = figure.Triangle.Angle };
            else throw new ArgumentException("Unknown type");

            return new IdResponse() { Id = _figureUseCases.Create(entity) };
        }

        [HttpGet("{id}")]
        public ActionResult<AreaResponse> Area(Guid id)
        {
            return new AreaResponse() { Area = _figureUseCases.CalculateArea(id) };
        }
    }
}
