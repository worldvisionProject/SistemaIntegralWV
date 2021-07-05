using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Presupuesto.Presupuesto.Commands.Create;
using WordVision.ec.Application.Features.Presupuesto.Presupuesto.Queries.GetAllCached;
using WordVision.ec.Web.Areas.Presupuesto.Models;

namespace WordVision.ec.Web.Areas.Presupuesto.Mappings
{
    public class PresupuestoProfile : Profile
    {
        public PresupuestoProfile()
        {
           
            CreateMap<CreatePresupuestoCommand, PresupuestoViewModel>().ReverseMap();
            CreateMap<GetAllPresupuestosCachedResponse, PresupuestoViewModel>().ReverseMap();
        }
    }
}
