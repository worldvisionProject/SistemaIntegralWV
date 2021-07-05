using Microsoft.AspNetCore.Mvc;

namespace WordVision.ec.Web.Views.Shared.Components.Culture
{
    public class CultureViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}