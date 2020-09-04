using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using HepsiBurada.Simulator.Model;
using System.Net.Http;

namespace HepsiBurada.Simulator.Commands
{
    public class GetProductInfo : IRequest<CommandResult>
    {
        public string Code { get; set; }
        public GetProductInfo(IList<string> parameters)
        {
            this.Code = parameters[0];
        }
    }

    public class GetProductInfoHandler : IRequestHandler<GetProductInfo, CommandResult>
    {        
        private readonly HttpClient _client;
        public GetProductInfoHandler(HttpClient client)
        {
            _client = client;
        }

        public async Task<CommandResult> Handle(GetProductInfo createProduct, CancellationToken cancellationToken)
        {
            var result = await _client.GetAsync($"/product/{createProduct.Code}");

            System.Console.WriteLine(result.StatusCode);
            return new CommandResult
            {
                IsSucced = result.IsSuccessStatusCode,
                Output = await result.Content.ReadAsStringAsync()
            };
        }

    }
}