using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Presupuesto.DatosT5.Commands.Create;
using WordVision.ec.Application.Features.Presupuesto.DatosT5.Queries.GetAllCached;
using WordVision.ec.Domain.Entities.Presupuesto;

namespace WordVision.ec.Application.Mappings.Presupuesto
{
    internal class DatosT5Profile:Profile
    {
        public DatosT5Profile()
        {
            CreateMap<CreateDatosT5Command, DatosT5>().ReverseMap();
            //CreateMap<GetColaboradorByIdResponse, Colaborador>().ReverseMap();
            CreateMap<GetAllDatosT5sCachedResponse, DatosT5>().ReverseMap();
            //CreateMap<GetAllColaboradoresResponse, Colaborador>().ReverseMap();
        }
    }
}
