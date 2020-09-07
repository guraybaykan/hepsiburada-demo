using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Model;
using HepsiBurada.Core.Notifications;
using HepsiBurada.Core.Persistence;
using MediatR;

namespace HepsiBurada.Service.Queries
{
    public class GetCurrentTimeQueryHandler : IRequestHandler<GetCurrentTimeQuery, Time>
    {
        private readonly ITimeRepository _timeRpository;
        private readonly IMediator _mediator;

        public GetCurrentTimeQueryHandler(ITimeRepository timeRpository,
            IMediator mediator)
        {
            _mediator = mediator;
            _timeRpository = timeRpository;
        }
        public async Task<Time> Handle(GetCurrentTimeQuery request, CancellationToken cancellationToken)
        {
            var now = await _timeRpository.GetCurrentDate(cancellationToken);
            if (now is null)
            {
                await _mediator.Publish(new CreateTimeNotification());
                now = await _timeRpository.GetCurrentDate(cancellationToken);
            }
            return now;
        }
    }
}