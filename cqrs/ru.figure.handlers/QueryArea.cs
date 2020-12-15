using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ru.figure.handlers
{
    public class AreaQuery : IRequest<Double>
    {
        public Guid Id { get; set; }
    }

    public class AreaQueryHandler : IRequestHandler<AreaQuery, Double>
    {
        private IHandlersPort _handlersPort;
        public AreaQueryHandler(IHandlersPort handlersPort)
        {
            _handlersPort = handlersPort;
        }

        public async Task<Double> Handle(AreaQuery request, CancellationToken cancellationToken)
        {
            
            return await _handlersPort.GetAreaAsync(request.Id);
        }
    }
}
