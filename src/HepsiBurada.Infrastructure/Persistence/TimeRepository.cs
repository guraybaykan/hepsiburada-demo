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

        public async Task<DateTime> GetCurrentDate(CancellationToken cancellationToken)
        {
            var result= await _session.CreateCriteria<Time>()
                .SetProjection(Projections.Max("TimeStamp"))
                .UniqueResultAsync<Time>();

            return result.TimeStamp;
        }

        public async Task<DateTime> IncreaseDate(int hour, CancellationToken cancellationToken)
        {
            var date = await GetCurrentDate(cancellationToken);
            var time = new Time
            {
                TimeStamp = date.AddHours(hour)
            };
            time.Id = await Save(time, cancellationToken);
            return time.TimeStamp;
        }
    }
}
