using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Businness;
using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Campaign>
    {
        private readonly IMapper _mapper;
        private readonly ICampaignService _campaignService;
        public CreateCampaignCommandHandler(IMapper mapper,
                    ICampaignService campaignService)
        {
            _mapper = mapper;
            _campaignService = campaignService;
        }
        public Task<Campaign> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
