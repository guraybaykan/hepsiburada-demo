using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Businness;
using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Queries
{
    public class GetProductInfoQueryHandler : IRequestHandler<GetProductInfoQuery, Product>
    
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public GetProductInfoQueryHandler(IMapper mapper,
            IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<Product> Handle(GetProductInfoQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProduct(request.Code, cancellationToken);
        }
    }
}
