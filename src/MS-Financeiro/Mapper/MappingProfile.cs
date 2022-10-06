using MS_Financeiro.Models;
using MS_Financeiro.Dto;
using AutoMapper;

namespace MS_Financeiro.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CashFlowModel, CashFlowDto>().ReverseMap();
        }
    }
}
