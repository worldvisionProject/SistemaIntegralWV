using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Application.Features.Valoracion.Responsabilidades.Queries.GetById;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Mappings.Valoracion
{
    public class ResponsabilidadProfile : Profile
    {
        public ResponsabilidadProfile()
        {
         
            CreateMap<ResponsabilidadResponse, Responsabilidad>().ReverseMap();
            CreateMap<GetResponsabilidadByIdResponse, Responsabilidad>().ReverseMap();

        }
    }
}
