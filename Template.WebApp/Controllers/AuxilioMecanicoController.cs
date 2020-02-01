using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("AuxilioMecanico")]
    public class AuxilioMecanicoController : Controller
    {
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListAuxilioMecanico(string fechainicio, string fechafin, string are_codigo, string ben_codigo)
        {

            var request = new AuxilioMecanicoRequest
            {
                Filtro = new AuxilioMecanicoFilter
                {
                    Are_codigo = are_codigo,
                    Ben_codigo = ben_codigo,
                    FechaFin = HelperFunctions.ValidarFechaStr(fechafin),
                    FechaInicio = HelperFunctions.ValidarFechaStr(fechainicio)
                }
            };

            var res = await _ServiceMantenimiento.ListAuxilioMecanicoAsync(request);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SelectAuxilioMecanico(int IdAuxilioMecanico)
        {
            var res = await _ServiceMantenimiento.SelectAuxilioMecanicoAsync(IdAuxilioMecanico);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteAuxilioMecanico(int IdAuxilioMecanico)
        {
            try
            {
                var res = await _ServiceMantenimiento.DeleteAuxilioMecanicoAsync(IdAuxilioMecanico);

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

        public async Task<ActionResult> InsertAuxilioMecanico(
                string Carga,
                string Are_Codigo,
                string Are_Codigo2,
                decimal Kmt_unidad,
                decimal Kmt_recorrido,
                string MMG,
                string Fechahora_ini,
                string Fechahora_fin,
                string Controlable,
                decimal Id_plataforma,
                short Idtarea_c,
                string Falla,
                string Ben_codigo,
                string Servicio,
                decimal Kmt_Perdido,
                short CambioTracto,
                string Responsable,
                string Atencion,
                string Causa,
                int IdPlan
            )
        {
            try
            {

                var request = new AuxilioMecanicoRequest
                {
                    AuxilioMecanico = new AuxilioMecanicoEntity
                    {
                        Are_Codigo = Are_Codigo,
                        Are_Codigo2 = Are_Codigo2,
                        Atencion = Atencion,
                        Ben_codigo = Ben_codigo,
                        CambioTracto = CambioTracto,
                        Carga = Carga,
                        Causa = Causa,
                        Controlable = Controlable,
                        Falla = Falla,
                        Fechahora_fin = Fechahora_fin,
                        Fechahora_ini = Fechahora_ini,
                        IdPlan = IdPlan,
                        Idtarea_c = Idtarea_c,
                        Id_plataforma = Id_plataforma,
                        Kmt_Perdido = Kmt_Perdido,
                        Kmt_recorrido = Kmt_recorrido,
                        Kmt_unidad = Kmt_unidad,
                        MMG = MMG,
                        Responsable = Responsable,
                        Servicio = Servicio
                    }
                };

                var res = await _ServiceMantenimiento.InsertAuxilioMecanicoAsync(request);

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

        public async Task<ActionResult> UpdateAuxilioMecanico(
                int ID_Tb_AuxilioMecanico,
                string Carga,
                string Are_Codigo,
                string Are_Codigo2,
                decimal Kmt_unidad,
                decimal Kmt_recorrido,
                string MMG,
                string Fechahora_ini,
                string Fechahora_fin,
                string Controlable,
                decimal Id_plataforma,
                short Idtarea_c,
                string Falla,
                string Ben_codigo,
                string Servicio,
                decimal Kmt_Perdido,
                short CambioTracto,
                string Responsable,
                string Atencion,
                string Causa,
                int IdPlan
            )
        {

            try
            {
                var request = new AuxilioMecanicoRequest
                {
                    AuxilioMecanico = new AuxilioMecanicoEntity
                    {
                        Are_Codigo = Are_Codigo,
                        Are_Codigo2 = Are_Codigo2,
                        Atencion = Atencion,
                        Ben_codigo = Ben_codigo,
                        CambioTracto = CambioTracto,
                        Carga = Carga,
                        Causa = Causa,
                        Controlable = Controlable,
                        Falla = Falla,
                        Fechahora_fin = Fechahora_fin,
                        Fechahora_ini = Fechahora_ini,
                        IdPlan = IdPlan,
                        Idtarea_c = Idtarea_c,
                        Id_plataforma = Id_plataforma,
                        Kmt_Perdido = Kmt_Perdido,
                        Kmt_recorrido = Kmt_recorrido,
                        Kmt_unidad = Kmt_unidad,
                        MMG = MMG,
                        Responsable = Responsable,
                        Servicio = Servicio,
                        ID_Tb_AuxilioMecanico = ID_Tb_AuxilioMecanico
                    }
                };

                var res = await _ServiceMantenimiento.UpdateAuxilioMecanicoAsync(request);
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