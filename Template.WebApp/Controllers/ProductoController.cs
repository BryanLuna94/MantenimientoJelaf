using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("Producto")]
    public class ProductoController : Controller
    {           // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListProducto(short Index_Compañia, string filtro)
        {
            var res = await _ServiceMantenimiento.ListProductoAsync(Index_Compañia, filtro);
            return Json(res, JsonRequestBehavior.AllowGet);
        } 

    }

}