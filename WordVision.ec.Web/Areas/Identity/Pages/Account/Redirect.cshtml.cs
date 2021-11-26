using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WordVision.ec.Web.Abstractions;

namespace WordVision.ec.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RedirectModel : BasePageModel<PageModel>
    {
        public void OnGet()
        {
            _notyf.Information("Bienvenidos!");
            //return View();
            //return RedirectToPage("/Views/AnioFiscal/Index", new { area = "Planificacion" });

        }
    }
}
