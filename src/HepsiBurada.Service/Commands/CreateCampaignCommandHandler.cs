using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Campaign>
    {
        private readonly IMapper _mapper;
        public CreateCampaignCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Task<Campaign> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
