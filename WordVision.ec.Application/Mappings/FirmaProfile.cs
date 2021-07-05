using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Firma.Commands.Create;
using WordVision.ec.Application.Features.Registro.Firma.Queries.GetById;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Mappings
{
    internal class FirmaProfile : Profile
    {
        public FirmaProfile()
        {
            CreateMap<CreateFirmaCommand, Firma>().ReverseMap();
            CreateMap<GetFirmaByIdResponse, Firma>().ReverseMap();
           
        }
    }
}
