using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using HepsiBurada.Core.Notifications;

namespace HepsiBurada.Service.NofiticationHandlers
{
    public class OrderCreatedNofiticationHandler : INotificationHandler<OrderCreatedNotification>
    {
        public async Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken)
        {
            //todo: recalculate stocks
            throw new NotImplementedException();
        }
    }
}
