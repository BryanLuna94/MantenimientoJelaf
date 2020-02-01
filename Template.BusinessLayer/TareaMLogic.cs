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
    public static class TareaMLogic
    {
        public static Response<TareaMResponse> IdTareaM()
        {
            try
            {
                Response<TareaMResponse> response;
                List<TareaMEntity> List;

                List = TareaMData.IdTareaM();

                response = new Response<TareaMResponse>
                {
                    EsCorrecto = true,
                    Valor = new TareaMResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<TareaMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<TareaMResponse> ListTareaM()
        {
            try
            {
                Response<TareaMResponse> response;
                List<TareaMEntity> List;

                List = TareaMData.ListTareaM();

                response = new Response<TareaMResponse>
                {
                    EsCorrecto = true,
                    Valor = new TareaMResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<TareaMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<TareaMResponse> SelectTareaM(short IdTipMan)
        {
            try
            {
                Response<TareaMResponse> response;
                List<TareaMEntity> List;

                List = TareaMData.SelectTareaM(IdTipMan);

                response = new Response<TareaMResponse>
                {
                    EsCorrecto = true,
                    Valor = new TareaMResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<TareaMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<TareaMResponse>> DeleteTareaM(short IdTarea)
        {
            Response<TareaMResponse> response;
            TareaMEntity objTareaM;

            try
            {
                objTareaM = await TareaMData.DeleteTareaM(IdTarea);

                if (objTareaM != null)
                {
                    BusinessException.Generar(Constants.NO_ELIMINO);
                }

                response = new Response<TareaMResponse>
                {
                    EsCorrecto = true,
                    Valor = new TareaMResponse
                    {
                        TareaM = objTareaM
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
                return new Response<TareaMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }



        public static async Task<Response<TareaMResponse>> InsertTareaM(short IdTarea, short IdTipMan, string Descripcion, short UsuarioRegistro, string FechaRegistro, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant)
        {
            Response<TareaMResponse> response;
            TareaMEntity objTareaM;

            try
            {
                objTareaM = await TareaMData.InsertTareaM(IdTarea, IdTipMan, Descripcion, UsuarioRegistro, FechaRegistro,ID_tb_Sistema_Mant,ID_tb_SubSistema_Mant);

                response = new Response<TareaMResponse>
                {
                    EsCorrecto = true,
                    Valor = new TareaMResponse
                    {
                        TareaM = objTareaM
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
                return new Response<TareaMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<TareaMResponse>> UpdateTareaM(short IdTarea, short IdTipMan, string Descripcion, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant)
        {
            Response<TareaMResponse> response;
            TareaMEntity objTareaM;

            try
            {
                objTareaM = await TareaMData.UpdateTareaM(IdTarea, IdTipMan, Descripcion, ID_tb_Sistema_Mant, ID_tb_SubSistema_Mant);

                response = new Response<TareaMResponse>
                {
                    EsCorrecto = true,
                    Valor = new TareaMResponse
                    {
                        TareaM = objTareaM
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
                return new Response<TareaMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

    }




}
