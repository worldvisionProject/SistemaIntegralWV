using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.Productos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Productos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<CreateProductoCommand, ProductoViewModel>().ReverseMap();
            CreateMap<GetProductoByIdResponse, ProductoViewModel>().ReverseMap();
            CreateMap<GetAllProductosCachedResponse, ProductoViewModel>().ReverseMap();
            CreateMap<UpdateProductoCommand, ProductoViewModel>().ReverseMap();
            CreateMap<ProductoViewModel, Producto>().ReverseMap();
          
        }
    }
}
