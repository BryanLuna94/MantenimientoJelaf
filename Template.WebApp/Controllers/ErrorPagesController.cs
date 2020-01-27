using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    public class ErrorPagesController : Controller
    {
        // GET: ErrorPages
        public ActionResult NotFound404()
        {
            return View();
        }

        public ActionResult NotFound500()
        {
            return View();
        }
    }
}