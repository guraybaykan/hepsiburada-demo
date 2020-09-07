using System;
using MediatR;

namespace HepsiBurada.Core.Notifications
{
    public class CampaignCreatedNotification : INotification
    {
        public DateTime StartDate { get; set; }
        
    }
}