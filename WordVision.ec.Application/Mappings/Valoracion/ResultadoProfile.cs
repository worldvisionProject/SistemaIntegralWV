using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Valoracion.Resultados.Queries.GetAllCached;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Mappings.Valoracion
{
    public class ResultadoProfile : Profile
    {
        public ResultadoProfile()
        {
            //CreateMap<CreateSeguimientoCommand, Resultado>().ReverseMap();
            CreateMap<GetAllResultadosCachedResponse, Resultado>().ReverseMap();


        }
    }
}
