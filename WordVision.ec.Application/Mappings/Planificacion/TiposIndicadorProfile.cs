using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.TiposIndicadores.Queries.GetAll;
using WordVision.ec.Application.Features.Planificacion.TiposIndicadores.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class TiposIndicadorProfile : Profile
    {
        public TiposIndicadorProfile()
        {
           
            CreateMap<GetTiposIndicadorByIdResponse, TiposIndicador>().ReverseMap();
        
            CreateMap<GetAllTiposIndicadoresResponse, TiposIndicador>().ReverseMap();

        }
    }
}
