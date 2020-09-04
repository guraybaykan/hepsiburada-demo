using System;
using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Model;

namespace HepsiBurada.Core.Persistence
{
    public interface ICampaignRepository : IRepository<Campaign, string>
    {
        Task<Campaign> CheckActiveCampaign(string productCode, DateTime Date, CancellationToken cancellationToken);
    }
}
