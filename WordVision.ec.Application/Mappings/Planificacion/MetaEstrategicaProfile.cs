using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class MetaEstrategicaProfile : Profile
    {
        public MetaEstrategicaProfile()
        {
            CreateMap<CreateMetaEstrategicaCommand, IndicadorEstrategico>().ReverseMap();
            CreateMap<GetMetaEstrategicaByIdResponse, IndicadorEstrategico>().ReverseMap();
            CreateMap<UpdateMetaEstrategicaCommand, IndicadorEstrategico>().ReverseMap();

        }
    }
}
