using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("TipoMP")]
    public class TipoMPController : Controller
    {           // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListTipoMP()
        {
            var res = await _ServiceMantenimiento.ListTipoMPAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SelectTipoMP(short IdTipMan)
        {
            var res = await _ServiceMantenimiento.SelectTipoMPAsync(IdTipMan);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> IdTipoMP()
        {
            var res = await _ServiceMantenimiento.IdTipoMPAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteTipoMP(short IdTipMan)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteTipoMPAsync(IdTipMan);


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
        [HttpPost]
        public async Task<ActionResult> InsertTipoMP(short IdTipMan, string Descripcion, decimal Kilometros, decimal KilometrosAviso,
            short Dias, short DiasAviso, short Horas, short HorasAviso, string cod_marca, int cod_modelo)
        {
            try
            {
                short UsuarioRegistro = (short)DataSession.UserLoggedIn.Codigo;
                string FechaRegistro = System.DateTime.Now.ToShortDateString();
                var res = await _ServiceMantenimiento.InsertTipoMPAsync(IdTipMan, Descripcion, Kilometros, KilometrosAviso, UsuarioRegistro, FechaRegistro, Dias, DiasAviso, Horas, HorasAviso, cod_marca, cod_modelo);

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
        [HttpPost]
        public async Task<ActionResult> UpdateTipoMP(short IdTipMan, string Descripcion, decimal Kilometros, decimal KilometrosAviso,
            short Dias, short DiasAviso, short Horas, short HorasAviso)
        {
            try
            {
                var res = await _ServiceMantenimiento.UpdateTipoMPAsync(IdTipMan, Descripcion, Kilometros, KilometrosAviso,
                    Dias, DiasAviso, Horas, HorasAviso);

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