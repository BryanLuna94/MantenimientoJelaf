using System;
using System.Collections.Generic;
using Mantenimiento.DataAccess;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Others;
using Mantenimiento.Entities.Requests.Responses;
using Mantenimiento.Utility;

namespace Mantenimiento.BusinessLayer
{
    public static class BaseLogic
    {
        public static Response<BaseResponse> ListEmpresa()
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListEmpresa();

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }
        public static Response<BaseResponse> ListUsuariosAutocomplete(string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListUsuariosAutocomplete(value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<BaseResponse> ListSistemasAutocomplete(string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListSistemasAutocomplete(value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<BaseResponse> ListSubSistemasAutocomplete(string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListSubSistemasAutocomplete(value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<BaseResponse> ListTipoMAutocomplete(string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListTipoMAutocomplete(value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<BaseResponse> ListFlotaAutocomplete(string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListFlotaAutocomplete(value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<BaseResponse> ListPlataformaAutocomplete(string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListPlataformaAutocomplete(value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<BaseResponse> ListTareasCAutocomplete(string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListTareasAutocomplete(value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<BaseResponse> ListTareasAutocomplete(string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListTareasAutocomplete(value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<BaseResponse> ListBeneficiarioAutocomplete(string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListBeneficiarioAutocomplete(value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<BaseResponse> ListPlanAccionAutocomplete(string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListPlanAccionAutocomplete(value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<BaseResponse> ListPuntoAtencionAutocomplete(string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListPuntoAtencionAutocomplete(value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<BaseResponse> ListMecanicosAutocomplete(string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListMecanicosAutocomplete(value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<BaseResponse> ListAlmacenesAutocomplete(string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListAlmacenesAutocomplete(value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<BaseResponse> ListArticulosAutocomplete(string idEmpresa, string idAlmacen, string value)
        {
            try
            {
                Response<BaseResponse> response;
                List<BaseEntity> List;

                List = BaseData.ListArticulosAutocomplete(idEmpresa, idAlmacen, value);

                response = new Response<BaseResponse>
                {
                    EsCorrecto = true,
                    Valor = new BaseResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<BaseResponse>(false, null, Functions.MessageError(ex), false);
            }
        }
    }
}
