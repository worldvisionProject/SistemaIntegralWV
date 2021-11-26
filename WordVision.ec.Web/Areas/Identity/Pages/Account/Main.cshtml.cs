using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WordVision.ec.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class MainModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
