using System;
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

        public async Task<Campaign> CheckActiveCampaign(string productCode, DateTime date, CancellationToken cancellationToken)
        {
            return await _session.CreateCriteria<Campaign>()
                .Add(Restrictions.Eq("ProductCode", productCode))
                .Add(Restrictions.Eq("StartDate", date))
                .UniqueResultAsync<Campaign>();
        }
    }
}
