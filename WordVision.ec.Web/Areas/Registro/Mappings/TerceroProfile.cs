using AutoMapper;
using WordVision.ec.Application.Features.Registro.Terceros.Commands.Create;
using WordVision.ec.Application.Features.Registro.Terceros.Commands.Update;
using WordVision.ec.Application.Features.Registro.Terceros.Queries.GetById;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Mappings
{
    internal class TerceroProfile : Profile
    {
        public TerceroProfile()
        {
            CreateMap<CreateTerceroCommand, TerceroViewModel>().ReverseMap();
            CreateMap<GetByIdResponse, TerceroViewModel>().ReverseMap();
            CreateMap<UpdateTerceroCommand, TerceroViewModel>().ReverseMap();

        }
    }
}
