using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;
using MediatR;

namespace HepsiBurada.Service.Queries
{
    public class GetCampaignInfoQueryHandler : IRequestHandler<GetCampaignInfoQuery, Campaign>
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        public GetCampaignInfoQueryHandler(IMapper mapper,
            ICampaignRepository campaignRepository)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
        }

        public async Task<Campaign> Handle(GetCampaignInfoQuery request, CancellationToken cancellationToken)
        {
            return await _campaignRepository.Get(request.Name, cancellationToken);
        }
    }
}
