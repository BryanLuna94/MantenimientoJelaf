using System.Web.Mvc;
using System.Web.Routing;

namespace Mantenimiento.WebApp.Helpers
{
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