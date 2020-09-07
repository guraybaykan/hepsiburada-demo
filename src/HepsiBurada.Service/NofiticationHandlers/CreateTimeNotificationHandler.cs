using System;
using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Notifications;
using HepsiBurada.Core.Persistence;
using MediatR;

namespace HepsiBurada.Service.NofiticationHandlers
{
    public class CreateTimeNotificationHandler : INotificationHandler<CreateTimeNotification>
    {
        private readonly ITimeRepository _timeRepository;

        public CreateTimeNotificationHandler(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task Handle(CreateTimeNotification notification, CancellationToken cancellationToken)
        {
            await _timeRepository.Save(new Core.Model.Time
            {
                TimeStamp = DateTime.Today
            }, cancellationToken);
        }
    }
}