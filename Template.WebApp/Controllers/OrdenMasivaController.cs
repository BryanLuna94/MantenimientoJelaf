using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.Reports;
using Mantenimiento.WebApp.ServiceMantenimiento;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("OrdenMasiva")]
    [SessionExpire]
    public class OrdenMasivaController : Controller
    {
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();
        // GET: OrdenMasiva
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report()
        {
            List<BaseEntity> listEmpresas = _ServiceMantenimiento.ListEmpresa().Valor.List;
            List<TareasPendientesList> TareasPendientesList = new List<TareasPendientesList>();
            TareasPendientesList = _ServiceMantenimiento.ListTareasPendientes("").Valor.ListTareasPendientes;
            PreventivosPendientesReport preventivosPendientesReport = new PreventivosPendientesReport();
            byte[] abytes = preventivosPendientesReport.PrepareReport(TareasPendientesList, listEmpresas);

            return File(abytes, "application/pdf");
        }

        public ActionResult ReportPlantillaTemp(string are_codigo, string codigo_programacion_real, string Id_ClaseMantenimiento)
        {
            Session["AreCodigoTemp"] = are_codigo;
            Session["CodigoProgramacionRealTemp"] = codigo_programacion_real;
            Session["IdClaseMantenimientoTemp"] = Id_ClaseMantenimiento;
            return RedirectToAction("ReportPlantilla", "OrdenMasiva");
        }

        public ActionResult ReportPlantilla()
        {
            string are_codigo = Session["AreCodigoTemp"].ToString();
            string codigo_programacion_real = Session["CodigoProgramacionRealTemp"].ToString();
            string Id_ClaseMantenimiento = Session["IdClaseMantenimientoTemp"].ToString();

            List<AreEntity> ListAreBus = _ServiceMantenimiento.ListAreBus(are_codigo, codigo_programacion_real).Valor.ListAreEntity;
            List<TareaSistemaEntity> ListTareaSistemaEntity = _ServiceMantenimiento.ListTareaSistema(are_codigo, Id_ClaseMantenimiento).Valor.ListTareaSistemaEntity;
            ListTareaSistemaEntity = ListTareaSistemaEntity.Where(s => s.Activo == 1).ToList();
            TareasSistemaReport tareasSistemaReport = new TareasSistemaReport();
            byte[] abytes = tareasSistemaReport.PrepareReport(ListAreBus, ListTareaSistemaEntity);

            return File(abytes, "application/pdf");
        }

        [HttpGet]
        public async Task<ActionResult> ListOrdenMasiva(string json)
        {

            var request = JsonConvert.DeserializeObject<OrdenMasivaRequest>(json);

            var res = await _ServiceMantenimiento.ListOrdenMasivaAsync(request);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListTareasPendientes(string are_codigo)
        {
            var res = await _ServiceMantenimiento.ListTareasPendientesAsync(are_codigo);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListAreBus(string are_codigo,string codigo_programacion_real)
        {
            var res = await _ServiceMantenimiento.ListAreBusAsync(are_codigo, codigo_programacion_real);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListTipoUnidad(string tbg_codigo)
        {
            var res = await _ServiceMantenimiento.ListTipoUnidadAutocompleteAsync(tbg_codigo);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GenerarCorrectivo(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<OrdenMasivaRequest>(json);
                request.UsuarioRegistro = DataSession.UserLoggedIn.Codigo.ToString();

                var res = await _ServiceMantenimiento.InsertCorrectivoAsync(request);

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

        public async Task<ActionResult> GuardarTareas(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<TareaSistemaRequest>(json);
              
                var res = await _ServiceMantenimiento.InsertTareasSistemasAsync(request);

                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (FaultException<ServiceErrorResponse> ex)
            {
                return Json(NotifyJson.BuildJson(KindOfNotify.Warning, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(NotifyJson.BuildJson(KindOfNotify.Danger, ex.Message), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> AnularCorrectivo(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<OrdenMasivaRequest>(json);

                var res = await _ServiceMantenimiento.AnularCorrectivoAsync(request);

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

        public async Task<ActionResult> GenerarPreventivo(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<OrdenMasivaRequest>(json);
                request.UsuarioRegistro = DataSession.UserLoggedIn.Codigo.ToString();

                var res = await _ServiceMantenimiento.InsertPreventivoAsync(request);

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

        public async Task<ActionResult> AnularPreventivo(string json)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<OrdenMasivaRequest>(json);

                var res = await _ServiceMantenimiento.AnularPreventivoAsync(request);

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

        public async Task<ActionResult> SelectInformePorNumero(decimal NumeroInforme, string Tipo)
        {
            try
            {
                var res = await _ServiceMantenimiento.SelectInformePorNumeroAsync(NumeroInforme, Tipo);
                Session["IdInforme"] = res.Valor.Informe.IdInforme;
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