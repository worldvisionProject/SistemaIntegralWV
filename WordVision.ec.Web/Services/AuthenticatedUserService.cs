using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Shared;

namespace WordVision.ec.Web.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier) == null ? null : httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            Username = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name) == null ? null : httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name).Value;
        }

        public string UserId { get; }
        public string Username { get; }
    }
}
