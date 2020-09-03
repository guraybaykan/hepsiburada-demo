using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;
using NHibernate;

namespace HepsiBurada.Infrastructure.Persistence
{
    public class TimeRepository : Repository<Time, int>, ITimeRepository
    {
        public TimeRepository(ISession session) : base (session) 
        {
            
        }
    }
}
