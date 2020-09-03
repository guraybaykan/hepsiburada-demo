using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Persistence;
using NHibernate;
using NHibernate.Criterion;

namespace HepsiBurada.Infrastructure.Persistence
{
    public abstract class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected readonly ISession _session;
        public Repository(ISession session)
        {
            _session = session;
        }

        public async Task<T> Get(TKey id, CancellationToken cancellationToken)
        {
            return await _session.CreateCriteria<T>().Add(Restrictions.IdEq(id)).UniqueResultAsync<T>();

        }

        public async Task<IList<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _session.CreateCriteria<T>().ListAsync<T>();
        }

        public async Task<T> Save(T entity, CancellationToken cancellationToken)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var saved = await _session.SaveAsync(entity, cancellationToken) as T;
                await transaction.CommitAsync();
                return saved;
            }
        }

        public async Task Update(T entity, CancellationToken cancellationToken)
        {
            using (var transaction = _session.BeginTransaction())
            {
                await _session.UpdateAsync(entity, cancellationToken);
                await transaction.CommitAsync();
            }
        }
        public async Task Delete(T entity, CancellationToken cancellationToken)
        {
            using (var transaction = _session.BeginTransaction())
            {
                await _session.DeleteAsync(entity, cancellationToken);
                await transaction.CommitAsync();
            }
        }
    }
}
