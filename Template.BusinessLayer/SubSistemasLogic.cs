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
    public static class SubSistemasLogic
    {
        public static Response<SubSistemasResponse> IdSubSistemas(short ID_tb_Sistema_Mant)
        {
            try
            {
                Response<SubSistemasResponse> response;
                List<SubSistemasEntity> List;

                List = SubSistemasData.IdSubSistemas(ID_tb_Sistema_Mant);

                response = new Response<SubSistemasResponse>
                {
                    EsCorrecto = true,
                    Valor = new SubSistemasResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<SubSistemasResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<SubSistemasResponse> ListSubSistemas()
        {
            try
            {
                Response<SubSistemasResponse> response;
                List<SubSistemasEntity> List;

                List = SubSistemasData.ListSubSistemas();

                response = new Response<SubSistemasResponse>
                {
                    EsCorrecto = true,
                    Valor = new SubSistemasResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<SubSistemasResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<SubSistemasResponse> SelectSubSistemas(string ID_tb_SubSistema_Mant)
        {
            try
            {
                Response<SubSistemasResponse> response;
                List<SubSistemasEntity> List;

                List = SubSistemasData.SelectSubSistemas(ID_tb_SubSistema_Mant);

                response = new Response<SubSistemasResponse>
                {
                    EsCorrecto = true,
                    Valor = new SubSistemasResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<SubSistemasResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<SubSistemasResponse>> DeleteSubSistemas(string ID_tb_SubSistema_Mant)
        {
            Response<SubSistemasResponse> response;
            SubSistemasEntity objSubSistemas;

            try
            {
                objSubSistemas = await SubSistemasData.DeleteSubSistemas(ID_tb_SubSistema_Mant);

                if (objSubSistemas != null)
                {
                    BusinessException.Generate(Constants.NO_ELIMINO);
                }

                response = new Response<SubSistemasResponse>
                {
                    EsCorrecto = true,
                    Valor = new SubSistemasResponse
                    {
                        SubSistemas = objSubSistemas
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
                return new Response<SubSistemasResponse>(false, null, Functions.MessageError(ex), false);
            }
        }



        public static async Task<Response<SubSistemasResponse>> InsertSubSistemas(string ID_tb_SubSistema_Mant, short ID_tb_Sistema_Mant, string Descripcion)
        {
            Response<SubSistemasResponse> response;
            SubSistemasEntity objSubSistemas;

            try
            {
                objSubSistemas = await SubSistemasData.InsertSubSistemas(ID_tb_SubSistema_Mant, ID_tb_Sistema_Mant, Descripcion);

                response = new Response<SubSistemasResponse>
                {
                    EsCorrecto = true,
                    Valor = new SubSistemasResponse
                    {
                        SubSistemas = objSubSistemas
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
                return new Response<SubSistemasResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<SubSistemasResponse>> UpdateSubSistemas(string ID_tb_SubSistema_Mant, short ID_tb_Sistema_Mant, string Descripcion)
        {
            Response<SubSistemasResponse> response;
            SubSistemasEntity objSubSistemas;

            try
            {
                objSubSistemas = await SubSistemasData.UpdateSubSistemas(ID_tb_SubSistema_Mant, ID_tb_Sistema_Mant, Descripcion);

                response = new Response<SubSistemasResponse>
                {
                    EsCorrecto = true,
                    Valor = new SubSistemasResponse
                    {
                        SubSistemas = objSubSistemas
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
                return new Response<SubSistemasResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

    }




}
