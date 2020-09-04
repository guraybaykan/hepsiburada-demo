using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using HepsiBurada.Simulator.Model;
using System.Net.Http;

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
        private readonly HttpClient _client;
        public GetCampaignInfoHandler(HttpClient client)
        {
            _client = client;
        }

        public async Task<CommandResult> Handle(GetCampaignInfo GetCampaignInfo, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("GetCampaignInfoHandler");

            throw new NotImplementedException();
        }

    }
}