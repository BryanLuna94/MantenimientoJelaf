using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("ClaseM")]
    public class ClaseMController : Controller
    {           // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListClaseM()
        {
            var res = await _ServiceMantenimiento.ListClaseMAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SelectClaseM(string IdClaseMantenimiento)
        {
            var res = await _ServiceMantenimiento.SelectClaseMAsync(IdClaseMantenimiento);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
 
        [HttpPost]
        public async Task<ActionResult> DeleteClaseM(string IdClaseMantenimiento)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteClaseMAsync(IdClaseMantenimiento);
               

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

        public async Task<ActionResult> InsertClaseM(string IdClaseMantenimiento,string Descripcion, short NroOrden)
        {
            try
            {
                var res = await _ServiceMantenimiento.InsertClaseMAsync(IdClaseMantenimiento, Descripcion,NroOrden);


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

        public async Task<ActionResult> UpdateClaseM(string IdClaseMantenimiento, string Descripcion, short NroOrden)
        {
            try
            {
                var res = await _ServiceMantenimiento.UpdateClaseMAsync(IdClaseMantenimiento, Descripcion, NroOrden);


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
        public async Task<ActionResult> ListClaseMP()
        {
            var res = await _ServiceMantenimiento.ListClaseMPAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

    }
}