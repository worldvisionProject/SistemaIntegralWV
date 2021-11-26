using AutoMapper;
using WordVision.ec.Application.Features.Registro.DashBoards.Queries.GetAllDashBoards;
using WordVision.ec.Web.Areas.Dashboard.Models;

namespace WordVision.ec.Web.Areas.Dashboard.Mappings
{
    internal class DashBoardProfile : Profile
    {
        public DashBoardProfile()
        {
            CreateMap<GetDashBoardsResponse, RegistroDashBoardViewModel>().ReverseMap();

        }
    }
}
