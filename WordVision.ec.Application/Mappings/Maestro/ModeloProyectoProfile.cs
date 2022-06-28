using AutoMapper;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Commands.Update;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class ModeloProyectoProfile : Profile
    {
        public ModeloProyectoProfile()
        {
            CreateMap<CreateModeloProyectoCommand, ModeloProyecto>().ReverseMap();
            CreateMap<ModeloProyectoResponse, ModeloProyecto>().ReverseMap();
            CreateMap<UpdateModeloProyectoCommand, ModeloProyecto>().ReverseMap();
            CreateMap<GetAllModeloProyectoQuery, ModeloProyecto>().ReverseMap();
        }
       
    }
}
