using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Queries
{
    public class GetProductInfoQuery : IRequest<Product>
    {
        public string Code { get; set; }
    }
}
