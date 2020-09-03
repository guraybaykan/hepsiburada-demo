using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Queries
{
    public class GetCampaignInfoQueryHandler : IRequestHandler<GetCampaignInfoQuery, Campaign>
    {
        private readonly IMapper _mapper;
        public GetCampaignInfoQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<Campaign> Handle(GetCampaignInfoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
