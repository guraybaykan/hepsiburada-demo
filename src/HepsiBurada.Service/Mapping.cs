
using AutoMapper;
using HepsiBurada.Core.Model;
using HepsiBurada.Service.Commands;

namespace HepsiBurada.Service
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
