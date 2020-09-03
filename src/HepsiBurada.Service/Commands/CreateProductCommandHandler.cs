using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
