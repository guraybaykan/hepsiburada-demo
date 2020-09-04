using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Model;

namespace HepsiBurada.Core.Businness
{
    public interface ICampaignService :  IService
    {
        Task<Campaign> GetCampaign(string name, CancellationToken cancellationToken);
        Task<Campaign> CreateCampaign(Campaign campaign, CancellationToken cancellationToken);
    }
}
