using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace HepsiBurada.Simulator.Commands
{
    public class GetCampaignInfo : IRequest<Unit>
    {
        public string Name { get; set; }
        public GetCampaignInfo(IList<string> parameters)
        {
            this.Name = parameters[0];
        }
    }

    public class GetCampaignInfoHandler : IRequestHandler<GetCampaignInfo, Unit>
    {
        public async Task<Unit> Handle(GetCampaignInfo GetCampaignInfo, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("GetCampaignInfoHandler");
            return await Task.FromResult(Unit.Value);
        }

    }
}