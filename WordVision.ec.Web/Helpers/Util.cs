namespace WordVision.ec.Web.Helpers
{
    public class Util
    {
        /// <summary>
        /// Creates an instance of an MVC controller from scratch 
        /// when no existing ControllerContext is present       
        /// </summary>
        /// <typeparam name="T">Type of the controller to create</typeparam>
        /// <returns>Controller Context for T</returns>
        /// <exception cref="InvalidOperationException">thrown if HttpContext not available</exception>
        //public static T CreateController<T>(RouteData routeData = null)
        //            where T : Controller, new()
        //{
        //    // create a disconnected controller instance
        //    T controller = new T();

        //    // get context wrapper from HttpContext if available
        //    HttpContextBase wrapper = null;
        //    if (HttpContext.Current != null)
        //        wrapper = new HttpContextWrapper(System.Web.HttpContext.Current);
        //    else
        //        throw new InvalidOperationException(
        //            "Can't create Controller Context if no active HttpContext instance is available.");

        //    if (routeData == null)
        //        routeData = new RouteData();

        //    // add the controller routing if not existing
        //    if (!routeData.Values.ContainsKey("controller") && !routeData.Values.ContainsKey("Controller"))
        //        routeData.Values.Add("controller", controller.GetType().Name
        //                                                    .ToLower()
        //                                                    .Replace("controller", ""));

        //    controller.ControllerContext = new ControllerContext(wrapper, routeData, controller);
        //    return controller;
        //}
    }
}
