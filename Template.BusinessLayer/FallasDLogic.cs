using System.Collections.Generic;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Mantenimiento.DataAccess;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Others;
using Mantenimiento.Entities.Requests.Responses;
using Mantenimiento.Utility;
using Mantenimiento.Entities.Objects.Lists;
using Mantenimiento.Entities.Peticiones.Requests;

namespace Mantenimiento.BusinessLayer
{
    public static class FallasDLogic
    {
        public static Response<FallasDResponse> IdFallasD()
        {
            try
            {
                Response<FallasDResponse> response;
                List<FallasDEntity> List;

                List = FallasDData.IdFallasD();

                response = new Response<FallasDResponse>
                {
                    EsCorrecto = true,
                    Valor = new FallasDResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<FallasDResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<FallasDResponse> SelectFallasD(string ID)
        {
            try
            {
                Response<FallasDResponse> response;
                List<FallasDEntity> List;

                List = FallasDData.SelectFallasD(ID);

                response = new Response<FallasDResponse>
                {
                    EsCorrecto = true,
                    Valor = new FallasDResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<FallasDResponse>(false, null, Functions.MessageError(ex), false);
            }
        }
        public static async Task<Response<FallasDResponse>> DeleteFallasD(string ID)
        {
            Response<FallasDResponse> response;
            FallasDEntity objFallasD;

            try
            {
                objFallasD = await FallasDData.DeleteFallasD(ID);

                if (objFallasD != null)
                {
                    BusinessException.Generar(Constants.NO_ELIMINO);
                }

                response = new Response<FallasDResponse>
                {
                    EsCorrecto = true,
                    Valor = new FallasDResponse
                    {
                        FallasD = objFallasD
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
                return new Response<FallasDResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<FallasDResponse>> InsertFallasD(string IdSolicitudRevisionD, string IdSolicitudRevision, string Observacion, string UsuarioRegistro,
            string FechaRegistro, string HoraRegistro, int Estado, int IdSistema, int IdObservacion)
        {
            Response<FallasDResponse> response;
            FallasDEntity objFallasD;

            try
            {
                UsuarioRegistro = Convert.ToInt32(UsuarioRegistro).ToString("000#");
                objFallasD = await FallasDData.InsertFallasD(IdSolicitudRevisionD, IdSolicitudRevision, Observacion, UsuarioRegistro, FechaRegistro, HoraRegistro, Estado, IdSistema, IdObservacion);

                response = new Response<FallasDResponse>
                {
                    EsCorrecto = true,
                    Valor = new FallasDResponse
                    {
                        FallasD = objFallasD
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
                return new Response<FallasDResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<FallasDResponse> SolicitudRevisionBusqueda(string NivelUsuario, string CodSucursal)
        {
            try
            {
                Response<FallasDResponse> response;
                List<SolicitudRevisionBusquedaList> List;

                List = new List<SolicitudRevisionBusquedaList>();

                if (NivelUsuario == "2")
                {
                    List = SolicitudRevisionTecnicaData.ListSolicitudRevisionAdmin();
                }
                else if (NivelUsuario == "1")
                {
                    List = SolicitudRevisionTecnicaData.ListSolicitudRevisionUsuario(Convert.ToInt32(CodSucursal).ToString("00#"));
                }

                response = new Response<FallasDResponse>
                {
                    EsCorrecto = true,
                    Valor = new FallasDResponse { ListBusqueda = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<FallasDResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<FallasDResponse> SelectSolicitudRevision(string IdsolicitudRevision)
        {
            try
            {
                Response<FallasDResponse> response;
                SolicitudRevisionList List;

                List = SolicitudRevisionTecnicaData.SelectSolicitudRevision(IdsolicitudRevision);

                response = new Response<FallasDResponse>
                {
                    EsCorrecto = true,
                    Valor = new FallasDResponse { SolicitudRevision = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<FallasDResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<FallasDResponse>> UpdateSolicitudRevision(FallasDRequest request)
        {
            Response<FallasDResponse> response;
            SolicitudRevisionList objSolicitudRevision;
            decimal valorMaximoOdometro;
            decimal valorMinimoOdometro;
            decimal odometroAnterior;
            decimal odometroNuevo;
            decimal valorMaximoAgregar;
            decimal valorMinimoAgregar;

            try
            {
                objSolicitudRevision = request.SolicitudRevision;
                odometroNuevo = objSolicitudRevision.Odometro;
                odometroAnterior = objSolicitudRevision.OdometroAnterior;
                valorMaximoAgregar = Convert.ToDecimal(ConfiguracionMantenimientoData.SelectValor(Convert.ToInt32(Constants.Configuracion.CODIGO_MAXIMO_ODOMETRO_FALLAS)));
                valorMinimoAgregar = Convert.ToDecimal(ConfiguracionMantenimientoData.SelectValor(Convert.ToInt32(Constants.Configuracion.CODIGO_MINIMO_ODOMETRO_FALLAS)));
                valorMaximoOdometro = odometroAnterior + valorMaximoAgregar;
                valorMinimoOdometro = odometroAnterior - valorMinimoAgregar;

                if (odometroNuevo > valorMaximoOdometro || odometroNuevo < valorMinimoOdometro)
                {
                    BusinessException.Generar(string.Format("Al valor del odómetro solo se le puede agregar {0} mas ó disminuir {1} menos", valorMaximoAgregar, valorMinimoAgregar));
                }

                await SolicitudRevisionTecnicaData.UpdateSolicitudRevisionTecnica_C_CorrelativoInterno(objSolicitudRevision.IdSolicitudRevision, objSolicitudRevision.CorrelativoInterno);
                await AreData.UpdateAre_OdometroAcumulado(objSolicitudRevision.IdUnidad, objSolicitudRevision.Odometro);

                response = new Response<FallasDResponse>
                {
                    EsCorrecto = true,
                    Valor = new FallasDResponse
                    {
                        SolicitudRevision = new SolicitudRevisionList()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static async Task<Response<FallasDResponse>> AnularSolicitudRevision(string IdSolicitudRevision)
        {
            Response<FallasDResponse> response;

            try
            {
                await SolicitudRevisionTecnicaData.AnularSolicitudRevisionTecnica_C(IdSolicitudRevision);

                response = new Response<FallasDResponse>
                {
                    EsCorrecto = true,
                    Valor = new FallasDResponse
                    {
                        SolicitudRevision = new SolicitudRevisionList()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Response<FallasDResponse> ObtenerUltimaRevisionChofer(string CodChofer)
        {
            try
            {
                Response<FallasDResponse> response;

                string ultimoRegistro = SolicitudRevisionTecnicaData.ObtenerUltimaRevisionChofer(CodChofer); 

                response = new Response<FallasDResponse>
                {
                    EsCorrecto = true,
                    Valor = new FallasDResponse { IdSolicitud = ultimoRegistro },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<FallasDResponse>(false, null, Functions.MessageError(ex), false);
            }
        }
    }
}
