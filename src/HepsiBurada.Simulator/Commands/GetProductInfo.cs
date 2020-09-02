using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace HepsiBurada.Simulator.Commands
{
    public class GetProductInfo : IRequest<Unit>
    {
        public string Code { get; set; }
        public GetProductInfo(IList<string> parameters)
        {
            this.Code = parameters[0];
        }
    }

    public class GetProductInfoHandler : IRequestHandler<GetProductInfo, Unit>
    {
        public async Task<Unit> Handle(GetProductInfo createProduct, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("GetProductInfoHandler");
            return await Task.FromResult(Unit.Value);
        }

    }
}