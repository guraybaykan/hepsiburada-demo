using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;

namespace HepsiBurada.Infrastructure.Persistence
{
    public class OrderRepository :  Repository<Order, int>, IOrderRepository
    {
    }
}
