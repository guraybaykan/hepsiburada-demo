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
    [Route("campaign")]
    public class CampaignController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CampaignController(IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpGet, Route("{name:required}")]
        [ProducesResponseType(typeof(CampaignResponse), StatusCodes.Status200OK)]

        public async Task<IActionResult> Get(string name)
        {
            var result = await _mediator.Send(new GetCampaignInfoQuery{
                Name = name
            });

            if(result is null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<CampaignResponse>(result);

            return Ok(mappedResult);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CampaignResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] CampaignRequest campaignRequest)
        {
            var request = _mapper.Map<CreateCampaignCommand>(campaignRequest);
            var result = await _mediator.Send(request);
            var mappedResult = _mapper.Map<CampaignResponse>(result);
            return Created($"campaign/{mappedResult.Name}" ,mappedResult);
        }
    }
}