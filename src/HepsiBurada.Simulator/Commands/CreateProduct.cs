using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Globalization;
using HepsiBurada.Simulator.Model;

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
        }
    }

    public class CreateProductHandler : IRequestHandler<CreateProduct, CommandResult>
    {
        public async Task<CommandResult> Handle(CreateProduct createProduct, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("CreateProductHandler");
            throw new NotImplementedException();
        }

    }
}