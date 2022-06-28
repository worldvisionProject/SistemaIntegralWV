using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace WordVision.ec.Web.Services
{
    public class RequestAuthenticationFilterAttribute : ActionFilterAttribute
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RequestAuthenticationFilterAttribute(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = _httpContextAccessor.HttpContext.Session.Get("UserId");
            Controller controller = context.Controller as Controller;

            if (session == null)
            {
               // controller.HttpContext.Response.Redirect("/identity/account/login");
                context.Result = new  RedirectToRouteResult(new RouteValueDictionary(new { action = "Login", controller = "Account", area = "Identity" }));
            }
            base.OnActionExecuting(context);
        }

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    HttpContext ctx = HttpContext.Current;

        //    // check if session is supported
        //    if (ctx.Session != null)
        //    {
        //        // check if a new session id was generated
        //        if (ctx.Session.IsAvailable)
        //        {
        //            // If it says it is a new session, but an existing cookie exists, then it must
        //            // have timed out
        //            string sessionCookie = ctx.Request.Headers["Cookie"];
        //            if ((null != sessionCookie) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
        //            {
        //                ctx.Response.Redirect("~/Error/SessionTimeoutVeiw");
        //            }
        //        }
        //    }
        //    base.OnActionExecuting(filterContext);
        //}

        /// <summary>
        /// OnActionExecuted
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
