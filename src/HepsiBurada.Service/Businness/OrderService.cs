using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Businness;
using HepsiBurada.Core.Model;

namespace HepsiBurada.Service.Businness
{
    public class OrderService : IOrderService, IService
    {
        public Task<Order> CreateOrder(Order order, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
