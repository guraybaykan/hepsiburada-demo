using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using HepsiBurada.Simulator.Model;

namespace HepsiBurada.Simulator.Commands
{
    public class IncreaseTime : IRequest<CommandResult>
    {
        public int Hour { get; set; }
        public IncreaseTime(IList<string> parameters)
        {
            this.Hour = Convert.ToInt32(parameters[0]);
        }
    }

    public class IncreaseTimeHandler : IRequestHandler<IncreaseTime, CommandResult>
    {
        public async Task<CommandResult> Handle(IncreaseTime createProduct, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("IncreaseTimeHandler");
            throw new NotImplementedException();
        }

    }
}