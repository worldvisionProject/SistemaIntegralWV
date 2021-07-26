using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllPaged;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Create;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Mappings
{
    internal class ColaboradorProfile : Profile
    {
        public ColaboradorProfile()
        {
            CreateMap<CreateColaboradorCommand, Colaborador>().ReverseMap();
            CreateMap<GetColaboradorByIdResponse, Colaborador>().ReverseMap();
            CreateMap<GetAllColaboradoresCachedResponse, Colaborador>()
                .ReverseMap();
            CreateMap<GetAllColaboradoresResponse, Colaborador>().ReverseMap();
        }
    }
}
