using System.Web.Mvc;
using System.Web.Routing;

namespace Mantenimiento.WebApp.Helpers
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Validar la información que se encuentra en la sesión.
            if (DataSession.UserLoggedIn == null || DataSession.UserLoggedIn.Nombre == null)
            {
                // Si la información es nula, redireccionar a 
                // página de error u otra página deseada.
                var ruta = filterContext.RequestContext.HttpContext.Request.Url.AbsolutePath;
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                   {
                           { "action", "Login" },
                           { "controller", "Autenticacion" },
                           { "Area", string.Empty },
                           { "returnUrl", ruta }
                   });
            }

            base.OnActionExecuting(filterContext);
        }
    }

    public class SessionExpire : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (DataSession.UserLoggedIn.Codigo == 0 || string.IsNullOrEmpty(DataSession.UserLoggedIn.Nombre))
            {
                if (!filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Login" }, { "controller", "Autenticacion" } });
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Autenticacion/AjaxSessionExpired");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}