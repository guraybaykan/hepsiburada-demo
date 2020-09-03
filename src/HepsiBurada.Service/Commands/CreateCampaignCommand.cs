using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class CreateCampaignCommand : IRequest<Campaign>
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int DurationInHour { get; set; }
        public decimal Limit { get; set; }
        public int TargetSalesCount { get; set; }
    }
}
