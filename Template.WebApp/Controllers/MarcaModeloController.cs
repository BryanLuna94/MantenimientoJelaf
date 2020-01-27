using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("MarcaModelo")]
    public class MarcaModeloController : Controller
    {           // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListMarcaModelo()
        {
            var res = await _ServiceMantenimiento.ListMarcaModeloAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        } 

    }
}