using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;

namespace HepsiBurada.Infrastructure.Persistence
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
    }
}
