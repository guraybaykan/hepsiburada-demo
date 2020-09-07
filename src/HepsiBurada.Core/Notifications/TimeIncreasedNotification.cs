using System;
using MediatR;

namespace HepsiBurada.Core.Notifications
{
    public class TimeIncreasedNotification : INotification
    {
        public DateTime Now { get; set; }
    }
}