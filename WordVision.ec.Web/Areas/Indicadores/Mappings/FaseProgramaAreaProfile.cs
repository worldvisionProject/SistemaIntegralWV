using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Commands.Create;
using WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Commands.Update;
using WordVision.ec.Web.Areas.Indicadores.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Mappings
{
    internal class FaseProgramaAreaProfile : Profile
    {
        public FaseProgramaAreaProfile()
        {
            CreateMap<FaseProgramaAreaResponse, FaseProgramaAreaViewModel>().ReverseMap();
            CreateMap<CreateFaseProgramaAreaCommand, FaseProgramaAreaViewModel>().ReverseMap();
            CreateMap<UpdateFaseProgramaAreaCommand, FaseProgramaAreaViewModel>().ReverseMap();
        }
    }
}
