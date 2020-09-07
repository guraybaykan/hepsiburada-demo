using HepsiBurada.Core.Model;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class IncreaseTimeCommand : IRequest<Time>
    {
        public int Hour { get; set; }
    }
}
