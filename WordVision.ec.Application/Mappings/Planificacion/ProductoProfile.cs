using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.Productos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Productos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<CreateProductoCommand, Producto>().ReverseMap();
            CreateMap<GetProductoByIdResponse, Producto>().ReverseMap();
            CreateMap<GetAllProductosCachedQuery, Producto>().ReverseMap();
            CreateMap<UpdateProductoCommand, Producto>().ReverseMap();
            CreateMap<GetAllProductosCachedResponse, Producto>().ReverseMap();

        }
    }
}
