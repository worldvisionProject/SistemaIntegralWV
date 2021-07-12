using Microsoft.AspNetCore.Mvc;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Views.Shared.Components.Title
{
    public class TitleViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (ViewBag.SNGestion ==null)
            {
                var estrategico = new EstrategiaNacionalViewModel();
                return View(estrategico);
            }
            else
                return View();
        }
    }
}