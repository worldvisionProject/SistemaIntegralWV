using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Application.DTOs.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}