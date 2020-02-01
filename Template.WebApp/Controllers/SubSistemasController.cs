using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("SubSistemas")]
    public class SubSistemasController : Controller
    {           // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListSubSistemas()
        {
            var res = await _ServiceMantenimiento.ListSubSistemasAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SelectSubSistemas(string ID_tb_SubSistema_Mant)
        {
            var res = await _ServiceMantenimiento.SelectSubSistemasAsync(ID_tb_SubSistema_Mant);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> IdSubSistemas(short ID_tb_Sistema_Mant)
        {
            var res = await _ServiceMantenimiento.IdSubSistemasAsync(ID_tb_Sistema_Mant);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteSubSistemas(string ID_tb_SubSistema_Mant)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteSubSistemasAsync(ID_tb_SubSistema_Mant);
               

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

        public async Task<ActionResult> InsertSubSistemas(string ID_tb_SubSistema_Mant, short ID_tb_Sistema_Mant, string Descripcion)
        {
            try
            {
                var res = await _ServiceMantenimiento.InsertSubSistemasAsync(ID_tb_SubSistema_Mant, ID_tb_Sistema_Mant,Descripcion);


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

        public async Task<ActionResult> UpdateSubSistemas(string ID_tb_SubSistema_Mant, short ID_tb_Sistema_Mant, string Descripcion)
        {
            try
            {
                var res = await _ServiceMantenimiento.UpdateSubSistemasAsync(ID_tb_SubSistema_Mant, ID_tb_Sistema_Mant, Descripcion);


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