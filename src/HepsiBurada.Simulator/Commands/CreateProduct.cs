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
        public CreateProductHandler(HttpClient client)
        {
            _client = client;
        }

        public async Task<CommandResult> Handle(CreateProduct createProduct, CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(createProduct);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _client.PostAsync($"/product", data, cancellationToken);

            return new CommandResult
            {
                IsSucced = result.IsSuccessStatusCode,
                Output = await result.Content.ReadAsStringAsync()
            };
        }

    }
}