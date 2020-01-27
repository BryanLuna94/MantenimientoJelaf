using System.Collections.Generic;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Mantenimiento.DataAccess;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Others;
using Mantenimiento.Entities.Requests.Responses;
using Mantenimiento.Utility;

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
                    BusinessException.Generate(Constants.NO_ELIMINO);
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
            string FechaRegistro,string HoraRegistro, int Estado, int IdSistema, int IdObservacion)
        {
            Response<FallasDResponse> response;
            FallasDEntity objFallasD;

            try
            {
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


    }




}
