using AutoMapper;
using HepsiBurada.Core.Model;
using HepsiBurada.Model.Request;
using HepsiBurada.Model.Response;
using HepsiBurada.Service.Commands;

namespace HepsiBurada
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap< ProductRequest, CreateProductCommand>();

            CreateMap<CampaignRequest, CreateCampaignCommand>();
            CreateMap<Campaign, CampaignResponse>();

            CreateMap<OrderRequest, CreateOrderCommand>();
            CreateMap<Order, OrderResponse>();

            CreateMap<TimeRequest, IncreaseTimeCommand>();
            CreateMap<Time, TimeResponse>();
            
        }
    }
}
