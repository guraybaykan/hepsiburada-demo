using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
