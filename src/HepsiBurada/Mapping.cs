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

            
        }
    }
}
