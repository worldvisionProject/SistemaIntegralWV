using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordVision.ec.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthWindowsController : ControllerBase
    {
        private readonly ILogger<AuthWindowsController> _logger;

        public AuthWindowsController(ILogger<AuthWindowsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string> { User.Identity.Name };
        }
    }
}
