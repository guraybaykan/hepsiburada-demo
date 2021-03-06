using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Model;
using HepsiBurada.Core.Notifications;
using HepsiBurada.Core.Persistence;
using HepsiBurada.Service.Queries;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IOrderRepository _orderRepository;
        public CreateOrderCommandHandler(IMapper mapper,
            IMediator mediator,
            IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var reqTime = await _mediator.Send(new GetCurrentTimeQuery());

            var product = await _mediator.Send(new GetProductInfoQuery
            {
                Code = request.ProductCode
            });

            if (request.Quantity > product.Stock)
            {
                throw new Exception("Stocks are insufficient");
            }

            var campaign = await _mediator.Send(new CheckProductHasCampaignQuery
            {
                ProductCode = request.ProductCode,
                Date = reqTime.TimeStamp
            });

            var order = new Order
            {
                Price = product.Price,
                Product = new Product { Code = request.ProductCode },
                Quantity = request.Quantity,
                CreatedAt = reqTime.TimeStamp,
                Campaign = campaign
            };

            order.Id = await _orderRepository.Save(order, cancellationToken);

            await _mediator.Publish(new OrderCreatedNotification
            {
                OrderId = order.Id,
                Quantity = order.Quantity,
                Price = order.Price,
                CampaignName = campaign.Name
            });

            return order;
        }
    }
}
