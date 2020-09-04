using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Businness;
using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public CreateProductCommandHandler(IMapper mapper,
            IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var mappedRequest = _mapper.Map<Product>(request);
            var response = await _productService.CreateProduct(mappedRequest, cancellationToken);
            return response;
        }
    }
}
