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
    public static class ArticuloTLogic
    {
        public static Response<ArticuloTResponse> IdArticuloT()
        {
            try
            {
                Response<ArticuloTResponse> response;
                List<ArticuloTEntity> List;

                List = ArticuloTData.IdArticuloT();

                response = new Response<ArticuloTResponse>
                {
                    EsCorrecto = true,
                    Valor = new ArticuloTResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<ArticuloTResponse>(false, null, Functions.MessageError(ex), false);
            }
        }



        public static Response<ArticuloTResponse> ListArticuloT(short IdTarea)
        {
            try
            {
                Response<ArticuloTResponse> response;
                List<ArticuloTEntity> List;

                List = ArticuloTData.ListArticuloT(IdTarea);

                response = new Response<ArticuloTResponse>
                {
                    EsCorrecto = true,
                    Valor = new ArticuloTResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<ArticuloTResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<ArticuloTResponse> SelectArticuloT(short IdArtTar)
        {
            try
            {
                Response<ArticuloTResponse> response;
                List<ArticuloTEntity> List;

                List = ArticuloTData.SelectArticuloT(IdArtTar);

                response = new Response<ArticuloTResponse>
                {
                    EsCorrecto = true,
                    Valor = new ArticuloTResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<ArticuloTResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<ArticuloTResponse>> DeleteArticuloT(short IdArtTar)
        {
            Response<ArticuloTResponse> response;
            ArticuloTEntity objArticuloT;

            try
            {
                objArticuloT = await ArticuloTData.DeleteArticuloT(IdArtTar);

                if (objArticuloT != null)
                {
                    BusinessException.Generar(Constants.NO_ELIMINO);
                }

                response = new Response<ArticuloTResponse>
                {
                    EsCorrecto = true,
                    Valor = new ArticuloTResponse
                    {
                        ArticuloT = objArticuloT
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
                return new Response<ArticuloTResponse>(false, null, Functions.MessageError(ex), false);
            }
        }



        public static async Task<Response<ArticuloTResponse>> InsertArticuloT(short IdTarea,
            short Cod_Mer, short Cantidad, short Orden)
        {
            Response<ArticuloTResponse> response;
            ArticuloTEntity objArticuloT;
            short IdArtTar = (short)ArticuloTData.IdArticuloT()[0].IdArtTar;

            try
            {
                objArticuloT = await ArticuloTData.InsertArticuloT(IdArtTar, IdTarea, Cod_Mer, Cantidad, Orden);

                response = new Response<ArticuloTResponse>
                {
                    EsCorrecto = true,
                    Valor = new ArticuloTResponse
                    {
                        ArticuloT = objArticuloT
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
                return new Response<ArticuloTResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<ArticuloTResponse>> UpdateArticuloT(short IdArtTar, short IdTarea,
            short Cod_Mer, short Cantidad, short Orden)
        {
            Response<ArticuloTResponse> response;
            ArticuloTEntity objArticuloT;

            try
            {
                objArticuloT = await ArticuloTData.UpdateArticuloT(IdArtTar, IdTarea, Cod_Mer, Cantidad, Orden);

                response = new Response<ArticuloTResponse>
                {
                    EsCorrecto = true,
                    Valor = new ArticuloTResponse
                    {
                        ArticuloT = objArticuloT
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
                return new Response<ArticuloTResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

    }




}
