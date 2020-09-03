using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Businness;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class IncreaseTimeCommandHAndler : IRequestHandler<IncreaseTimeCommand>
    {
        private readonly IMapper _mapper;
        private readonly ITimeService _timerService;
        public IncreaseTimeCommandHAndler(IMapper mapper,
            ITimeService timeService)
        {
            _mapper = mapper;
            _timerService = timeService;
        }
        public Task<Unit> Handle(IncreaseTimeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
