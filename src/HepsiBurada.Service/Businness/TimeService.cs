using System;
using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Businness;

namespace HepsiBurada.Service.Businness
{
    public class TimeService : ITimeService, IService
    {
        public Task IncreaseTime(int hour, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<DateTime> SetTime(DateTime time, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}