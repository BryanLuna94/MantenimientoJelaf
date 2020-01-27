using Mantenimiento.WebApp.Helpers;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [SessionExpire]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}