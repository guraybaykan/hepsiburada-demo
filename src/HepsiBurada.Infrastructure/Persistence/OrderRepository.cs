using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;
using NHibernate;

namespace HepsiBurada.Infrastructure.Persistence
{
    public class OrderRepository :  Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(ISession session) : base(session)
        {
            
        }
    }
}
