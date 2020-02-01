using SeguridadJelaf;
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
    public static class LoginLogic
    {
        public static async Task<Response<LoginResponse>> Login(string codiUsuario, string Password)
        {
            Response<LoginResponse> response;
            UsuarioEntity objUsuario;

            try
            {
                objUsuario = await LoginData.Login(codiUsuario);

                objUsuario = await LoginData.Login(codiUsuario);

                if (objUsuario == null)
                {
                    BusinessException.Generar(Constants.USUARIO_NO_EXISTE);
                }

           //     if (Seguridad.Desencripta(objUsuario.Password, Constants.UnaLlave).ToUpper() != Password.ToUpper())
           //     {
            //        BusinessException.Generar(Constants.CLAVE_INCORRECTA);
            //    }



              if (objUsuario.Password.ToUpper() != Password.ToUpper())
                  {
                    BusinessException.Generar(Constants.CLAVE_INCORRECTA);
               }

                objUsuario.Password = null;
                response = new Response<LoginResponse>
                {
                    EsCorrecto = true,
                    Valor = new LoginResponse
                    {
                        Usuario = objUsuario
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
                return new Response<LoginResponse>(false, null, Functions.MessageError(ex), false);
            }
        }
    }


    public static class ActualizapwdLogic
    {
        public static async Task<Response<PwdResponse>> Actualizapwd(string codiUsuario, string Password)
        {
            Response<PwdResponse> response;
            UsuarioEntity objUsuario;

            try
            {
                objUsuario = await LoginData.Actualizapwd(codiUsuario,Password);

            

                if (Password == "")
                {
                    BusinessException.Generar(Constants.CLAVE_VACIA);
                }

                response = new Response<PwdResponse>

                {
                    EsCorrecto = true,
                    Valor = new PwdResponse
                    {
                        Usuario = objUsuario
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
                return new Response<PwdResponse>(false, null, Functions.MessageError(ex), false);
            }
        }
    }


}
