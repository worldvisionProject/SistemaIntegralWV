using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Commands.Create;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Commands.Update;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Queries.GetAll;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Mappings.Indicadores
{
    internal class FaseProgramaAreaProfile : Profile
    {
        public FaseProgramaAreaProfile()
        {
            CreateMap<CreateFaseProgramaAreaCommand, FaseProgramaArea>().ReverseMap();
            CreateMap<FaseProgramaAreaResponse, FaseProgramaArea>().ReverseMap();
            CreateMap<UpdateFaseProgramaAreaCommand, FaseProgramaArea>().ReverseMap();
            CreateMap<GetAllFaseProgramaAreaQuery, FaseProgramaArea>().ReverseMap();
        }
       
    }
}
