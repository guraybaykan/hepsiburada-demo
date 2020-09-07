using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using HepsiBurada.Simulator.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

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
        public IncreaseTimeHandler(HttpClient client)
        {
            _client = client;
        }

        public async Task<CommandResult> Handle(IncreaseTime increaseTime, CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(increaseTime);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _client.PutAsync($"/time/increase", data, cancellationToken);

            return new CommandResult
            {
                IsSucced = result.IsSuccessStatusCode,
                Output = await result.Content.ReadAsStringAsync()
            };
        }

    }
}