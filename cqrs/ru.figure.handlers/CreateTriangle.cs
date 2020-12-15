using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ru.figure.handlers
{
    public class CreateTriangleCommand : IRequest<Guid>
    {
        public int A { get; set; }
        public int B { get; set; }
        public int Angle { get; set; }
    }

    public class CreateTriangleHandler : IRequestHandler<CreateTriangleCommand, Guid>
    {
        private IHandlersPort _handlersPort;
        public CreateTriangleHandler(IHandlersPort handlersPort)
        {
            _handlersPort = handlersPort;
        }

        public async Task<Guid> Handle(CreateTriangleCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            await _handlersPort.SaveFigureAsync(id, Math.Sin(Math.PI * request.Angle / 180) * request.A * request.B);
            return id;
        }
    }
}
