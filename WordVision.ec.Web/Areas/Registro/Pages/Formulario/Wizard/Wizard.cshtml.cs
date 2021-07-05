using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
