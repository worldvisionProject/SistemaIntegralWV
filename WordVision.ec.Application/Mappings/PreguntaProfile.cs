using AutoMapper;
using WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetById;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Mappings
{
    internal class PreguntaProfile : Profile
    {
        public PreguntaProfile()
        {
            //CreateMap<CreatePreguntaCommand, Pregunta>().ReverseMap();
            CreateMap<GetPreguntaByIdResponse, Pregunta>().ReverseMap();
            CreateMap<GetAllPreguntasCachedResponse, Pregunta>().ReverseMap();
            CreateMap<GetPreguntasByIdDocumentoResponse, Pregunta>().ReverseMap();
            //CreateMap<GetAllPreguntasResponse, Pregunta>().ReverseMap();
        }
    }
}
