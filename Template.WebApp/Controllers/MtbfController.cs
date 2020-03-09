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
    [RoutePrefix("Mtbf")]
    [SessionExpire]
    public class MtbfController : Controller
    {
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();

        // GET: Mtbf
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListMtbf(short value)
        {
            var res = await _ServiceMantenimiento.ListMtbfAsync(value);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> RecargarMtbf(short value)
        {
            var res = await _ServiceMantenimiento.ListMtbf_AuxilioMecanicoAsync(value);
            return Json(res, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> InsertMtbf(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<MtbfRequest>(json);

                var res = await _ServiceMantenimiento.InsertMtbfAsync(request);

                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (FaultException<ServiceErrorResponse> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
                return Json(NotifyJson.BuildJson(KindOfNotify.Warning, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(NotifyJson.BuildJson(KindOfNotify.Danger, ex.Message), JsonRequestBehavior.AllowGet);
            }
        }
    }
}