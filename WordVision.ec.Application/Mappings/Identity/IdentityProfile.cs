using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Identity.Usuarios.Queries.GetAllCached;
using WordVision.ec.Application.Features.Identity.Usuarios.Queries.GetById;
using WordVision.ec.Domain.Entities.Identity;

namespace WordVision.ec.Application.Mappings.Identity
{
    internal class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<GetUsuarioByIdResponse, UsuariosActiveDirectory>().ReverseMap();
            CreateMap<GetAllUsuariosCachedResponse, UsuariosActiveDirectory>().ReverseMap();
            //CreateMap<GetAllUsuariosResponse, UsuariosActiveDirectory>().ReverseMap();
        }
    }
}
