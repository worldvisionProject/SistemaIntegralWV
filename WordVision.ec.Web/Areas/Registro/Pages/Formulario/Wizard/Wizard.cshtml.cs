using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WordVision.ec.Web.Areas.Registro.Pages.Formulario.Wizard
{
    public class WizardModel : PageModel
    {
        public string Message { get; private set; } = "PageModel in C#";
        public WizardModel()//ContactService service)
        {

        }
        public void OnGet()
        {
            Message += $" Server time is { DateTime.Now }";
        }
    }
}
