﻿using AutoMapper;
using WordVision.ec.Application.DTOs.Debitos;
using WordVision.ec.Application.DTOs.Donantes;
using WordVision.ec.Application.Features.Donacion.Donantes.Commands.Create;
using WordVision.ec.Application.Features.Donacion.Donantes.Commands.Update;
using WordVision.ec.Application.Features.Donacion.Donantes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Donacion.Donantes.Queries.GetById;
using WordVision.ec.Domain.Entities.Donacion;
using WordVision.ec.Web.Areas.Donacion.Models;

namespace WordVision.ec.Web.Areas.Donacion.Mappings
{
    public class DonanteProfile : Profile
    {

        public DonanteProfile()
        {
            CreateMap<CreateDonanteCommand, DonanteViewModel>().ReverseMap();
            
            CreateMap<UpdateDonanteCommand, DonanteViewModel>().ReverseMap();
            CreateMap<GetAllDonantesResponse, DonanteViewModel>().ReverseMap();
            CreateMap<GetDonantesByIdResponse, DonanteViewModel>().ReverseMap();
            CreateMap<Donante, DonanteViewModel>().ReverseMap();
            CreateMap<DonanteResponseViewModel, DonanteResponse>().ReverseMap();
            CreateMap<ReporteDonantesResponseViewModel,ReporteDonantesResponse >().ReverseMap()
                .ForMember(dest=>dest.Nombres,opt=>opt.MapFrom(src=> string.Format("{0} {1} ", src.Nombre1, src.Nombre2)))
                .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => string.Format("{0} {1} ", src.Apellido1, src.Apellido2)));
        }
    }

}