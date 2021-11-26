using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class ProductoObjetivoProfile : Profile
    {
        public ProductoObjetivoProfile()
        {
            CreateMap<CreateProductoObjetivoCommand, ProductoObjetivo>().ReverseMap();
            CreateMap<GetProductoObjetivoByIdResponse, ProductoObjetivo>().ReverseMap();
            CreateMap<UpdateProductoObjetivoCommand, ProductoObjetivo>().ReverseMap();

        }
    }
}
