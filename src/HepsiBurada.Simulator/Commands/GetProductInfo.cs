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
        private readonly IMapper _mapper;

        public GetProductInfoHandler(HttpClient client,
            IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }
        public async Task<CommandResult> Handle(GetProductInfo createProduct, CancellationToken cancellationToken)
        {
            var httpResult = await _client.GetAsync($"/product/{createProduct.Code}");
            if(!httpResult.IsSuccessStatusCode)
            {
                return new CommandResult {IsSucceed = false};
            }
            var output = _mapper.Map<CommandResult>(JsonConvert.DeserializeObject<ProductInfoResponse>(await httpResult.Content.ReadAsStringAsync()));
            output.IsSucceed = true;
            return output;
        }

    }
}