using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using Newtonsoft.Json;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("OrdenMasiva")]
    public class OrdenMasivaController : Controller
    {
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: OrdenMasiva
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListOrdenMasiva(string json)
        {

            var request = JsonConvert.DeserializeObject<OrdenMasivaRequest>(json);

            var res = await _ServiceMantenimiento.ListOrdenMasivaAsync(request);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        
        public async Task<ActionResult> GenerarCorrectivo(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<OrdenMasivaRequest>(json);
                request.UsuarioRegistro = DataSession.UserLoggedIn.Codigo.ToString();

                var res = await _ServiceMantenimiento.InsertCorrectivoAsync(request);

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

        public async Task<ActionResult> AnularCorrectivo(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<OrdenMasivaRequest>(json);

                var res = await _ServiceMantenimiento.AnularCorrectivoAsync(request);

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

        public async Task<ActionResult> GenerarPreventivo(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<OrdenMasivaRequest>(json);
                request.UsuarioRegistro = DataSession.UserLoggedIn.Codigo.ToString();

                var res = await _ServiceMantenimiento.InsertPreventivoAsync(request);

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

        public async Task<ActionResult> AnularPreventivo(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<OrdenMasivaRequest>(json);

                var res = await _ServiceMantenimiento.AnularPreventivoAsync(request);

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