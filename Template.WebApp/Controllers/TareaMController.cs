using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("TareaM")]
    public class TareaMController : Controller
    {           // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListTareaM()
        {
            var res = await _ServiceMantenimiento.ListTareaMAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SelectTareaM(short IdTarea)
        {
            var res = await _ServiceMantenimiento.SelectTareaMAsync(IdTarea);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> IdTareaM()
        {
            var res = await _ServiceMantenimiento.IdTareaMAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteTareaM(short IdTarea)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteTareaMAsync(IdTarea);
               

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

        public async Task<ActionResult> InsertTareaM(short IdTarea,short IdTipMan, string Descripcion,short UsuarioRegistro, string FechaRegistro, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant)
        {
            try
            {
                var res = await _ServiceMantenimiento.InsertTareaMAsync(IdTarea,IdTipMan, Descripcion, UsuarioRegistro, FechaRegistro, ID_tb_Sistema_Mant, ID_tb_SubSistema_Mant);


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

        public async Task<ActionResult> UpdateTareaM(short IdTarea, short IdTipMan, string Descripcion, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant)
        {
             
            try
            {
                var res = await _ServiceMantenimiento.UpdateTareaMAsync(IdTarea, IdTipMan, Descripcion, ID_tb_Sistema_Mant, ID_tb_SubSistema_Mant);

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