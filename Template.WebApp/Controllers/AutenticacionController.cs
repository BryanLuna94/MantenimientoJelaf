using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("Autenticacion")]
    public class AutenticacionController : Controller
    {
        // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();

        // GET: Autenticacion
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string codiUsuario, string password)
        {
            try
            {
                var res = await _ServiceMantenimiento.LoginAsync(codiUsuario, password);
                //Set DataSession
                DataSession.UserLoggedIn = res.Valor.Usuario;

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

        [HttpGet]
        public ActionResult Redirect()
        {
            var usuario = DataSession.UserLoggedIn;
            if (usuario.Ben_Codigo.Substring(0,1) == "C")
            {
                return RedirectToAction("Index", "Fallas");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        public ActionResult Logout()
        {
            DataSession.UserLoggedIn = null;
            return RedirectToAction("Login", "Autenticacion");
        }
    }
}