using System.Collections.Generic;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Mantenimiento.DataAccess;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Others;
using Mantenimiento.Utility;
using Mantenimiento.Entities.Peticiones.Responses;
using Mantenimiento.Entities.Objects.Filters;
using Mantenimiento.Entities.Peticiones.Requests;
using Mantenimiento.Entities.Objects.Lists;
using System.Transactions;

namespace Mantenimiento.BusinessLayer
{
    public class OrdenMasivaLogic
    {
        public static Response<OrdenMasivaResponse> ListOrdenMasiva(OrdenMasivaRequest request)
        {
            try
            {
                Response<OrdenMasivaResponse> response;
                List<OrdenMasivaList> List;
                OrdenMasivaFilter objFiltro;

                objFiltro = request.Filtro;

                List = ProgramacionData.ListOrdenMasiva(objFiltro);

                response = new Response<OrdenMasivaResponse>
                {
                    EsCorrecto = true,
                    Valor = new OrdenMasivaResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<OrdenMasivaResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<OrdenMasivaResponse>> InsertCorrectivo(OrdenMasivaRequest request)
        {
            Response<OrdenMasivaResponse> response;
            List<OrdenMasivaList> ListInsertar;
            string FechaGenerar;
            decimal klm_acumulado;
            DateTime fechaRegistro;
            string usuarioRegistro;
            string are_codigo;
            int idMaxRevision;
            int idMaxInforme;
            decimal idNumInforme;
            SolicitudRevisionTecnica_CEntity objSolicitudRevision;
            InformeEntity objInforme;
            ProgramacionEntity objProgramacion;

            ListInsertar = request.ListInsertar;
            FechaGenerar = request.FechaGenerar;
            idMaxRevision = 1;
            idMaxInforme = 1;
            fechaRegistro = DateTime.Now;
            usuarioRegistro = request.UsuarioRegistro;

            try
            {
                foreach (var item in ListInsertar)
                {
                    if (item.Correctivo) continue;

                    are_codigo = item.IdUnidad;
                    klm_acumulado = AreData.SelectAre(are_codigo).Klm_Acumulados;
                    idMaxRevision = SolicitudRevisionTecnicaData.ObtenerUltimoId();

                    objSolicitudRevision = new SolicitudRevisionTecnica_CEntity
                    {
                        IdSolicitudRevision = idMaxRevision.ToString(),
                        FechaDoc = Convert.ToDateTime(FechaGenerar),
                        HorasDoc = fechaRegistro.ToShortTimeString(),
                        IdUnidad = item.IdUnidad,
                        IdChofer = item.IDChofer,
                        CodOrigen = Convert.ToInt32(item.CodOrigen).ToString("00#"),
                        CodDestino = Convert.ToInt32(item.CodDestino).ToString("00#"),
                        Kilometraje = klm_acumulado,
                        UsuarioRegistro = Convert.ToInt32(usuarioRegistro).ToString("000#"),
                        HoraRegistro = fechaRegistro.ToShortTimeString(),
                        FechaRegistro = fechaRegistro,
                        FechaViaje = Convert.ToDateTime(item.FechaViaje),
                        HoraViahe = item.HoraViaje,
                        Estado = 1
                    };
                    await SolicitudRevisionTecnicaData.InsertSolicitudRevisionTecnica_C(objSolicitudRevision);

                    objInforme = new InformeEntity
                    {
                        Are_Codigo = item.IdUnidad,
                        ChoferEntrega = item.IDChofer,
                        KmUnidad = klm_acumulado,
                        Ofi_Codigo = Convert.ToInt32(item.CodOrigen).ToString("00#"),
                        Fecha = Convert.ToDateTime(FechaGenerar),
                        CostoManoObra = 0,
                        CostoRepuestos = 0,
                        ServicioTerceros = 0,
                        Observacion = "",
                        IdUndAlerta = 0,
                        IdPlanEjecucionTarea = "",
                        Tipo = "1",
                        UsuarioRegistro = Convert.ToInt16(usuarioRegistro)
                    };

                    idMaxInforme = InformeData.InsertInforme(objInforme);
                    idNumInforme = InformeData.ObtenerUltimoId();

                    objProgramacion = new ProgramacionEntity
                    {
                        CODI_BUS = item.IdUnidad,
                        CODI_PROGRAMACION = item.Codi_Programacion,
                        FechaGeneracion = FechaGenerar,
                        HoraGeneracion = fechaRegistro.ToShortTimeString(),
                        KMT_VIAJE = klm_acumulado,
                        UsuarioGeneracion = usuarioRegistro,
                        NumeroMantenimieto = "",
                        NumeroOrden = idNumInforme.ToString()
                    };
                    
                    await InformeData.UpdateInforme_NumInforme(idMaxInforme, idNumInforme);
                    await SolicitudRevisionTecnicaData.UpdateSolicitudRevisionTecnica_C_Correctivo(idMaxRevision.ToString(), klm_acumulado, idNumInforme);
                    await ProgramacionData.UpdateProgramacionOrdenCorrectivoGeneracion(objProgramacion);
                }

                response = new Response<OrdenMasivaResponse>
                {
                    EsCorrecto = true,
                    Valor = new OrdenMasivaResponse
                    {
                        List = new List<OrdenMasivaList>()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (FaultException<ServiceError>)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new Response<OrdenMasivaResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<OrdenMasivaResponse>> AnularCorrectivo(OrdenMasivaRequest request)
        {
            Response<OrdenMasivaResponse> response;
            List<OrdenMasivaList> ListInsertar;;
            decimal numInforme;

            ListInsertar = request.ListInsertar;

            try
            {
                foreach (var item in ListInsertar)
                {
                    if (!item.Correctivo) continue;

                    numInforme = Convert.ToDecimal(item.NumeroOrden);

                    await SolicitudRevisionTecnicaData.AnularSolicitudRevisionTecnica_C_Correctivo(numInforme);
                    await InformeData.AnularInforme(numInforme, "1");
                    await ProgramacionData.UpdateProgramacionOrdenCorrectivoAnulacion(item.Codi_Programacion);

                    if (item.Preventivo)
                    {
                        //await SolicitudRevisionTecnicaData.AnularSolicitudRevisionTecnica_C_Correctivo(numInforme);
                        await InformeData.AnularInforme(numInforme, "0");
                        await ProgramacionData.UpdateProgramacionOrdenPreventivoAnulacion(item.Codi_Programacion);
                    }
                }

                response = new Response<OrdenMasivaResponse>
                {
                    EsCorrecto = true,
                    Valor = new OrdenMasivaResponse
                    {
                        List = new List<OrdenMasivaList>()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (FaultException<ServiceError>)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new Response<OrdenMasivaResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<OrdenMasivaResponse>> InsertPreventivo(OrdenMasivaRequest request)
        {
            Response<OrdenMasivaResponse> response;
            List<OrdenMasivaList> ListInsertar;
            string FechaGenerar;
            decimal klm_acumulado;
            DateTime fechaRegistro;
            string usuarioRegistro;
            string are_codigo;
            int idMaxRevision;
            int idMaxInforme;
            decimal idNumInforme;
            SolicitudRevisionTecnica_CEntity objSolicitudRevision;
            InformeEntity objInforme;
            ProgramacionEntity objProgramacion;

            ListInsertar = request.ListInsertar;
            FechaGenerar = request.FechaGenerar;
            fechaRegistro = DateTime.Now;
            usuarioRegistro = request.UsuarioRegistro;

            try
            {
                foreach (var item in ListInsertar)
                {
                    if (!item.Correctivo) continue;
                    if (item.Preventivo) continue;

                    are_codigo = item.IdUnidad;
                    klm_acumulado = AreData.SelectAre(are_codigo).Klm_Acumulados;
                    idMaxRevision = SolicitudRevisionTecnicaData.ObtenerUltimoId();

                    /*
                    objSolicitudRevision = new SolicitudRevisionTecnica_CEntity
                    {
                        IdSolicitudRevision = idMaxRevision.ToString(),
                        FechaDoc = Convert.ToDateTime(FechaGenerar),
                        HorasDoc = fechaRegistro.ToShortTimeString(),
                        IdUnidad = item.IdUnidad,
                        IdChofer = item.IDChofer,
                        CodOrigen = Convert.ToInt32(item.CodOrigen).ToString("00#"),
                        CodDestino = Convert.ToInt32(item.CodDestino).ToString("00#"),
                        Kilometraje = klm_acumulado,
                        UsuarioRegistro = Convert.ToInt32(usuarioRegistro).ToString("000#"),
                        HoraRegistro = fechaRegistro.ToShortTimeString(),
                        FechaRegistro = fechaRegistro,
                        FechaViaje = Convert.ToDateTime(item.FechaViaje),
                        HoraViahe = item.HoraViaje,
                        Estado = 1
                    };
                    await SolicitudRevisionTecnicaData.InsertSolicitudRevisionTecnica_C(objSolicitudRevision);
                    */

                    objInforme = new InformeEntity
                    {
                        Are_Codigo = item.IdUnidad,
                        ChoferEntrega = item.IDChofer,
                        KmUnidad = klm_acumulado,
                        Ofi_Codigo = Convert.ToInt32(item.CodOrigen).ToString("00#"),
                        Fecha = Convert.ToDateTime(FechaGenerar),
                        CostoManoObra = 0,
                        CostoRepuestos = 0,
                        ServicioTerceros = 0,
                        Observacion = "",
                        IdUndAlerta = 0,
                        IdPlanEjecucionTarea = "",
                        Tipo = "0",
                        UsuarioRegistro = Convert.ToInt16(usuarioRegistro)
                    };

                    idMaxInforme = InformeData.InsertInforme(objInforme);
                    idNumInforme = Convert.ToDecimal(item.NumeroOrden);

                    objProgramacion = new ProgramacionEntity
                    {
                        CODI_PROGRAMACION = item.Codi_Programacion,
                        NumeroMantenimieto = idNumInforme.ToString(),
                    };

                    await InformeData.UpdateInforme_NumInforme(idMaxInforme, idNumInforme);
                    //await SolicitudRevisionTecnicaData.UpdateSolicitudRevisionTecnica_C_Correctivo(idMaxRevision.ToString(), klm_acumulado, idNumInforme);
                    await ProgramacionData.UpdateProgramacionOrdenPreventivoGeneracion(objProgramacion);
                }

                response = new Response<OrdenMasivaResponse>
                {
                    EsCorrecto = true,
                    Valor = new OrdenMasivaResponse
                    {
                        List = new List<OrdenMasivaList>()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (FaultException<ServiceError>)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new Response<OrdenMasivaResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<OrdenMasivaResponse>> AnularPreventivo(OrdenMasivaRequest request)
        {
            Response<OrdenMasivaResponse> response;
            List<OrdenMasivaList> ListInsertar; ;
            decimal numInforme;

            ListInsertar = request.ListInsertar;

            try
            {
                foreach (var item in ListInsertar)
                {
                    if (!item.Preventivo) continue;

                    numInforme = Convert.ToDecimal(item.NumeroOrden);

                    //await SolicitudRevisionTecnicaData.AnularSolicitudRevisionTecnica_C_Correctivo(numInforme);
                    await InformeData.AnularInforme(numInforme, "0");
                    await ProgramacionData.UpdateProgramacionOrdenPreventivoAnulacion(item.Codi_Programacion);
                }

                response = new Response<OrdenMasivaResponse>
                {
                    EsCorrecto = true,
                    Valor = new OrdenMasivaResponse
                    {
                        List = new List<OrdenMasivaList>()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (FaultException<ServiceError>)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new Response<OrdenMasivaResponse>(false, null, Functions.MessageError(ex), false);
            }
        }
    }
}
