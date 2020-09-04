using System;
using System.Threading;
using System.Threading.Tasks;

namespace HepsiBurada.Core.Businness
{
    public interface ITimeService : IService
    {
        Task<DateTime> SetTime(DateTime time, CancellationToken cancellationToken);
        Task IncreaseTime(int hour, CancellationToken cancellationToken);
    }
}
