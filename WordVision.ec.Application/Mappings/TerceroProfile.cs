using AutoMapper;
using WordVision.ec.Application.Features.Registro.Terceros.Commands.Create;
using WordVision.ec.Application.Features.Registro.Terceros.Queries.GetById;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Mappings
{
    internal class TerceroProfile : Profile
    {
        public TerceroProfile()
        {
            CreateMap<CreateTerceroCommand, Tercero>().ReverseMap();
            CreateMap<GetByIdResponse, Tercero>().ReverseMap();

        }
    }
}
