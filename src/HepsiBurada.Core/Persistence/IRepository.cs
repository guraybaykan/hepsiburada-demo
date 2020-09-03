using System.Threading.Tasks;
using System.Collections.Generic;

namespace HepsiBurada.Core.Persistence
{
    public interface IRepository<T, TKey>
    {
        Task<T> Get(TKey id);
        Task<IList<T>> GetAll();
        Task<T> Save(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(TKey id);

    }
}
