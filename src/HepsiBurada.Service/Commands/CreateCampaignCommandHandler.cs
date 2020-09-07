using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HepsiBurada.Core.Model;
using HepsiBurada.Core.Notifications;
using HepsiBurada.Core.Persistence;
using HepsiBurada.Service.Queries;
using MediatR;

namespace HepsiBurada.Service.Commands
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Campaign>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ICampaignRepository _campaignRepository;
        public CreateCampaignCommandHandler(IMapper mapper,
            IMediator mediator,
            ICampaignRepository campaignRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _campaignRepository = campaignRepository;
        }
        public async Task<Campaign> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            //todo is it necessary to control. Name is ID actually
            if (await _campaignRepository.Get(request.Name, cancellationToken) != null)
            {
                throw new System.Exception("The campaign is already defined");
            }

            var campaign = _mapper.Map<Campaign>(request);

            var product = await _mediator.Send(new GetProductInfoQuery {
                Code = request.ProductCode
            });

            var currentTime = await _mediator.Send(new GetCurrentTimeQuery());

            campaign.AverageItemPrice = 0;
            campaign.TotalSalesCount = 0;
            campaign.Turnover = 0;
            campaign.TargetSalesCount = request.TargetSalesCount;
            campaign.StartDate = currentTime.TimeStamp;
            campaign.EndDate = currentTime.TimeStamp.AddHours(request.DurationInHour);
            campaign.IsActive = true;
            campaign.Product = product;
            campaign.StartPrice = product.Price;

            campaign.Name = await _campaignRepository.Save(campaign, cancellationToken);

            await _mediator.Publish(new CampaignCreatedNotification{
                StartDate = campaign.StartDate
            });

            return campaign;
        }
    }
}
