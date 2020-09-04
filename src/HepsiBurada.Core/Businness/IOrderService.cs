using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Model;

namespace HepsiBurada.Core.Businness
{
    public interface IOrderService : IService
    {
        Task<Order> CreateOrder(Order order, CancellationToken cancellationToken);
    }
}
