using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace HepsiBurada.Simulator.Commands
{
    public class IncreaseTime : IRequest<Unit>
    {
        public int Hour { get; set; }
        public IncreaseTime(IList<string> parameters)
        {
            this.Hour = Convert.ToInt32(parameters[0]);
        }
    }

    public class IncreaseTimeHandler : IRequestHandler<IncreaseTime, Unit>
    {
        public async Task<Unit> Handle(IncreaseTime createProduct, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("IncreaseTimeHandler");
            return await Task.FromResult(Unit.Value);
        }

    }
}