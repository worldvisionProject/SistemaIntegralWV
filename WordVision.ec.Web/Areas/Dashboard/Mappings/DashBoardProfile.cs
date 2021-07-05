using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.DashBoards.Queries.GetAllDashBoards;
using WordVision.ec.Web.Areas.Dashboard.Models;

namespace WordVision.ec.Web.Areas.Dashboard.Mappings
{
    internal class DashBoardProfile:Profile
    {
        public DashBoardProfile()
        {
            CreateMap<GetDashBoardsResponse, RegistroDashBoardViewModel>().ReverseMap();
          
        }
    }
}
