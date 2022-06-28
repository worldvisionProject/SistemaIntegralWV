using AutoMapper;
using WordVision.ec.Application.Features.Maestro.OtroIndicador;
using WordVision.ec.Application.Features.Maestro.OtroIndicador.Commands.Create;
using WordVision.ec.Application.Features.Maestro.OtroIndicador.Commands.Update;
using WordVision.ec.Application.Features.Maestro.OtroIndicador.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class OtroIndicadorProfile : Profile
    {
        public OtroIndicadorProfile()
        {
            CreateMap<CreateOtroIndicadorCommand, OtroIndicador>().ReverseMap();
            CreateMap<OtroIndicadorResponse, OtroIndicador>().ReverseMap();
            CreateMap<UpdateOtroIndicadorCommand, OtroIndicador>().ReverseMap();
            CreateMap<GetAllOtroIndicadorQuery, OtroIndicador>().ReverseMap();
        }
       
    }
}
