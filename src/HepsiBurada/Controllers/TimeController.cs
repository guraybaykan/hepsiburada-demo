using System;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Model.Request;
using HepsiBurada.Model.Response;
using HepsiBurada.Service.Commands;
using HepsiBurada.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace HepsiBurada.Controllers
{
    [Route("time")]
    public class TimeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public TimeController(IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPut, Route("increase")]
        public async Task<IActionResult> Put([FromBody] TimeRequest timeRequest)
        {
            var request = _mapper.Map<IncreaseTimeCommand>(timeRequest);
            var result = await _mediator.Send(request);
            throw new NotImplementedException();
        }

        
    }
}