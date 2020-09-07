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
    public class CreateOrder : IRequest<CommandResult>
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public CreateOrder(IList<string> parameters)
        {
            this.ProductCode = parameters[0];
            this.Quantity = Convert.ToInt32(parameters[1]);
        }
    }

    public class CreateOrderHandler : IRequestHandler<CreateOrder, CommandResult>
    {
        private readonly HttpClient _client;
        public CreateOrderHandler(HttpClient client)
        {
            _client = client;
        }

        public async Task<CommandResult> Handle(CreateOrder createOrder, CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(createOrder);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _client.PostAsync($"/order/", data, cancellationToken);
            
            return new CommandResult
            {
                IsSucced = result.IsSuccessStatusCode,
                Output = await result.Content.ReadAsStringAsync()
            };
        }

    }
}