using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Soporte.Donantes.Commands.Create;
using WordVision.ec.Application.Features.Soporte.Donantes.Commands.Update;
using WordVision.ec.Application.Features.Soporte.Donantes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Soporte.Donantes.Queries.GetById;
using WordVision.ec.Domain.Entities.Soporte;


namespace WordVision.ec.Application.Mappings.Soporte
{
    public class DonanteProfile : Profile
    {

        public DonanteProfile()
        {
            CreateMap<CreateDonanteCommand, Donante>().ReverseMap();
            CreateMap<UpdateDonanteCommand, Donante>().ReverseMap();
            CreateMap<GetAllDonantesResponse, Donante>().ReverseMap();
            CreateMap<GetDonantesByIdResponse, Donante>().ReverseMap();
           
        }
    }
    
}
