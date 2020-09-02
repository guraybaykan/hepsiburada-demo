using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using HepsiBurada.Simulator.Model;

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
        public async Task<CommandResult> Handle(GetProductInfo createProduct, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("GetProductInfoHandler");
            throw new NotImplementedException();
        }

    }
}