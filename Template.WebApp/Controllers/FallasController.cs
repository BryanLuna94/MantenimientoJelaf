using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("Fallas")]
    public class FallasController : Controller
    {           // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> SelectFallasD(string ID)
        {
            var res = await _ServiceMantenimiento.SelectFallasDAsync(ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> IdFallasD()
        {
            var res = await _ServiceMantenimiento.IdFallasDAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteFallasD(string ID)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteFallasDAsync(ID);


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

        public async Task<ActionResult> InsertFallasD(string IdSolicitudRevisionD, string IdSolicitudRevision, string Observacion,
            string UsuarioRegistro, string FechaRegistro, string HoraRegistro, int Estado, int IdSistema, int IdObservacion)
        {
            try
            {
                var res = await _ServiceMantenimiento.InsertFallasDAsync( IdSolicitudRevisionD,  IdSolicitudRevision,  Observacion,
             UsuarioRegistro,  FechaRegistro,  HoraRegistro,  Estado,  IdSistema,  IdObservacion);


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