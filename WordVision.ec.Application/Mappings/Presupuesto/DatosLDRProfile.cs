using AutoMapper;
using WordVision.ec.Application.Features.Presupuesto.DatosLDR.Commands.Create;
using WordVision.ec.Application.Features.Presupuesto.DatosLDR.Queries.GetAllCached;
using WordVision.ec.Domain.Entities.Presupuesto;

namespace WordVision.ec.Application.Mappings.Presupuesto
{
    internal class DatosLDRProfile : Profile
    {
        public DatosLDRProfile()
        {
            CreateMap<CreateDatosLDRCommand, DatosLDR>().ReverseMap();
            //CreateMap<GetColaboradorByIdResponse, Colaborador>().ReverseMap();
            CreateMap<GetAllDatosLDRsCachedResponse, DatosLDR>().ReverseMap();
            //CreateMap<GetAllColaboradoresResponse, Colaborador>().ReverseMap();
        }
    }
}
