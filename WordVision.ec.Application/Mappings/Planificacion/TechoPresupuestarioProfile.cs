using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Queries.GetById;
using WordVision.ec.Application.Features.Registro.TechoPresupuestarios.Queries.GetAllCached;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class TechoPresupuestarioProfile : Profile
    {
        public TechoPresupuestarioProfile()
        {
            CreateMap<CreateTechoPresupuestarioCommand, TechoPresupuestario>().ReverseMap();
            CreateMap<GetTechoPresupuestarioByIdResponse, TechoPresupuestario>().ReverseMap();
            CreateMap<UpdateTechoPresupuestarioCommand, TechoPresupuestario>().ReverseMap();
            CreateMap<GetAllTechoPresupuestariosResponse, TechoPresupuestario>().ReverseMap();

        }
    }
}
