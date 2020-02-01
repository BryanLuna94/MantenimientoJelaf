using System.Collections.Generic;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Mantenimiento.DataAccess;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Others;
using Mantenimiento.Utility;
using Mantenimiento.Entities.Peticiones.Responses;
using Mantenimiento.Entities.Objects.Filters;
using Mantenimiento.Entities.Peticiones.Requests;
using Mantenimiento.Entities.Objects.Lists;

namespace Mantenimiento.BusinessLayer
{
    public class AuxilioMecanicoLogic
    {
        public static Response<AuxilioMecanicoResponse> ListAuxilioMecanico(AuxilioMecanicoRequest request)
        {
            try
            {
                Response<AuxilioMecanicoResponse> response;
                List<AuxilioMecanicoList> List;
                AuxilioMecanicoFilter objFiltro;
                DateTime fechaHoraIni;
                DateTime fechaHoraFin;

                objFiltro = request.Filtro;
                if (objFiltro.FechaInicio == "") objFiltro.FechaInicio = DateTime.Now.ToShortDateString();
                if (objFiltro.FechaFin == "") objFiltro.FechaFin = DateTime.Now.AddDays(1).ToShortDateString();
                if (objFiltro.Are_codigo == null) objFiltro.Are_codigo = "";
                if (objFiltro.FechaFin == null) objFiltro.FechaFin = "";

                fechaHoraIni = DateTime.Parse(objFiltro.FechaInicio);
                fechaHoraFin = DateTime.Parse(objFiltro.FechaFin);

                List = AuxilioMecanicoData.ListAuxilioMecanico(fechaHoraIni, fechaHoraFin, objFiltro.Are_codigo, objFiltro.Ben_codigo);

                response = new Response<AuxilioMecanicoResponse>
                {
                    EsCorrecto = true,
                    Valor = new AuxilioMecanicoResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<AuxilioMecanicoResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<AuxilioMecanicoResponse> SelectAuxilioMecanico(int ID_Tb_AuxilioMecanico)
        {
            try
            {
                Response<AuxilioMecanicoResponse> response;
                AuxilioMecanicoEntity List;

                List = AuxilioMecanicoData.SelectAuxilioMecanico(ID_Tb_AuxilioMecanico);

                response = new Response<AuxilioMecanicoResponse>
                {
                    EsCorrecto = true,
                    Valor = new AuxilioMecanicoResponse { AuxilioMecanico = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<AuxilioMecanicoResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<AuxilioMecanicoResponse>> DeleteAuxilioMecanico(int ID_Tb_AuxilioMecanico)
        {
            Response<AuxilioMecanicoResponse> response;
            AuxilioMecanicoEntity objAuxilioMecanico;

            try
            {
                objAuxilioMecanico = await AuxilioMecanicoData.DeleteAuxilioMecanico(ID_Tb_AuxilioMecanico);

                if (objAuxilioMecanico != null)
                {
                    BusinessException.Generar(Constants.NO_ELIMINO);
                }

                response = new Response<AuxilioMecanicoResponse>
                {
                    EsCorrecto = true,
                    Valor = new AuxilioMecanicoResponse
                    {
                        AuxilioMecanico = objAuxilioMecanico
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
                return new Response<AuxilioMecanicoResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<AuxilioMecanicoResponse>> InsertAuxilioMecanico(AuxilioMecanicoRequest request)
        {
            Response<AuxilioMecanicoResponse> response;
            AuxilioMecanicoEntity objAuxilioMecanico;

            try
            {
                objAuxilioMecanico = request.AuxilioMecanico;
                int idAuxilioMecanico = await AuxilioMecanicoData.InsertAuxilioMecanico(objAuxilioMecanico);

                response = new Response<AuxilioMecanicoResponse>
                {
                    EsCorrecto = true,
                    Valor = new AuxilioMecanicoResponse
                    {
                        AuxilioMecanico = objAuxilioMecanico
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
                return new Response<AuxilioMecanicoResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<AuxilioMecanicoResponse>> UpdateAuxilioMecanico(AuxilioMecanicoRequest request)
        {
            Response<AuxilioMecanicoResponse> response;
            AuxilioMecanicoEntity objAuxilioMecanico;

            try
            {
                objAuxilioMecanico = request.AuxilioMecanico;
                objAuxilioMecanico = await AuxilioMecanicoData.UpdateAuxilioMecanico(objAuxilioMecanico);

                response = new Response<AuxilioMecanicoResponse>
                {
                    EsCorrecto = true,
                    Valor = new AuxilioMecanicoResponse
                    {
                        AuxilioMecanico = objAuxilioMecanico
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
                return new Response<AuxilioMecanicoResponse>(false, null, Functions.MessageError(ex), false);
            }
        }
    }
}
