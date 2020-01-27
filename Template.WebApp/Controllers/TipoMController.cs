using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("TipoM")]
    public class TipoMController : Controller
    {           // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListTipoM()
        {
            var res = await _ServiceMantenimiento.ListTipoMAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SelectTipoM(short IdTipMan)
        {
            var res = await _ServiceMantenimiento.SelectTipoMAsync(IdTipMan);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> IdTipoM()
        {
            var res = await _ServiceMantenimiento.IdTipoMAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteTipoM(short IdTipMan)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteTipoMAsync(IdTipMan);
               

                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (FaultException<ServiceError> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
                return Json(NotifyJson.BuildJson(KindOfNotify.Warning, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(NotifyJson.BuildJson(KindOfNotify.Danger, ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> InsertTipoM(short IdTipMan, string Descripcion,short UsuarioRegistro, string FechaRegistro)
        {
            try
            {
                var res = await _ServiceMantenimiento.InsertTipoMAsync(IdTipMan, Descripcion, UsuarioRegistro, FechaRegistro);


                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (FaultException<ServiceError> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
                return Json(NotifyJson.BuildJson(KindOfNotify.Warning, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(NotifyJson.BuildJson(KindOfNotify.Danger, ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> UpdateTipoM(short IdTipMan, string Descripcion, decimal Kilometros, decimal KilometrosAviso, short Dias,
            short DiasAviso, short Horas, short HorasAviso)
        {
            try
            {
                var res = await _ServiceMantenimiento.UpdateTipoMAsync(IdTipMan, Descripcion, Kilometros, KilometrosAviso, Dias,
             DiasAviso, Horas, HorasAviso);


                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (FaultException<ServiceError> ex)
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