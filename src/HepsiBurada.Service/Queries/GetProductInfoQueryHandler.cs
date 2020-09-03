using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Queries
{
    public class GetProductInfoQueryHandler : IRequestHandler<GetProductInfoQuery, Product>
    
    {
        private readonly IMapper _mapper;
        public GetProductInfoQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<Product> Handle(GetProductInfoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
