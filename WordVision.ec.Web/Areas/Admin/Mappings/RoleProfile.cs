using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WordVision.ec.Web.Areas.Admin.Models;

namespace WordVision.ec.Web.Areas.Admin.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
        }
    }
}
