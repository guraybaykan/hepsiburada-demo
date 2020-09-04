using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;
using NHibernate;

namespace HepsiBurada.Infrastructure.Persistence
{
    public class ProductRepository : Repository<Product, string>, IProductRepository
    {
        public ProductRepository(ISession session) : base(session)
        {
            
        }
    }
}
