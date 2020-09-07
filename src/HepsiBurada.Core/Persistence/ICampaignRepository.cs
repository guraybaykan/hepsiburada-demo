using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Model;

namespace HepsiBurada.Core.Persistence
{
    public interface ICampaignRepository : IRepository<Campaign, string>
    {
        Task<Campaign> CheckActiveCampaign(string productCode, DateTime now, CancellationToken cancellationToken);
        Task<IList<Campaign>> GetActiveFlaggedCampaigns(CancellationToken cancellationToken);
       
    }
}
