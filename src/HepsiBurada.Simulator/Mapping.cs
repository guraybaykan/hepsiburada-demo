using AutoMapper;
using HepsiBurada.Simulator.ClientModel.Response;
using HepsiBurada.Simulator.Commands;
using HepsiBurada.Simulator.Model;
using HepsiBurada.Simulator.Request;

namespace HepsiBurada.Simulator
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateProduct, ProductRequest>();
            CreateMap<CreateCampaing, CampaignRequest>();
            CreateMap<CreateOrder, OrderRequest>();
            CreateMap<IncreaseTime, TimeRequest>();

            CreateMap<CampaignResponse, CommandResult>()
                .ForMember(dest => dest.Output, opts => opts.MapFrom(src =>
                    $"Campaign created; name {src.Name}, product {src.ProductCode}, duration {src.DurationInHour}, limit {src.Limit}, target sales count {src.TargetSalesCount}"
                )); 

            CreateMap<OrderResponse, CommandResult>()
                .ForMember(dest => dest.Output, opts => opts.MapFrom(src => 
                    $"Order created; product {src.ProductCode}, quantity {src.Quantity}"
                ));

            CreateMap<ProductResponse, CommandResult>()
                .ForMember(dest => dest.Output, opts => opts.MapFrom(src => 
                    $"Product created; code {src.Code}, price {src.Price}, stock {src.Stock}"
                ));

            CreateMap<TimeResponse, CommandResult>()
                .ForMember(dest => dest.Output, opts => opts.MapFrom(src => 
                    $"Time is {src.TimeStamp.ToShortTimeString()}"
                ));

            CreateMap<CampaignInfoResponse, CommandResult>()
                .ForMember(dest => dest.Output, opts => opts.MapFrom(src => 
                    $"Campaign {src.Name} info; Status {GetStatus(src.Active)}, Target Sales {src.TargetSalesCount},Total Sales {src.TotalSalesCount}, Turnover {src.Turnover}, Average Item Price {src.AverageItemPrice}"
                ));
            
            CreateMap<ProductInfoResponse, CommandResult>()
                .ForMember(dest => dest.Output, opts => opts.MapFrom(src => 
                    $"Product {src.Code} info; price {src.Price}, stock {src.Stock}"
            ));

            
        }

        private string GetStatus (bool status) => status ? "is active" : "ended"; 

    }
}