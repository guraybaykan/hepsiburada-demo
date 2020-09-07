using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using HepsiBurada.Simulator.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using AutoMapper;
using HepsiBurada.Simulator.Request;
using HepsiBurada.Simulator.ClientModel.Response;

namespace HepsiBurada.Simulator.Commands
{
    public class IncreaseTime : IRequest<CommandResult>
    {
        public int Hour { get; set; }
        public IncreaseTime(IList<string> parameters)
        {
            this.Hour = Convert.ToInt32(parameters[0]);
        }
    }

    public class IncreaseTimeHandler : IRequestHandler<IncreaseTime, CommandResult>
    {
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public IncreaseTimeHandler(HttpClient client,
            IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(IncreaseTime increaseTime, CancellationToken cancellationToken)
        {
            var mappedRequest = _mapper.Map<TimeRequest>(increaseTime);
            var json = JsonConvert.SerializeObject(mappedRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResult = await _client.PutAsync($"/time/increase", data, cancellationToken);

            if(!httpResult.IsSuccessStatusCode)
            {
                return new CommandResult {IsSucceed = false};
            }
            var output = _mapper.Map<CommandResult>(JsonConvert.DeserializeObject<TimeResponse>(await httpResult.Content.ReadAsStringAsync()));
            output.IsSucceed = true;
            return output;
        }

    }
}