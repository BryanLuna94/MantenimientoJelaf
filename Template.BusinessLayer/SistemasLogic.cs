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
    public static class SistemasLogic
    {
        public static async Task<Response<SistemasResponse>> ListSistemas(short ID_tb_Sistema_Mant)
        {
            Response<SistemasResponse> response;
            SistemasEntity objSistemas;

            try
            {
                objSistemas = await SistemasData.ListSistemas(ID_tb_Sistema_Mant);

              //  objSistemas = await SistemasData.Descripcion(objSistemas);

                if (objSistemas == null)
                {
                    BusinessException.Generar(Constants.CODIGO_VACIO);
                }

  
      
                response = new Response<SistemasResponse>
                {
                    EsCorrecto = true,
                    Valor = new SistemasResponse
                    {
                        Sistemas = objSistemas
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
                return new Response<SistemasResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<SistemasResponse>> DeleteSistemas(short ID_tb_Sistema_Mant)
        {
            Response<SistemasResponse> response;
            SistemasEntity objSistemas;

            try
            {
                objSistemas = await SistemasData.DeleteSistemas(ID_tb_Sistema_Mant);

                if (objSistemas != null)
                {
                    BusinessException.Generar(Constants.NO_ELIMINO);
                }

                response = new Response<SistemasResponse>
                {   
                    EsCorrecto = true,
                    Valor = new SistemasResponse
                    {
                        Sistemas = objSistemas
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
                return new Response<SistemasResponse>(false, null, Functions.MessageError(ex), false);
            }
        }


        public static Response<SistemasResponse> SelectSistemas()
        {
            try
            {
                Response<SistemasResponse> response;
                List<SistemasEntity> List;

                List = SistemasData.SelectSistemas();

                response = new Response<SistemasResponse>
                {
                    EsCorrecto = true,
                    Valor = new SistemasResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<SistemasResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<SistemasResponse> IdSistemas()
        {
            try
            {
                Response<SistemasResponse> response;
                List<SistemasEntity> List;

                List = SistemasData.IdSistemas();

                response = new Response<SistemasResponse>
                {
                    EsCorrecto = true,
                    Valor = new SistemasResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<SistemasResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<SistemasResponse>> InsertSistemas(short ID_tb_Sistema_Mant,string Descripcion)
        {
            Response<SistemasResponse> response;
            SistemasEntity objSistemas;

            try
            {
                objSistemas = await SistemasData.InsertSistemas(ID_tb_Sistema_Mant,Descripcion);

 

                response = new Response<SistemasResponse>
                {
                    EsCorrecto = true,
                    Valor = new SistemasResponse
                    {
                        Sistemas = objSistemas
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
                return new Response<SistemasResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<SistemasResponse>> UpdateSistemas(short ID_tb_Sistema_Mant, string Descripcion)
        {
            Response<SistemasResponse> response;
            SistemasEntity objSistemas;

            try
            {
                objSistemas = await SistemasData.UpdateSistemas(ID_tb_Sistema_Mant, Descripcion);

                response = new Response<SistemasResponse>
                {
                    EsCorrecto = true,
                    Valor = new SistemasResponse
                    {
                        Sistemas = objSistemas
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
                return new Response<SistemasResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

    }

     


}
