using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Globalization;

namespace HepsiBurada.Simulator.Commands
{
    public class CreateProduct : IRequest<Unit>
    {
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public CreateProduct(IList<string> parameters)
        {
            this.Code = parameters[0];
            this.Price = Convert.ToDecimal(parameters[1], CultureInfo.InvariantCulture);
        }
    }

    public class CreateProductHandler : IRequestHandler<CreateProduct, Unit>
    {
        public async Task<Unit> Handle(CreateProduct createProduct, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("CreateProductHandler");
            return await Task.FromResult(Unit.Value);
        }

    }
}