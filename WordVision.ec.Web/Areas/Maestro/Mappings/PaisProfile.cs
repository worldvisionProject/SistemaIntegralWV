using AutoMapper;
using WordVision.ec.Application.Features.Maestro.DivisionPolitica.Queries.GetById;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    public class PaisProfile : Profile
    {
        public PaisProfile()
        {
            CreateMap<PaisViewModel, Pais>().ReverseMap();
            CreateMap<ProvinciaViewModel, Provincia>().ReverseMap();
            CreateMap<CiudadViewModel, Ciudad>().ReverseMap();
            CreateMap<GetPaisByIdResponse, PaisViewModel>().ReverseMap();
            CreateMap<GetProvinciaByIdResponse, ProvinciaViewModel>().ReverseMap();
            CreateMap<GetCiudadByIdResponse, CiudadViewModel>().ReverseMap();

        }
    }
}
