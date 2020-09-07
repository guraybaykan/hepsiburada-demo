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
        private readonly IMapper _mapper;

        public CreateOrderHandler(HttpClient client,
            IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(CreateOrder createOrder, CancellationToken cancellationToken)
        {
            var mappedRequest = _mapper.Map<OrderRequest>(createOrder);
            var json = JsonConvert.SerializeObject(mappedRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResult = await _client.PostAsync($"/order/", data, cancellationToken);
            
            if(!httpResult.IsSuccessStatusCode)
            {
                return new CommandResult {IsSucceed = false};
            }
            var output = _mapper.Map<CommandResult>(JsonConvert.DeserializeObject<OrderResponse>(await httpResult.Content.ReadAsStringAsync()));
            output.IsSucceed = true;
            return output;
        }

    }
}