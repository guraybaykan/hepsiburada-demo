using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class IncreaseTimeCommand : IRequest<Unit>
    {
        public int Hour { get; set; }
    }
}
