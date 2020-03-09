using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<ActionResult> ListModeloBuses()
        {
            var res = await _ServiceMantenimiento.ListModeloBusesAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListMarcaBuses()
        {
            var res = await _ServiceMantenimiento.ListMarcaBusesAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListMarcaModeloFiltro(string json)
        {
            var request = JsonConvert.DeserializeObject<MarcaModeloResponse>(json);

            var res = await _ServiceMantenimiento.ListMarcaModeloFiltroAsync(request);

            
            return Json(res, JsonRequestBehavior.AllowGet);
        }

    }
}