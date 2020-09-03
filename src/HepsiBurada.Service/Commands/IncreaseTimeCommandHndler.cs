using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class IncreaseTimeCommandHAndler : IRequestHandler<IncreaseTimeCommand>
    {
        private readonly IMapper _mapper;
        public IncreaseTimeCommandHAndler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Task<Unit> Handle(IncreaseTimeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
