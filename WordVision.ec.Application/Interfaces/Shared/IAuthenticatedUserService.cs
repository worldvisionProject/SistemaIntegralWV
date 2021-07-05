using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Interfaces.Shared
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
        public string Username { get; }
    }
}
