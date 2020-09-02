using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HepsiBurada.Simulator.Commands
{
    public class CreateProduct : IRequest<Unit>
    {

    }

    public class CreateProductHandler : IRequestHandler<CreateProduct, Unit>
    {
        public async Task<Unit> Handle(CreateProduct createProduct, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("we're in");
            return await Task.FromResult(Unit.Value);
        }

    }
}