using AutoMapper;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Application.Features.Donacion.Debitos.Commands.Create;
using WordVision.ec.Application.Features.Donacion.Debitos.Commands.Update;
using WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetAllCached;
using WordVision.ec.Application.Features.Donacion.Debitos.Queries.GetById;
using WordVision.ec.Domain.Entities.Donacion;
using WordVision.ec.Web.Areas.Donacion.Models;

namespace WordVision.ec.Web.Areas.Donacion.Mappings
{
    public class DebitoProfile : Profile
    {

        public DebitoProfile()
        {
            CreateMap<CreateDebitoCommand, DebitoViewModel>().ReverseMap();
            CreateMap<UpdateDebitoCommand, DebitoViewModel>().ReverseMap();
            CreateMap<GetAllDebitosResponse, Debito>().ReverseMap();
            CreateMap<GetDebitosByIdResponse, DebitoViewModel>().ReverseMap();
            CreateMap<DebitoViewModel, Debito>().ReverseMap();
            CreateMap<DebitoResponse, Debito>().ReverseMap();
            CreateMap<DebitoResponse, DebitoResponseViewModel>().ReverseMap();


        }
    }

}
