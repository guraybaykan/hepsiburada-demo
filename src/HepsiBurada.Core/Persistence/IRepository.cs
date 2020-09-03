using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace HepsiBurada.Core.Persistence
{
    public interface IRepository<T, TKey> : IRepository
    {
        Task<T> Get(TKey id, CancellationToken cancellationToken);
        Task<IList<T>> GetAll(CancellationToken cancellationToken);
        Task<T> Save(T entity, CancellationToken cancellationToken);
        Task Update(T entity, CancellationToken cancellationToken);
        Task Delete(T entity, CancellationToken cancellationToken);

    }

    public interface IRepository
    {

    }
}
