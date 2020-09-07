using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Globalization;
using HepsiBurada.Simulator.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using AutoMapper;
using HepsiBurada.Simulator.Request;
using HepsiBurada.Simulator.ClientModel.Response;

namespace HepsiBurada.Simulator.Commands
{
    public class CreateCampaing : IRequest<CommandResult>
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int DurationInHour { get; set; }
        public decimal Limit { get; set; }
        public int TargetSalesCount { get; set; }

        public CreateCampaing(IList<string> parameters)
        {
            this.Name = parameters[0];
            this.ProductCode =  parameters[1];
            this.DurationInHour = Convert.ToInt32(parameters[2]);
            this.Limit = Convert.ToDecimal(parameters[3], CultureInfo.InvariantCulture);
            this.TargetSalesCount = Convert.ToInt32(parameters[4]);
        }
    }

    public class CreateCampaingHandler : IRequestHandler<CreateCampaing, CommandResult>
    {
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public CreateCampaingHandler(HttpClient client,
            IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }
        public async Task<CommandResult> Handle(CreateCampaing createCampaing, CancellationToken cancellationToken)
        {
            var mappedRequest = _mapper.Map<CampaignRequest>(createCampaing);
            var json = JsonConvert.SerializeObject(mappedRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResult = await _client.PostAsync($"/campaign/", data, cancellationToken);

            if(!httpResult.IsSuccessStatusCode)
            {
                return new CommandResult {IsSucceed = false};
            }
            var output = _mapper.Map<CommandResult>(JsonConvert.DeserializeObject<CampaignResponse>(await httpResult.Content.ReadAsStringAsync()));
            output.IsSucceed = true;
            return output;
        }

    }
}