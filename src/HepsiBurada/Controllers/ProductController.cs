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
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductController(IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet, Route("{code:required}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute]string code)
        {
            var result = await _mediator.Send(new GetProductInfoQuery{
                Code = code
            });

            if(result is null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<ProductResponse>(result);

            return Ok(mappedResult);
        }


        [HttpPost]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody]ProductRequest productRequest)
        {
            var request = _mapper.Map<CreateProductCommand>(productRequest);
            var result = await _mediator.Send(request);
            var mappedResult = _mapper.Map<ProductResponse>(result);
            return Created($"product/{mappedResult.Code}" ,mappedResult);
        }

        
    }
}