using System;
using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Notifications;
using HepsiBurada.Core.Persistence;
using MediatR;

namespace HepsiBurada.Service.NofiticationHandlers
{
    public class CampaignCreatedNotificationHandler : INotificationHandler<CampaignCreatedNotification>
    {
        private readonly ITimeRepository _timeRepository;
        public CampaignCreatedNotificationHandler(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;

        }
        public async Task Handle(CampaignCreatedNotification notification, CancellationToken cancellationToken)
        {
            var now = await _timeRepository.GetCurrentDate(cancellationToken);
            if(now is null)
            {
                await _timeRepository.Save(new Core.Model.Time {TimeStamp = notification.StartDate}, cancellationToken);
            }
        }
    }
}