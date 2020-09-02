using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Globalization;

namespace HepsiBurada.Simulator.Commands
{
    public class CreateCampaing : IRequest<Unit>
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int DurationInHour { get; set; }
        public decimal Limit { get; set; }
        public int TargetSalesCount { get; set; }

        public CreateCampaing(IList<string> parameters)
        {
            this.Name = parameters[0];
            this.ProductCode =  parameters[1];
            this.DurationInHour = Convert.ToInt32(parameters[2]);
            this.Limit = Convert.ToDecimal(parameters[3], CultureInfo.InvariantCulture);
            this.TargetSalesCount = Convert.ToInt32(parameters[4]);
        }
    }

    public class CreateCampaingHandler : IRequestHandler<CreateCampaing, Unit>
    {
        public async Task<Unit> Handle(CreateCampaing createCampaing, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("CreateCampaingHandler");
            return await Task.FromResult(Unit.Value);
        }

    }
}