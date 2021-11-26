using AutoMapper;
using WordVision.ec.Application.Features.Presupuesto.DatosT5.Commands.Create;
using WordVision.ec.Application.Features.Presupuesto.DatosT5.Queries.GetAllCached;
using WordVision.ec.Web.Areas.Presupuesto.Models;

namespace WordVision.ec.Web.Areas.Presupuesto.Mappings
{
    public class DatosT5Profile : Profile
    {
        public DatosT5Profile()
        {
            CreateMap<GetAllDatosT5sCachedResponse, DatosT5ViewModel>().ReverseMap();
            //CreateMap<GetColaboradorByIdResponse, ColaboradorViewModel>().ReverseMap();
            CreateMap<CreateDatosT5Command, DatosT5ViewModel>().ReverseMap();
            //CreateMap<UpdateColaboradorCommand, ColaboradorViewModel>().ReverseMap();
        }
    }
}
