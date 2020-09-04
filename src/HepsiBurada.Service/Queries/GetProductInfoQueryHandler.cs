using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;
using MediatR;

namespace HepsiBurada.Service.Queries
{
    public class GetProductInfoQueryHandler : IRequestHandler<GetProductInfoQuery, Product>
    
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductInfoQueryHandler(IMapper mapper,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductInfoQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.Get(request.Code, cancellationToken);
        }
    }
}
