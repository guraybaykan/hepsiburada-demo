using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Businness;
using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Queries
{
    public class GetCampaignInfoQueryHandler : IRequestHandler<GetCampaignInfoQuery, Campaign>
    {
        private readonly IMapper _mapper;
        private readonly ICampaignService _campaignService;
        public GetCampaignInfoQueryHandler(IMapper mapper,
            ICampaignService campaignService)
        {
            _mapper = mapper;
            _campaignService = campaignService;
        }

        public Task<Campaign> Handle(GetCampaignInfoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
