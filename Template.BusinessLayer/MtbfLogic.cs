using System.Collections.Generic;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Mantenimiento.DataAccess;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Others;
using Mantenimiento.Utility;
using Mantenimiento.Entities.Peticiones.Responses;
using System.Linq;
using Mantenimiento.Entities.Peticiones.Requests;
using System.Transactions;

namespace Mantenimiento.BusinessLayer
{
    public class MtbfLogic
    {
        public static Response<MtbfResponse> ListMtbf(short anio)
        {
            try
            {
                Response<MtbfResponse> response;
                List<MTBFEntity> ListAnterior;
                List<MTBFEntity> List;
                MTBFEntity objVacio;
                decimal Bam;
                short ViajeEnHoras;
                byte HorasDia;

                List = new List<MTBFEntity>();
                ListAnterior = MtbfData.ListMTBF(anio);

                if (ListAnterior.Count > 0)
                {
                    Bam = ListAnterior[0].Bam;
                    HorasDia = ListAnterior[0].HorasDia;
                    ViajeEnHoras = ListAnterior[0].ViajeEnHoras;
                }
                else
                {
                    Bam = 0;
                    HorasDia = 0;
                    ViajeEnHoras = 0;
                }

                for (int i = 1; i <= 12; i++)
                {
                    var existe = ListAnterior.FirstOrDefault(x => x.NumMes == i);
                    if (existe != null)
                    {
                        List.Add(existe);
                    }
                    else
                    {
                        objVacio = new MTBFEntity
                        {
                            Anio = anio,
                            Bam = 0,
                            CambioTractos = 0,
                            DiasMes = (byte)DateTime.DaysInMonth(anio, i),
                            IdMtbf = 0,
                            NombreMes = Functions.NombreMes(i),
                            NumMes = (byte)i,
                        };
                        List.Add(objVacio);
                    }
                }

                response = new Response<MtbfResponse>
                {
                    EsCorrecto = true,
                    Valor = new MtbfResponse
                    {
                        List = List,
                        Bam = Bam,
                        HorasDia = HorasDia,
                        ViajeEnHoras = ViajeEnHoras
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<MtbfResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        private static string convertHoraDecimalToString(double hora)
        {
            var final = "";
            var horaFormato = TimeSpan.FromHours(hora);
            var horasFinal = horaFormato.Hours;
            var minutosFinal = horaFormato.Minutes;
            var segundosFinal = horaFormato.Seconds;
            var dias = horaFormato.Days;
            if (dias > 0)
            {
                horasFinal = dias * 24 + horasFinal;
            }

            final = horasFinal + ":" + minutosFinal.ToString("0#") + ":" + segundosFinal.ToString("0#");

            return final;
        }

        public static Response<MtbfResponse> ListMtbf_AuxilioMecanico(short anio)
        {
            try
            {
                Response<MtbfResponse> response;
                List<MTBFEntity> ListAnterior;
                List<MTBFEntity> List;
                List<AuxilioMecanicoEntity> ListAuxilioMecanico;
                MTBFEntity objVacio;

                List = new List<MTBFEntity>();
                ListAnterior = MtbfData.ListMTBF(anio);
                for (int i = 1; i <= 12; i++)
                {
                    var existe = ListAnterior.FirstOrDefault(x => x.NumMes == i);
                    ListAuxilioMecanico = AuxilioMecanicoData.ListAuxilioMecanicoPorAnioMes(anio, (byte)i);
                    var totalHoras = ListAuxilioMecanico.Sum(x => ((Convert.ToDateTime(x.Fechahora_fin) - Convert.ToDateTime(x.Fechahora_ini)).TotalHours));
                    short fallasMecanicas = (short)ListAuxilioMecanico.Count();
                    var mttr = (ListAuxilioMecanico.Count > 0) ? convertHoraDecimalToString(totalHoras / fallasMecanicas) : "";
                    int kmPerdidos = (int)ListAuxilioMecanico.Sum(x => x.Kmt_Perdido);
                    byte cambioTractos = (byte)ListAuxilioMecanico.Sum(x => x.CambioTracto);
                    objVacio = new MTBFEntity
                    {
                        Anio = anio,
                        Bam = 0,
                        ViajeEnHoras = 0,
                        HorasDia = 0,
                        DiasMes = (existe != null) ? existe.DiasMes : (byte)DateTime.DaysInMonth(anio, i),
                        Viajes = (existe != null) ? existe.Viajes : (short)0,
                        FallasMecanicas = fallasMecanicas,
                        TotalHoras = convertHoraDecimalToString(totalHoras),
                        MTTR = mttr,
                        MetaMTBF = (existe != null) ? existe.MetaMTBF : (short)0,
                        KmPerdidos = kmPerdidos,
                        Meta = (existe != null) ? existe.Meta : 0,
                        CambioTractos = cambioTractos,
                        NombreMes = Functions.NombreMes(i),
                        NumMes = (byte)i
                    };
                    List.Add(objVacio);
                }

                response = new Response<MtbfResponse>
                {
                    EsCorrecto = true,
                    Valor = new MtbfResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<MtbfResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<MtbfResponse>> DeleteMtbf(short IdMtbf)
        {
            Response<MtbfResponse> response;
            MTBFEntity objMtbf;

            try
            {
                objMtbf = await MtbfData.DeleteMTBF(IdMtbf);

                if (objMtbf != null)
                {
                    BusinessException.Generate(Constants.NO_ELIMINO);
                }

                response = new Response<MtbfResponse>
                {
                    EsCorrecto = true,
                    Valor = new MtbfResponse
                    {
                        Mtbf = objMtbf
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
                return new Response<MtbfResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<MtbfResponse>> InsertMtbf(MtbfRequest request)
        {
            Response<MtbfResponse> response;
            List<MTBFEntity> ListMtbf;
            decimal Bam;
            short ViajeEnHoras;
            short Anio;
            byte HorasDia;

            ListMtbf = request.ListMtbf;
            Bam = request.Bam;
            ViajeEnHoras = request.ViajeEnHoras;
            HorasDia = request.HorasDia;
            Anio = request.Anio;

            try
            {
                await MtbfData.DeleteMTBF_Anio(Anio);

                foreach (var item in ListMtbf)
                {
                    item.HorasDia = HorasDia;
                    item.Bam = Bam;
                    item.ViajeEnHoras = ViajeEnHoras;
                    item.Anio = Anio;
                    item.FechaHoraRegistro = DateTime.Now;
                    item.UsuarioRegistro = "";
                    await MtbfData.InsertMTBF(item);
                }

                response = new Response<MtbfResponse>
                {
                    EsCorrecto = true,
                    Valor = new MtbfResponse
                    {
                        Mtbf = new MTBFEntity()
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
                return new Response<MtbfResponse>(false, null, Functions.MessageError(ex), false);
            }
        }
    }
}
