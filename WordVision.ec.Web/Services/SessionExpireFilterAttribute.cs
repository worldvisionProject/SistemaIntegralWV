using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace WordVision.ec.Web.Services
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

           // Validar la información que se encuentra en la sesión.
            if (HttpContext..Session.GetString("Name") == null)
            {
                // Si la información es nula, redireccionar a 
                // página de error u otra página deseada.
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                    { "Controller", "Home" },
                    { "Action", "TimeoutRedirect" }
                });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}