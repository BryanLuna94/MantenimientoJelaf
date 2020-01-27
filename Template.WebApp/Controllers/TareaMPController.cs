using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("TareaMP")]
    public class TareaMPController : Controller
    {           // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListTareaMP(short IdTipMan)
        {
            var res = await _ServiceMantenimiento.ListTareaMPAsync(IdTipMan);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SelectTareaMP(short IdTarea)
        {
            var res = await _ServiceMantenimiento.SelectTareaMPAsync(IdTarea);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> IdTareaMP()
        {
            var res = await _ServiceMantenimiento.IdTareaMPAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteTareaMP(short IdTarea)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteTareaMPAsync(IdTarea);


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

        public async Task<ActionResult> InsertTareaMP(short IdTipMan,
            string Descripcion, int Flg_Revision, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant)
        {
            try
            {
                short UsuarioRegistro = (short)DataSession.UserLoggedIn.Codigo;
                string FechaRegistro = System.DateTime.Now.ToShortDateString();
                var res = await _ServiceMantenimiento.InsertTareaMPAsync(IdTipMan, Descripcion, UsuarioRegistro,
                    FechaRegistro, Flg_Revision, ID_tb_Sistema_Mant, ID_tb_SubSistema_Mant);

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

        public async Task<ActionResult> UpdateTareaMP(short IdTarea, short IdTipMan,
            string Descripcion, int Flg_Revision, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant)
        {

            try
            {
                var res = await _ServiceMantenimiento.UpdateTareaMPAsync(IdTarea, IdTipMan, Descripcion, Flg_Revision, ID_tb_Sistema_Mant, ID_tb_SubSistema_Mant);
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