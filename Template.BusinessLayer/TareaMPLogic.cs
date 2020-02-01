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
    public static class TareaMPLogic
    {
        public static Response<TareaMPResponse> IdTareaMP()
        {
            try
            {
                Response<TareaMPResponse> response;
                List<TareaMPEntity> List;

                List = TareaMPData.IdTareaMP();

                response = new Response<TareaMPResponse>
                {
                    EsCorrecto = true,
                    Valor = new TareaMPResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<TareaMPResponse>(false, null, Functions.MessageError(ex), false);
            }
        }



        public static Response<TareaMPResponse> ListTareaMP(short IdTipMan)
        {
            try
            {
                Response<TareaMPResponse> response;
                List<TareaMPEntity> List;

                List = TareaMPData.ListTareaMP(IdTipMan);

                response = new Response<TareaMPResponse>
                {
                    EsCorrecto = true,
                    Valor = new TareaMPResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<TareaMPResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<TareaMPResponse> SelectTareaMP(short IdTarea)
        {
            try
            {
                Response<TareaMPResponse> response;
                List<TareaMPEntity> List;

                List = TareaMPData.SelectTareaMP(IdTarea);

                response = new Response<TareaMPResponse>
                {
                    EsCorrecto = true,
                    Valor = new TareaMPResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<TareaMPResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<TareaMPResponse>> DeleteTareaMP(short IdTarea)
        {
            Response<TareaMPResponse> response;
            TareaMPEntity objTareaMP;

            try
            {
                objTareaMP = await TareaMPData.DeleteTareaMP(IdTarea);

                if (objTareaMP != null)
                {
                    BusinessException.Generar(Constants.NO_ELIMINO);
                }

                response = new Response<TareaMPResponse>
                {
                    EsCorrecto = true,
                    Valor = new TareaMPResponse
                    {
                        TareaMP = objTareaMP
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
                return new Response<TareaMPResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<TareaMPResponse>> InsertTareaMP(short IdTipMan,
            string Descripcion, short UsuarioRegistro, string FechaRegistro, int Flg_Revision,
            int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant)
        {
            Response<TareaMPResponse> response;
            TareaMPEntity objTareaMP;

            try
            {
                short idTarea = (short)TareaMPData.IdTareaMP()[0].IdTarea;
                objTareaMP = await TareaMPData.InsertTareaMP(idTarea, IdTipMan, Descripcion, UsuarioRegistro,
                    Convert.ToDateTime(FechaRegistro), Flg_Revision,ID_tb_Sistema_Mant, ID_tb_SubSistema_Mant);

                response = new Response<TareaMPResponse>
                {
                    EsCorrecto = true,
                    Valor = new TareaMPResponse
                    {
                        TareaMP = objTareaMP
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
                return new Response<TareaMPResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<TareaMPResponse>> UpdateTareaMP(short IdTarea, short IdTipMan,
            string Descripcion, int Flg_Revision, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant)
        {
            Response<TareaMPResponse> response;
            TareaMPEntity objTareaMP;

            try
            {
                objTareaMP = await TareaMPData.UpdateTareaMP(IdTarea, IdTipMan, Descripcion, Flg_Revision, ID_tb_Sistema_Mant, ID_tb_SubSistema_Mant);

                response = new Response<TareaMPResponse>
                {
                    EsCorrecto = true,
                    Valor = new TareaMPResponse
                    {
                        TareaMP = objTareaMP
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
                return new Response<TareaMPResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

    }




}
