using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace HepsiBurada.Simulator.Commands
{
    public class CreateOrder : IRequest<Unit>
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public CreateOrder(IList<string> parameters)
        {
            this.ProductCode = parameters[0];
            this.Quantity = Convert.ToInt32(parameters[1]);
        }
    }

    public class CreateOrderHandler : IRequestHandler<CreateOrder, Unit>
    {
        public async Task<Unit> Handle(CreateOrder createOrder, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("CreateOrderHandler");
            return await Task.FromResult(Unit.Value);
        }

    }
}