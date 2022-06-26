using AutoMapper;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ModeloProyecto.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class ModeloProyectoProfile : Profile
    {
        public ModeloProyectoProfile()
        {            
            CreateMap<ModeloProyectoResponse, ModeloProyectoViewModel>().ReverseMap();
            CreateMap<CreateModeloProyectoCommand, ModeloProyectoViewModel>().ReverseMap();
            CreateMap<UpdateModeloProyectoCommand, ModeloProyectoViewModel>().ReverseMap();
        }
        
    }
}
