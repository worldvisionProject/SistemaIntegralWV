using AutoMapper;
using WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal;
using WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal.Commands.Create;
using WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal.Commands.Update;
using WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal.Queries.GetAll;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Mappings.Indicadores
{
    internal class EstadoPorAnioFiscalProfile : Profile
    {
        public EstadoPorAnioFiscalProfile()
        {
            CreateMap<CreateEstadoPorAnioFiscalCommand, EstadoPorAnioFiscal>().ReverseMap();
            CreateMap<EstadoPorAnioFiscalResponse, EstadoPorAnioFiscal>().ReverseMap();
            CreateMap<UpdateEstadoPorAnioFiscalCommand, EstadoPorAnioFiscal>().ReverseMap();
            CreateMap<GetAllEstadoPorAnioFiscalQuery, EstadoPorAnioFiscal>().ReverseMap();
        }
       
    }
}
