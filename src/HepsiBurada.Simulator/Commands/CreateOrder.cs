using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using HepsiBurada.Simulator.Model;

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
        public async Task<CommandResult> Handle(CreateOrder createOrder, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("CreateOrderHandler");
            throw new NotImplementedException();
        }

    }
}