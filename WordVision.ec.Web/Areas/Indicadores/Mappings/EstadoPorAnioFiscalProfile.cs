using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal;
using WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal.Commands.Create;
using WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal.Commands.Update;
using WordVision.ec.Web.Areas.Indicadores.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Mappings
{
    internal class EstadoPorAnioFiscalProfile : Profile
    {
        public EstadoPorAnioFiscalProfile()
        {
            CreateMap<EstadoPorAnioFiscalResponse, EstadoPorAnioFiscalViewModel>().ReverseMap();
            CreateMap<CreateEstadoPorAnioFiscalCommand, EstadoPorAnioFiscalViewModel>().ReverseMap();
            CreateMap<UpdateEstadoPorAnioFiscalCommand, EstadoPorAnioFiscalViewModel>().ReverseMap();
        }
    }
}
