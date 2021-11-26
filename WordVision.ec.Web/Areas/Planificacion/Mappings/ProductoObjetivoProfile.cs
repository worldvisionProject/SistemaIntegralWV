using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Queries.GetById;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    public class ProductoObjetivoProfile : Profile
    {
        public ProductoObjetivoProfile()
        {
            CreateMap<CreateProductoObjetivoCommand, ProductoObjetivoViewModel>().ReverseMap();
            CreateMap<GetProductoObjetivoByIdResponse, ProductoObjetivoViewModel>().ReverseMap();
            CreateMap<UpdateProductoObjetivoCommand, ProductoObjetivoViewModel>().ReverseMap();

        }
    }
}
