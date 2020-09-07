using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using HepsiBurada.Simulator.Model;
using System.Net.Http;
using AutoMapper;
using Newtonsoft.Json;
using HepsiBurada.Simulator.ClientModel.Response;

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
        private readonly IMapper _mapper;

        public GetCampaignInfoHandler(HttpClient client,
            IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(GetCampaignInfo getCampaignInfo, CancellationToken cancellationToken)
        {
            var httpResult = await _client.GetAsync($"/campaign/{getCampaignInfo.Name}");
            if(!httpResult.IsSuccessStatusCode)
            {
                return new CommandResult {IsSucceed = false};
            }
            var output = _mapper.Map<CommandResult>(JsonConvert.DeserializeObject<CampaignInfoResponse>(await httpResult.Content.ReadAsStringAsync()));
            output.IsSucceed = true;
            return output;
        }
    }
}