using Microsoft.AspNetCore.Identity;

namespace WordVision.ec.Infrastructure.Data.Identity.Models
{
    public class ApplicationUser : IdentityUser//<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsActive { get; set; } = false;

        public int IdEmpresa { get; set; }

    }
}
