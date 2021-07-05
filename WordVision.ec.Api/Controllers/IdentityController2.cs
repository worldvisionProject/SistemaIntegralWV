using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Api.Identity;

namespace WordVision.ec.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController2 : Controller
    {
        private IUserProvider provider;

        public IdentityController2(IUserProvider provider)
        {
            this.provider = provider;
        }

        [HttpGet("[action]")]
        public async Task<List<AdUser>> GetDomainUsers() => await provider.GetDomainUsers();

        [HttpGet("[action]/{search}")]
        public async Task<List<AdUser>> FindDomainUser([FromRoute] string search) => await provider.FindDomainUser(search);

        [HttpGet("[action]")]
        public AdUser GetCurrentUser() => provider.CurrentUser;
    }
}
