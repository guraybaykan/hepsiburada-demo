using System;
using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Model;

namespace HepsiBurada.Core.Persistence
{
    public interface ITimeRepository : IRepository<Time, int>
    {
        Task<Time> GetCurrentDate(CancellationToken cancellationToken);
    }
}
