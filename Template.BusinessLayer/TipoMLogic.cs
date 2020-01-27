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
    public static class TipoMLogic
    {
        public static Response<TipoMResponse> IdTipoM()
        {
            try
            {
                Response<TipoMResponse> response;
                List<TipoMEntity> List;

                List = TipoMData.IdTipoM();

                response = new Response<TipoMResponse>
                {
                    EsCorrecto = true,
                    Valor = new TipoMResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<TipoMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<TipoMResponse> ListTipoM()
        {
            try
            {
                Response<TipoMResponse> response;
                List<TipoMEntity> List;

                List = TipoMData.ListTipoM();

                response = new Response<TipoMResponse>
                {
                    EsCorrecto = true,
                    Valor = new TipoMResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<TipoMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<TipoMResponse> SelectTipoM(short IdTipMan)
        {
            try
            {
                Response<TipoMResponse> response;
                List<TipoMEntity> List;

                List = TipoMData.SelectTipoM(IdTipMan);

                response = new Response<TipoMResponse>
                {
                    EsCorrecto = true,
                    Valor = new TipoMResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<TipoMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<TipoMResponse>> DeleteTipoM(short IdTipMan)
        {
            Response<TipoMResponse> response;
            TipoMEntity objTipoM;

            try
            {
                objTipoM = await TipoMData.DeleteTipoM(IdTipMan);

                if (objTipoM != null)
                {
                    BusinessException.Generate(Constants.NO_ELIMINO);
                }

                response = new Response<TipoMResponse>
                {
                    EsCorrecto = true,
                    Valor = new TipoMResponse
                    {
                        TipoM = objTipoM
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
                return new Response<TipoMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }



        public static async Task<Response<TipoMResponse>> InsertTipoM(short IdTipMan, string Descripcion, short UsuarioRegistro, string FechaRegistro)
        {
            Response<TipoMResponse> response;
            TipoMEntity objTipoM;

            try
            {
                objTipoM = await TipoMData.InsertTipoM(IdTipMan, Descripcion, UsuarioRegistro, FechaRegistro);

                response = new Response<TipoMResponse>
                {
                    EsCorrecto = true,
                    Valor = new TipoMResponse
                    {
                        TipoM = objTipoM
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
                return new Response<TipoMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<TipoMResponse>> UpdateTipoM(short IdTipMan, string Descripcion,decimal Kilometros, decimal KilometrosAviso, short Dias, 
            short DiasAviso, short Horas, short HorasAviso)
        {
            Response<TipoMResponse> response;
            TipoMEntity objTipoM;

            try
            {
                objTipoM = await TipoMData.UpdateTipoM(IdTipMan, Descripcion,Kilometros, KilometrosAviso, Dias, DiasAviso, Horas, HorasAviso);

                response = new Response<TipoMResponse>
                {
                    EsCorrecto = true,
                    Valor = new TipoMResponse
                    {
                        TipoM = objTipoM
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
                return new Response<TipoMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

    }




}
