using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using HepsiBurada.Simulator.Model;

namespace HepsiBurada.Simulator.Commands
{
    public class GetCampaignInfo : IRequest<CommandResult>
    {
        public string Name { get; set; }
        public GetCampaignInfo(IList<string> parameters)
        {
            this.Name = parameters[0];
        }
    }

    public class GetCampaignInfoHandler : IRequestHandler<GetCampaignInfo, CommandResult>
    {
        public async Task<CommandResult> Handle(GetCampaignInfo GetCampaignInfo, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("GetCampaignInfoHandler");
            throw new NotImplementedException();
        }

    }
}