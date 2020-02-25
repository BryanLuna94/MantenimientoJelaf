using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("ArticuloT")]
    [SessionExpire]
    public class ArticuloTController : Controller
    {           // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> IdArticuloT()
        {
            var res = await _ServiceMantenimiento.IdArticuloTAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> ListArticuloT(short IdTarea)
        {
            var res = await _ServiceMantenimiento.ListArticuloTAsync(IdTarea);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SelectArticuloT(short IdArtTar)
        {
            var res = await _ServiceMantenimiento.SelectArticuloTAsync(IdArtTar);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteArticuloT(short IdArtTar)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteArticuloTAsync(IdArtTar);
               

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

        public async Task<ActionResult> InsertArticuloT(short IdTarea,
            short Cod_Mer, short Cantidad, short Orden)
        {
            try
            {
                var res = await _ServiceMantenimiento.InsertArticuloTAsync(IdTarea, Cod_Mer, Cantidad, Orden);

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

        public async Task<ActionResult> UpdateArticuloT(short IdArtTar, short IdTarea,
            short Cod_Mer, short Cantidad, short Orden)
        {
             
            try
            {
                var res = await _ServiceMantenimiento.UpdateArticuloTAsync(IdArtTar, IdTarea, Cod_Mer, Cantidad, Orden);
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