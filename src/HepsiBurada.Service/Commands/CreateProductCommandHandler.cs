using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IMapper mapper,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

             //todo is it necessary to control. Code is ID actually
            if(await _productRepository.Get(product.Code, cancellationToken) != null)
            {
                throw new System.Exception($"product {product.Code} has already been defined");
            }
            product.Code = await _productRepository.Save(product, cancellationToken);
            return product;
        }
    }
}
