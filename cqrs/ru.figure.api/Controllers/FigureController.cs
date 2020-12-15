using ru.figure.api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using MediatR;
using ru.figure.handlers;

namespace ru.figure.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FigureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FigureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult<IdResponse>> FigureAsync([FromBody] Figure figure)
        {
            // TODO А вот тут нужен хитрый маппер и может быть даже роутинг по командам
            // Т.е. сделать команду, которая просто берет фигуру как параметр, и потом перераспределяет ее по другим командам. Но для демонстрации идеи и так пойдет
            Guid id;
            if (figure.Circle != null)
                id = await _mediator.Send(new CreateCircleCommand()
                {
                    Radius = figure.Circle.Radius
                });
            else if (figure.Triangle != null)
                id = await _mediator.Send(new CreateTriangleCommand()
                {
                    A = figure.Triangle.A,
                    B = figure.Triangle.B,
                    Angle = figure.Triangle.Angle
                });
            else throw new ArgumentException("Unknown type");

            return new IdResponse() { Id = id };
        }

        [HttpGet("{id}")]
        public async System.Threading.Tasks.Task<ActionResult<AreaResponse>> AreaAsync(Guid id)
        {
            return new AreaResponse()
            {
                Area = await _mediator.Send(new AreaQuery() { Id = id })
            };
        }
    }
}
