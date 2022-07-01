using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.DivisionPolitica.Queries.GetById;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    public class PaisProfile : Profile
    {
        public PaisProfile()
        {
            CreateMap<GetPaisByIdResponse, Pais>().ReverseMap();
            CreateMap<GetProvinciaByIdResponse, Provincia>().ReverseMap();
            CreateMap<GetCiudadByIdResponse, Ciudad>().ReverseMap();
          
        }

    }
}
