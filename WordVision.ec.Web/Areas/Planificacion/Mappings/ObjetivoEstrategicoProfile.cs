using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    internal class ObjetivoEstrategicoProfile : Profile
    {
        public ObjetivoEstrategicoProfile()
        {
            CreateMap<GetAllObjetivoEstrategicoesCachedResponse, ObjetivoEstrategicoViewModel>().ReverseMap();
            CreateMap<GetObjetivoEstrategicoByIdResponse, ObjetivoEstrategicoViewModel>().ReverseMap();
            CreateMap<CreateObjetivoEstrategicoCommand, ObjetivoEstrategicoViewModel>().ReverseMap();
            CreateMap<UpdateObjetivoEstrategicoCommand, ObjetivoEstrategicoViewModel>().ReverseMap();
            CreateMap<ObjetivoEstrategico, ObjetivoEstrategicoViewModel>().ReverseMap();
        }
    }
}
