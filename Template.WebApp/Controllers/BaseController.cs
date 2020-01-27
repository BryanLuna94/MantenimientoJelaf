using Mantenimiento.WebApp.ServiceMantenimiento;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    public class BaseController : Controller
    {
        // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();


        // GET: Base
        [HttpGet]
        public async Task<ActionResult> ListUsuariosAutocomplete(string value)
        {
            var res = await _ServiceMantenimiento.ListUsuariosAutocompleteAsync(value);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> ListSistemasAutocomplete(string value)
        {
            var res = await _ServiceMantenimiento.ListSistemasAutocompleteAsync(value);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> ListSubSistemasAutocomplete(string value)
        {
            var res = await _ServiceMantenimiento.ListSubSistemasAutocompleteAsync(value);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> ListTipoMAutocomplete(string value)
        {
            var res = await _ServiceMantenimiento.ListTipoMAutocompleteAsync(value);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> ListEmpresa()
        {
            var res = await _ServiceMantenimiento.ListEmpresaAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public async Task<ActionResult> ListFlotaAutocomplete(string value)
        {
            var res = await _ServiceMantenimiento.ListFlotaAutocompleteAsync(value);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListBeneficiarioAutocomplete(string value)
        {
            var res = await _ServiceMantenimiento.ListBeneficiarioAutocompleteAsync(value);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListPlanAccionAutocomplete(string value)
        {
            var res = await _ServiceMantenimiento.ListPlanAccionAutocompleteAsync(value);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListPlataformaAutocomplete(string value)
        {
            var res = await _ServiceMantenimiento.ListPlataformaAutocompleteAsync(value);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListTareasAutocomplete(string value)
        {
            var res = await _ServiceMantenimiento.ListTareasAutocompleteAsync(value);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListPuntoAtencionAutocomplete(string value)
        {
            var res = await _ServiceMantenimiento.ListPuntoAtencionAutocompleteAsync(value);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}