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
    public class CreateProduct : IRequest<CommandResult>
    {
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public CreateProduct(IList<string> parameters)
        {
            this.Code = parameters[0];
            this.Price = Convert.ToDecimal(parameters[1], CultureInfo.InvariantCulture);
            this.Stock = Convert.ToInt32(parameters[2], CultureInfo.InvariantCulture);
        }
    }

    public class CreateProductHandler : IRequestHandler<CreateProduct, CommandResult>
    {
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public CreateProductHandler(HttpClient client,
            IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(CreateProduct createProduct, CancellationToken cancellationToken)
        {
            var mappedRequest = _mapper.Map<ProductRequest>(createProduct);
            var json = JsonConvert.SerializeObject(mappedRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResult = await _client.PostAsync($"/product", data, cancellationToken);

            if(!httpResult.IsSuccessStatusCode)
            {
                return new CommandResult {IsSucceed = false};
            }
            var output = _mapper.Map<CommandResult>(JsonConvert.DeserializeObject<ProductResponse>(await httpResult.Content.ReadAsStringAsync()));
            output.IsSucceed = true;
            return output;
        }

    }
}