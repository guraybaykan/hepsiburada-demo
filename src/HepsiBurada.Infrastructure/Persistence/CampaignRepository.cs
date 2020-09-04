using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;
using NHibernate;

namespace HepsiBurada.Infrastructure.Persistence
{
    public class CampaignRepository : Repository<Campaign, string>, ICampaignRepository
    {
        public CampaignRepository(ISession session) : base(session)
        {
            
        }
    }
}
