using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WordVision.ec.Infrastructure.Data.Identity.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
