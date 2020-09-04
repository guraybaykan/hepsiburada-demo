using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Notifications;
using MediatR;

namespace HepsiBurada.Service.NofiticationHandlers
{
    public class TimeIncreasedNotificationHandler : INotificationHandler<TimeIncreasedNotification>
    {
        public Task Handle(TimeIncreasedNotification notification, CancellationToken cancellationToken)
        {
            // todo: change price
            throw new System.NotImplementedException();
        }
        
    }
}