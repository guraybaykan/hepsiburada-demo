using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Model;
using HepsiBurada.Core.Notifications;
using HepsiBurada.Core.Persistence;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class IncreaseTimeCommandHandler : IRequestHandler<IncreaseTimeCommand, Time>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ITimeRepository _timeRepository;
        public IncreaseTimeCommandHandler(IMapper mapper,
            IMediator mediator,
            ITimeRepository timeRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _timeRepository = timeRepository;
        }
        public async Task<Time> Handle(IncreaseTimeCommand request, CancellationToken cancellationToken)
        {
            var now = await _timeRepository.GetCurrentDate(cancellationToken);
            if (now is null)
            {
                now = new Core.Model.Time { TimeStamp = DateTime.Now };
                await _timeRepository.Save(now, cancellationToken); ;
                return now;
            }

            now.TimeStamp = now.TimeStamp.AddHours(request.Hour);
            await _timeRepository.Save(now, cancellationToken);

            await _mediator.Publish(new TimeIncreasedNotification
            {
                Now = now.TimeStamp
            });

            return now;
        }
    }
}
