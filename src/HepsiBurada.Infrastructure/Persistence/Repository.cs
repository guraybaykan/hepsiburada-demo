using System.Collections.Generic;
using System.Threading.Tasks;
using HepsiBurada.Core.Persistence;

namespace HepsiBurada.Infrastructure.Persistence
{
    public abstract class Repository<T, TKey> : IRepository<T, TKey>
    {
        public Task<T> Delete(TKey id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Get(TKey id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<T>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Save(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
