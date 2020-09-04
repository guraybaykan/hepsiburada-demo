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
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public OrderController(IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody]OrderRequest ordertRequest)
        {
            var request = _mapper.Map<CreateOrderCommand>(ordertRequest);
            var result = await _mediator.Send(request);
            var mappedResult = _mapper.Map<OrderResponse>(result);
            return Created($"product/{mappedResult.Id}" ,mappedResult);
        }


        
    }
}