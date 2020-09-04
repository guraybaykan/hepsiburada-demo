using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Model;

namespace HepsiBurada.Core.Businness
{
    public interface IProductService : IService
    {
        Task<Product> GetProduct(string code, CancellationToken cancellationToken);
        Task<Product> CreateProduct(Product product, CancellationToken cancellationToken);
    }
}
