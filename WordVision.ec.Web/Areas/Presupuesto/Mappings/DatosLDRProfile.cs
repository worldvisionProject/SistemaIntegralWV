using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Presupuesto.DatosLDR.Commands.Create;
using WordVision.ec.Application.Features.Presupuesto.DatosLDR.Commands.Update;
using WordVision.ec.Application.Features.Presupuesto.DatosLDR.Queries.GetAllCached;
using WordVision.ec.Web.Areas.Presupuesto.Models;

namespace WordVision.ec.Web.Areas.Presupuesto.Mappings
{
    internal class DatosLDRProfile : Profile
    {
        public DatosLDRProfile()
        {
            CreateMap<GetAllDatosLDRsCachedResponse, DatosLDRViewModel>().ReverseMap();
            //CreateMap<GetColaboradorByIdResponse, ColaboradorViewModel>().ReverseMap();
            CreateMap<CreateDatosLDRCommand, DatosLDRViewModel>().ReverseMap();
            CreateMap<UpdateDatosLDRCommand, DatosLDRViewModel>().ReverseMap();
        }
    }
}
