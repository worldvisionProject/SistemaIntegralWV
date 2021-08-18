using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Queries.GetById;
using WordVision.ec.Application.Features.Registro.TechoPresupuestarios.Queries.GetAllCached;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    public class TechoPresupuestarioProfile: Profile
    {
        public TechoPresupuestarioProfile()
        {
            CreateMap<CreateTechoPresupuestarioCommand, TechoPresupuestarioViewModel>().ReverseMap();
            CreateMap<GetTechoPresupuestarioByIdResponse, TechoPresupuestarioViewModel>().ReverseMap();
            CreateMap<UpdateTechoPresupuestarioCommand, TechoPresupuestarioViewModel>().ReverseMap();
            CreateMap<TechoPresupuestario, TechoPresupuestarioViewModel>().ReverseMap();
            CreateMap<GetAllTechoPresupuestariosResponse, TechoPresupuestarioViewModel>().ReverseMap();


        }
    }
}
