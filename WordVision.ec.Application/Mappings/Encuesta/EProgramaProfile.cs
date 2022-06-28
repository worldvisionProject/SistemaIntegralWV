using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EProgramas;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EProgramaProfile : Profile
    {
        public EProgramaProfile()
        {
            CreateMap<GetAllEProgramasResponse, EPrograma>().ReverseMap();
            CreateMap<GetEProgramasByIdResponse, EPrograma>().ReverseMap();
            CreateMap<CreateEProgramaCommand, EPrograma>().ReverseMap();
            CreateMap<UpdateEProgramaCommand, EPrograma>().ReverseMap();
        }

    }
}
