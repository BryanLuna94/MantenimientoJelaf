using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("Perfil")]
    public class PerfilController : Controller
    {           // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<ActionResult> Actualizapwd(string codiUsuario, string Password)
        {
            try
            {
                var res = await _ServiceMantenimiento.ActualizapwdAsync(codiUsuario, Password);
               

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

       
        [HttpGet]
        public ActionResult Redirect()
        {
            return RedirectToAction("Index", "Perfil");
        }
        public ActionResult Logout()
        {
            DataSession.UserLoggedIn = null;
            return RedirectToAction("Login", "Autenticacion");
        }

    }
}