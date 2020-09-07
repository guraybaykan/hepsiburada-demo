using System;
using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;
using NHibernate;
using NHibernate.Criterion;

namespace HepsiBurada.Infrastructure.Persistence
{
    public class TimeRepository : Repository<Time, int>, ITimeRepository
    {
        public TimeRepository(ISession session) : base (session) 
        {
            
        }

        public async Task<Time> GetCurrentDate(CancellationToken cancellationToken)
        {
            var result = _session.CreateCriteria<Time>()
                .AddOrder(NHibernate.Criterion.Order.Desc("TimeStamp"))
                .SetMaxResults(1)
                .UniqueResult<Time>();

            return await Task.FromResult(result);
        }
    }
}
