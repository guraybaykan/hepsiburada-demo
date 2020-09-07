using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;
using NHibernate;
using NHibernate.Criterion;

namespace HepsiBurada.Infrastructure.Persistence
{
    public class CampaignRepository : Repository<Campaign, string>, ICampaignRepository
    {
        public CampaignRepository(ISession session) : base(session)
        {
        }

        public async Task<Campaign> CheckActiveCampaign(string productCode, DateTime now, CancellationToken cancellationToken)
        {
            return await _session.CreateCriteria<Campaign>()
                .Add(Restrictions.Eq("IsActive", true))
                .Add(Restrictions.Eq("Product.Code", productCode))
                .Add(Restrictions.Le("StartDate", now))
                .Add(Restrictions.Ge("EndDate", now))
                .UniqueResultAsync<Campaign>();
        }
        public async Task<IList<Campaign>> GetActiveFlaggedCampaigns(CancellationToken cancellationToken)
        {
            return await _session.CreateCriteria<Campaign>()
                .Add(Restrictions.Eq("IsActive", true))
                .ListAsync<Campaign>();
        }

    }
}
