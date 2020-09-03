using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Queries
{
    public class GetCampaignInfoQuery : IRequest<Campaign>
    {
        public string Name { get; set; }
    }
}
