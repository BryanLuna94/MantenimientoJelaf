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
    public static class ClaseMLogic
    {

        public static Response<ClaseMResponse> ListClaseM()
        {
            try
            {
                Response<ClaseMResponse> response;
                List<ClaseMEntity> List;

                List = ClaseMData.ListClaseM();

                response = new Response<ClaseMResponse>
                {
                    EsCorrecto = true,
                    Valor = new ClaseMResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<ClaseMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }
        public static Response<ClaseMResponse> ListClaseMP()
        {
            try
            {
                Response<ClaseMResponse> response;
                List<ClaseMEntity> List;

                List = ClaseMData.ListClaseMP();

                response = new Response<ClaseMResponse>
                {
                    EsCorrecto = true,
                    Valor = new ClaseMResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<ClaseMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<ClaseMResponse> SelectClaseM(string IdClaseMantenimiento)
        {
            try
            {
                Response<ClaseMResponse> response;
                List<ClaseMEntity> List;

                List = ClaseMData.SelectClaseM(IdClaseMantenimiento);

                response = new Response<ClaseMResponse>
                {
                    EsCorrecto = true,
                    Valor = new ClaseMResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<ClaseMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<ClaseMResponse>> DeleteClaseM(string IdClaseMantenimiento)
        {
            Response<ClaseMResponse> response;
            ClaseMEntity objClaseM;

            try
            {
                objClaseM = await ClaseMData.DeleteClaseM(IdClaseMantenimiento);

                if (objClaseM != null)
                {
                    BusinessException.Generate(Constants.NO_ELIMINO);
                }

                response = new Response<ClaseMResponse>
                {
                    EsCorrecto = true,
                    Valor = new ClaseMResponse
                    {
                        ClaseM = objClaseM
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
                return new Response<ClaseMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }



        public static async Task<Response<ClaseMResponse>> InsertClaseM(string IdClaseMantenimiento, string Descripcion, short NroOrden)
        {
            Response<ClaseMResponse> response;
            ClaseMEntity objClaseM;

            try
            {
                objClaseM = await ClaseMData.InsertClaseM(IdClaseMantenimiento, Descripcion, NroOrden);

                response = new Response<ClaseMResponse>
                {
                    EsCorrecto = true,
                    Valor = new ClaseMResponse
                    {
                        ClaseM = objClaseM
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
                return new Response<ClaseMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<ClaseMResponse>> UpdateClaseM(string IdClaseMantenimiento, string Descripcion, short NroOrden)
        {
            Response<ClaseMResponse> response;
            ClaseMEntity objClaseM;

            try
            {
                objClaseM = await ClaseMData.UpdateClaseM(IdClaseMantenimiento, Descripcion, NroOrden);

                response = new Response<ClaseMResponse>
                {
                    EsCorrecto = true,
                    Valor = new ClaseMResponse
                    {
                        ClaseM = objClaseM
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
                return new Response<ClaseMResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

    }




}
