using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Businness;
using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        public CreateOrderCommandHandler(IMapper mapper,
            IOrderService orderService)
        {
            _mapper = mapper;   
            _orderService = orderService;
        }

        public Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
