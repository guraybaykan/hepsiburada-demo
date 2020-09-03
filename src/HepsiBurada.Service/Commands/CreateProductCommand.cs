using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class CreateProductCommand :  IRequest<Product>
    {
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
