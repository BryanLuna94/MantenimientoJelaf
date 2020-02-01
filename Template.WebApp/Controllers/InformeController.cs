using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using Newtonsoft.Json;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("Informe")]
    public class InformeController : Controller
    {
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListInforme(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<InformeRequest>(json);

                var usuarioActual = DataSession.UserLoggedIn;
                request.Filtro.NivelUsuario = usuarioActual.Nivel.ToString();

                var res = await _ServiceMantenimiento.ListInformeAsync(request);
                return Json(res, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ActionResult> SelectInforme(int IdInforme)
        {
            var res = await _ServiceMantenimiento.SelectInformeAsync(IdInforme);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SelectInformeCambiar(decimal NumeroInforme, string TipoInforme, int TipoU)
        {
            var res = await _ServiceMantenimiento.SelectInformeCorrectivoPreventivoTractoCarretaAsync(NumeroInforme, TipoInforme, TipoU);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListInformeTareas(int IdInforme)
        {
            try
            {
                var res = await _ServiceMantenimiento.ListInformeTareasAsync(IdInforme);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<ActionResult> InsertInformeTarea(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<InformeRequest>(json);
                request.InformeTareas.UsuarioRegistro = DataSession.UserLoggedIn.Codigo;

                var res = await _ServiceMantenimiento.InsertInformeTareasAsync(request);

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

        public async Task<ActionResult> DeleteInformeTarea(int IdInforme, int IdTarea)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteInformeTareasAsync(IdInforme, IdTarea);

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

        public async Task<ActionResult> UpdateInformeTarea(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<InformeRequest>(json);
                request.InformeTareas.UsuarioRegistro = DataSession.UserLoggedIn.Codigo;

                var res = await _ServiceMantenimiento.UpdateInformeTareasAsync(request);

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

        #region MECANICOS

        [HttpGet]
        public async Task<ActionResult> ListTareaMecanico(int IdInforme, int IdTarea)
        {
            try
            {
                var res = await _ServiceMantenimiento.ListTareaMecanicoAsync(IdInforme, IdTarea);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<ActionResult> InsertTareaMecanico(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<InformeRequest>(json);
                request.TareaMecanico.UsuarioRegistro = DataSession.UserLoggedIn.Codigo;

                var res = await _ServiceMantenimiento.InsertTareaMecanicoAsync(request);

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

        public async Task<ActionResult> DeleteTareaMecanico(int IdTareaMecanico)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteTareaMecanicoAsync(IdTareaMecanico);

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

        public async Task<ActionResult> UpdateTareaMecanico(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<InformeRequest>(json);
                request.TareaMecanico.UsuarioRegistro = DataSession.UserLoggedIn.Codigo;

                var res = await _ServiceMantenimiento.UpdateTareaMecanicoAsync(request);

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

        #endregion

        #region AYUDANTE

        [HttpGet]
        public async Task<ActionResult> ListTareaMecanicosAyudante(int IdTareaMecanico)
        {
            try
            {
                var res = await _ServiceMantenimiento.ListTareaMecanicosAyudanteAsync(IdTareaMecanico);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<ActionResult> InsertTareaMecanicosAyudante(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<InformeRequest>(json);

                var res = await _ServiceMantenimiento.InsertTareaMecanicosAyudanteAsync(request);

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

        public async Task<ActionResult> DeleteTareaMecanicosAyudante(int IdAyudante)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteTareaMecanicosAyudanteAsync(IdAyudante);

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

        #endregion

        #region ARTICULO

        [HttpGet]
        public async Task<ActionResult> BusquedaArticulo(string CodAlmacen)
        {
            try
            {
                var usuarioSesion = DataSession.UserLoggedIn;
                var res = await _ServiceMantenimiento.BusquedaArticuloAsync(usuarioSesion.Codi_Empresa.ToString("0#"), CodAlmacen);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet]
        public async Task<ActionResult> AgregarBolsa(string CodAlmacen, int IdTarea, int IdInforme)
        {
            try
            {
                var res = await _ServiceMantenimiento.AgregarBolsasAsync(CodAlmacen, IdTarea, IdInforme);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<ActionResult> InsertBolsa(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<InformeRequest>(json);

                var res = await _ServiceMantenimiento.InsertBolsasAsync(request);

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

        #endregion
    }
}