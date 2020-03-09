using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("Sistemas")]
    [SessionExpire]
    public class SistemasController : Controller
    {           // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> SelectSistemas()
        {
            var res = await _ServiceMantenimiento.SelectSistemasAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> ListSistemas(short ID_tb_Sistema_Mant)
        {
            var res = await _ServiceMantenimiento.ListSistemasAsync(ID_tb_Sistema_Mant);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> IdSistemas()
        {
            var res = await _ServiceMantenimiento.IdSistemasAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteSistemas(short ID_tb_Sistema_Mant)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteSistemasAsync(ID_tb_Sistema_Mant);
               

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

        public async Task<ActionResult> InsertSistemas(short ID_tb_Sistema_Mant,string Descripcion)
        {
            try
            {
                var res = await _ServiceMantenimiento.InsertSistemasAsync(ID_tb_Sistema_Mant, Descripcion);


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

        public async Task<ActionResult> UpdateSistemas(short ID_tb_Sistema_Mant, string Descripcion)
        {
            try
            {
                var res = await _ServiceMantenimiento.UpdateSistemasAsync(ID_tb_Sistema_Mant, Descripcion);


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