using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ru.figure.handlers
{
    public class CreateCircleCommand : IRequest<Guid>
    {
        public int Radius { get; set; }

    }

    public class CreateCircleHandler : IRequestHandler<CreateCircleCommand, Guid>
    {
        private IHandlersPort _handlersPort;
        public CreateCircleHandler(IHandlersPort handlersPort)
        {
            _handlersPort = handlersPort;
        }

        public async Task<Guid> Handle(CreateCircleCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            await _handlersPort.SaveFigureAsync(id, Math.PI * request.Radius * request.Radius);
            return id;
        }
    }
}
