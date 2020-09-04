using System;
using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Queries
{
    public class CheckProductHasCampaignQuery : IRequest<Campaign>
    {
        public string ProductCode { get; set; }
        public DateTime Date { get; set; }
    }
}