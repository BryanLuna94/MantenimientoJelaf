using System.Collections.Generic;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Mantenimiento.DataAccess;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Others;
using Mantenimiento.Entities.Requests.Responses;
using Mantenimiento.Utility;
using System.Linq;

namespace Mantenimiento.BusinessLayer
{
    public static class TipoMPLogic
    {
        public static Response<TipoMPResponse> IdTipoMP()
        {
            try
            {
                Response<TipoMPResponse> response;
                List<TipoMPEntity> List;

                List = TipoMPData.IdTipoMP();

                response = new Response<TipoMPResponse>
                {
                    EsCorrecto = true,
                    Valor = new TipoMPResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<TipoMPResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<TipoMPResponse> ListTipoMP()
        {
            try
            {
                Response<TipoMPResponse> response;
                List<TipoMPEntity> List;

                List = TipoMPData.ListTipoMP();

                response = new Response<TipoMPResponse>
                {
                    EsCorrecto = true,
                    Valor = new TipoMPResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<TipoMPResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<TipoMPResponse> ListTipoMP(TipoMPResponse request)
        {
            try
            {
                Response<TipoMPResponse> response;
                List<TipoMPEntity> List;
            
                List = TipoMPData.ListTipoMP();


                response = new Response<TipoMPResponse>
                {
                    EsCorrecto = true,
                    Valor = new TipoMPResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<TipoMPResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        //public static Response<TipoMPResponse> ListMP()
        //{
        //    try
        //    {
        //        Response<TipoMPResponse> response;
        //        List<MarcaModeloEntity> ListMarcaModelo;
        //        List<TipoMPEntity> ListTipoMP;

        //        ListMarcaModelo = MarcaModeloData.ListMarcaModelo();
        //        ListTipoMP = TipoMPData.ListTipoMP();




        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response<TipoMPResponse>(false, null, Functions.MessageError(ex), false);
        //    }
        //}

        public static Response<TipoMPResponse> SelectTipoMP(short IdTipMan)
        {
            try
            {
                Response<TipoMPResponse> response;
                List<TipoMPEntity> List;

                List = TipoMPData.SelectTipoMP(IdTipMan);

                response = new Response<TipoMPResponse>
                {
                    EsCorrecto = true,
                    Valor = new TipoMPResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<TipoMPResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<TipoMPResponse>> DeleteTipoMP(short IdTipMan)
        {
            Response<TipoMPResponse> response;
            TipoMPEntity objTipoMP;

            try
            {
                objTipoMP = await TipoMPData.DeleteTipoMP(IdTipMan);

                if (objTipoMP != null)
                {
                    BusinessException.Generar(Constants.NO_ELIMINO);
                }

                response = new Response<TipoMPResponse>
                {
                    EsCorrecto = true,
                    Valor = new TipoMPResponse
                    {
                        TipoMP = objTipoMP
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
                return new Response<TipoMPResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<TipoMPResponse>> InsertTipoMP(short IdTipMan, string Descripcion, decimal Kilometros, decimal KilometrosAviso,
            short UsuarioRegistro, string FechaRegistro, short Dias, short DiasAviso, short Horas, short HorasAviso, string cod_marca, int cod_modelo,short Meses, short MesesAviso)
        {
            Response<TipoMPResponse> response;
            TipoMPEntity objTipoMP;

            try
            {
                objTipoMP = await TipoMPData.InsertTipoMP(IdTipMan, Descripcion, Kilometros, KilometrosAviso,
                    UsuarioRegistro, Convert.ToDateTime(FechaRegistro), Dias, DiasAviso, Horas, HorasAviso, cod_marca, cod_modelo, Meses, MesesAviso);

                response = new Response<TipoMPResponse>
                {
                    EsCorrecto = true,
                    Valor = new TipoMPResponse
                    {
                        TipoMP = objTipoMP
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
                return new Response<TipoMPResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<TipoMPResponse>> UpdateTipoMP(short IdTipMan, string Descripcion,
            decimal Kilometros, decimal KilometrosAviso, short Dias,
            short DiasAviso, short Horas, short HorasAviso, short Meses, short MesesAviso)
        {
            Response<TipoMPResponse> response;
            TipoMPEntity objTipoMP;

            try
            {
                objTipoMP = await TipoMPData.UpdateTipoMP(IdTipMan, Descripcion, Kilometros, KilometrosAviso,
                    Dias, DiasAviso, Horas, HorasAviso, Meses, MesesAviso);

                response = new Response<TipoMPResponse>
                {
                    EsCorrecto = true,
                    Valor = new TipoMPResponse
                    {
                        TipoMP = objTipoMP
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
                return new Response<TipoMPResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

    }




}
