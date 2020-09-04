using System;
using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Model;

namespace HepsiBurada.Core.Persistence
{
    public interface ITimeRepository : IRepository<Time, int>
    {
        Task<DateTime> GetCurrentDate(CancellationToken cancellationToken);
        Task<DateTime> IncreaseDate(int hour, CancellationToken cancellationToken);
    }
}
