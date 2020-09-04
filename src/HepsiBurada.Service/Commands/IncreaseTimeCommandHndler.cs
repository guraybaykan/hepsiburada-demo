using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Persistence;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class IncreaseTimeCommandHAndler : IRequestHandler<IncreaseTimeCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ITimeRepository _timeRepository;
        public IncreaseTimeCommandHAndler(IMapper mapper,
            IMediator mediator,
            ITimeRepository timeRepository)
        {
            _mapper = mapper;
            _mediator = mediator; 
            _timeRepository = timeRepository;
        }
        public async Task<Unit> Handle(IncreaseTimeCommand request, CancellationToken cancellationToken)
        {
            await _timeRepository.IncreaseDate(request.Hour, cancellationToken);

            //todo: mediator publish timeIncreased

            return Unit.Value;
        }
    }
}
