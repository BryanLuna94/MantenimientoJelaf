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
            try
            {
                var res = await _ServiceMantenimiento.SelectInformeAsync(IdInforme);
                Session.Remove("IdInforme");
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

        public async Task<ActionResult> SelectInformeCambiar(decimal NumeroInforme, string TipoInforme, int TipoU)
        {
            var res = await _ServiceMantenimiento.SelectInformeCorrectivoPreventivoTractoCarretaAsync(NumeroInforme, TipoInforme, TipoU);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> AnularInforme(int IdInforme)
        {
            try
            {
                var res = await _ServiceMantenimiento.AnularInformeAsync(IdInforme);

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

        [HttpGet]
        public async Task<ActionResult> ListInformeTareasBackLog(string IdUnidad, string Tipo)
        {
            try
            {
                var res = await _ServiceMantenimiento.ListInformeTareasBackLogAsync(IdUnidad, Tipo);
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

        public async Task<ActionResult> DeleteInformeTarea(int IdInforme, int IdTarea, int IdTipMan, string AreCodigo)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteInformeTareasAsync(IdInforme, IdTarea, IdTipMan, AreCodigo);

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

        public async Task<ActionResult> UpdateInformeTareaEstado(int IdInforme, int IdTarea, int Estado)
        {
            try
            {
                var res = await _ServiceMantenimiento.UpdateInformeTareasEstadoAsync(IdInforme, IdTarea, Estado);

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

        public async Task<ActionResult> UpdateInformeTareasReasignarInforme(int IdInformeNuevo, int IdInformeAnterior, int IdTarea)
        {
            try
            {
                var res = await _ServiceMantenimiento.UpdateInformeTareasReasignarInformeAsync(IdInformeNuevo, IdInformeAnterior, IdTarea);

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
        public async Task<ActionResult> ListBolsas(decimal IdInforme, string Cod_Ben)
        {
            try
            {
                var res = await _ServiceMantenimiento.ListBolsasAsync(IdInforme, Cod_Ben);
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
                var usuarioSesion = DataSession.UserLoggedIn;

                var request = JsonConvert.DeserializeObject<InformeRequest>(json);

                request.ODM.Usr_Codigo = usuarioSesion.Codigo.ToString("000#");
                request.ODM.Ben_Codigo_Jefe = usuarioSesion.Ben_Codigo;
                request.ODM.Emp_Codigo = usuarioSesion.Codi_Empresa.ToString("0#");
                request.ODM.Suc_Codigo = usuarioSesion.Sucursal.ToString("00#"); ;
                request.ODM.Ofi_Codigo = usuarioSesion.Sucursal.ToString("00#"); ;

                var res = await _ServiceMantenimiento.InsertBolsaAsync(request);

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

        public async Task<ActionResult> AgregarBolsas(string json)
        {
            try
            {
                var usuarioSesion = DataSession.UserLoggedIn;

                var request = JsonConvert.DeserializeObject<InformeRequest>(json);

                request.ODM.Usr_Codigo = usuarioSesion.Codigo.ToString("000#");
                request.ODM.Ben_Codigo_Jefe = usuarioSesion.Ben_Codigo;
                request.ODM.Emp_Codigo = usuarioSesion.Codi_Empresa.ToString("0#");
                request.ODM.Suc_Codigo = usuarioSesion.Sucursal.ToString("00#"); ;
                request.ODM.Ofi_Codigo = usuarioSesion.Sucursal.ToString("00#"); ;

                var res = await _ServiceMantenimiento.AgregarBolsasAsync(request);

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

        public async Task<ActionResult> DeleteBolsa(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<InformeRequest>(json);

                var res = await _ServiceMantenimiento.DeleteBolsaAsync(request);

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