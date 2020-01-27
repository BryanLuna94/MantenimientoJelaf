using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("ClaseMP")]
    public class ClaseMPController : Controller
    {
        // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();

        [HttpGet]
        public async Task<ActionResult> ListClaseMP()
        {
            var res = await _ServiceMantenimiento.ListClaseMPAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}