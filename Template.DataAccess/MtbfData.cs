using System;

using System.Data;
using System.Data.SqlClient;

using System.Threading.Tasks;
using Mantenimiento.DataAccess.Connection;
using Mantenimiento.Entities.Objects.Entities;
using System.Collections.Generic;
using Mantenimiento.Utility;
using Mantenimiento.Entities.Objects.Lists;


namespace Mantenimiento.DataAccess
{
    public class MtbfData
    {
        public static List<MTBFEntity> ListMTBF(short anio)
        {
            List<MTBFEntity> List = new List<MTBFEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_LIST_tb_MTBF", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pAnio", SqlDbType.SmallInt).Value = anio;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new MTBFEntity
                            {
                                IdMtbf = DataReader.GetIntValue(dr, "IdMtbf"),
                                Bam = DataReader.GetDecimalValue(dr, "Bam"),
                                ViajeEnHoras = DataReader.GetSmallIntValue(dr, "ViajeEnHoras"),
                                HorasDia = DataReader.GetTinyIntValue(dr, "HorasDia"),
                                Anio = DataReader.GetSmallIntValue(dr, "Anio"),
                                NumMes = DataReader.GetTinyIntValue(dr, "NumMes"),
                                DiasMes = DataReader.GetTinyIntValue(dr, "DiasMes"),
                                Viajes = DataReader.GetSmallIntValue(dr, "Viajes"),
                                FallasMecanicas = DataReader.GetSmallIntValue(dr, "FallasMecanicas"),
                                TotalHoras = DataReader.GetStringValue(dr, "TotalHoras"),
                                MTTR = DataReader.GetStringValue(dr, "MTTR"),
                                MetaMTBF = DataReader.GetSmallIntValue(dr, "MetaMTBF"),
                                MTBFHorasTotales = DataReader.GetSmallIntValue(dr, "MTBFHorasTotales"),
                                MTBFDiario = DataReader.GetSmallIntValue(dr, "MTBFDiario"),
                                MTBFViajes = DataReader.GetSmallIntValue(dr, "MTBFViajes"),
                                KmPerdidos = DataReader.GetIntValue(dr, "KmPerdidos"),
                                Meta = DataReader.GetDecimalValue(dr, "Meta"),
                                Eficiencia = DataReader.GetDecimalValue(dr, "Eficiencia"),
                                CambioTractos = DataReader.GetTinyIntValue(dr, "CambioTractos"),
                                DisponibilidadMecanica = DataReader.GetDecimalValue(dr, "DisponibilidadMecanica"),
                                DisponibilidadFlota = DataReader.GetDecimalValue(dr, "DisponibilidadFlota"),
                                NombreMes = Functions.NombreMes(DataReader.GetTinyIntValue(dr, "NumMes"))
                            });
                        }

                        dr.Close();
                    }

                    cmd.Dispose();
                }

                if (con.State == ConnectionState.Open) { con.Close(); }
            }

            return List;
        }

        public static async Task<int> InsertMTBF(MTBFEntity objEntidad)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_INS_tb_MTBF", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pBam", SqlDbType.Decimal).Value = objEntidad.Bam;
                        cmd.Parameters.Add("@pViajeEnHoras", SqlDbType.SmallInt).Value = objEntidad.ViajeEnHoras;
                        cmd.Parameters.Add("@pHorasDia", SqlDbType.TinyInt).Value = objEntidad.HorasDia;
                        cmd.Parameters.Add("@pAnio", SqlDbType.SmallInt).Value = objEntidad.Anio;
                        cmd.Parameters.Add("@pNumMes", SqlDbType.TinyInt).Value = objEntidad.NumMes;
                        cmd.Parameters.Add("@pDiasMes", SqlDbType.TinyInt).Value = objEntidad.DiasMes;
                        cmd.Parameters.Add("@pViajes", SqlDbType.SmallInt).Value = objEntidad.Viajes;
                        cmd.Parameters.Add("@pFallasMecanicas", SqlDbType.SmallInt).Value = objEntidad.FallasMecanicas;
                        cmd.Parameters.Add("@pTotalHoras", SqlDbType.VarChar).Value = Functions.Check.Cadena(objEntidad.TotalHoras);
                        cmd.Parameters.Add("@pMTTR", SqlDbType.VarChar).Value = Functions.Check.Cadena(objEntidad.MTTR);
                        cmd.Parameters.Add("@pMetaMTBF", SqlDbType.SmallInt).Value = objEntidad.MetaMTBF;
                        cmd.Parameters.Add("@pMTBFHorasTotales", SqlDbType.SmallInt).Value = objEntidad.MTBFHorasTotales;
                        cmd.Parameters.Add("@pMTBFDiario", SqlDbType.SmallInt).Value = objEntidad.MTBFDiario;
                        cmd.Parameters.Add("@pMTBFViajes", SqlDbType.SmallInt).Value = objEntidad.MTBFViajes;
                        cmd.Parameters.Add("@pKmPerdidos", SqlDbType.Int).Value = objEntidad.KmPerdidos;
                        cmd.Parameters.Add("@pMeta", SqlDbType.Decimal).Value = objEntidad.Meta;
                        cmd.Parameters.Add("@pEficiencia", SqlDbType.Decimal).Value = objEntidad.Eficiencia;
                        cmd.Parameters.Add("@pCambioTractos", SqlDbType.TinyInt).Value = objEntidad.CambioTractos;
                        cmd.Parameters.Add("@pDisponibilidadMecanica", SqlDbType.Decimal).Value = objEntidad.DisponibilidadMecanica;
                        cmd.Parameters.Add("@pDisponibilidadFlota", SqlDbType.Decimal).Value = objEntidad.DisponibilidadFlota;
                        cmd.Parameters.Add("@pFechaHoraRegistro", SqlDbType.DateTime).Value = objEntidad.FechaHoraRegistro;
                        cmd.Parameters.Add("@pUsuarioRegistro", SqlDbType.VarChar).Value = objEntidad.UsuarioRegistro;
                        cmd.Parameters.Add("@pIdMtbf", SqlDbType.Int).Value = 0;
                        await cmd.ExecuteNonQueryAsync();
                        nuevoId = Convert.ToInt32(cmd.Parameters["@pIdMtbf"].Value);
                        cmd.Dispose();
                    }

                    if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return nuevoId;
        }

        public static async Task<MTBFEntity> UpdateMTBF(MTBFEntity objEntidad)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UPD_Tb_MTBF", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pBam", SqlDbType.Decimal).Value = objEntidad.Bam;
                        cmd.Parameters.Add("@pViajeEnHoras", SqlDbType.SmallInt).Value = objEntidad.ViajeEnHoras;
                        cmd.Parameters.Add("@pHorasDia", SqlDbType.TinyInt).Value = objEntidad.HorasDia;
                        cmd.Parameters.Add("@pAnio", SqlDbType.SmallInt).Value = objEntidad.Anio;
                        cmd.Parameters.Add("@pNumMes", SqlDbType.TinyInt).Value = objEntidad.NumMes;
                        cmd.Parameters.Add("@pDiasMes", SqlDbType.TinyInt).Value = objEntidad.DiasMes;
                        cmd.Parameters.Add("@pViajes", SqlDbType.SmallInt).Value = objEntidad.Viajes;
                        cmd.Parameters.Add("@pFallasMecanicas", SqlDbType.SmallInt).Value = objEntidad.FallasMecanicas;
                        cmd.Parameters.Add("@pTotalHoras", SqlDbType.VarChar).Value = objEntidad.TotalHoras;
                        cmd.Parameters.Add("@pMTTR", SqlDbType.VarChar).Value = objEntidad.MTTR;
                        cmd.Parameters.Add("@pMetaMTBF", SqlDbType.SmallInt).Value = objEntidad.MetaMTBF;
                        cmd.Parameters.Add("@pMTBFHorasTotales", SqlDbType.SmallInt).Value = objEntidad.MTBFHorasTotales;
                        cmd.Parameters.Add("@pMTBFDiario", SqlDbType.SmallInt).Value = objEntidad.MTBFDiario;
                        cmd.Parameters.Add("@pMTBFViajes", SqlDbType.SmallInt).Value = objEntidad.MTBFViajes;
                        cmd.Parameters.Add("@pKmPerdidos", SqlDbType.Int).Value = objEntidad.KmPerdidos;
                        cmd.Parameters.Add("@pMeta", SqlDbType.Decimal).Value = objEntidad.Meta;
                        cmd.Parameters.Add("@pEficiencia", SqlDbType.Decimal).Value = objEntidad.Eficiencia;
                        cmd.Parameters.Add("@pCambioTractos", SqlDbType.TinyInt).Value = objEntidad.CambioTractos;
                        cmd.Parameters.Add("@pDisponibilidadMecanica", SqlDbType.Decimal).Value = objEntidad.DisponibilidadMecanica;
                        cmd.Parameters.Add("@pDisponibilidadFlota", SqlDbType.Decimal).Value = objEntidad.DisponibilidadFlota;
                        cmd.Parameters.Add("@pFechaHoraRegistro", SqlDbType.DateTime).Value = objEntidad.FechaHoraRegistro;
                        cmd.Parameters.Add("@pUsuarioRegistro", SqlDbType.VarChar).Value = objEntidad.UsuarioRegistro;
                        cmd.Parameters.Add("@pId_MTBF", SqlDbType.Int).Value = objEntidad.IdMtbf;
                        await cmd.ExecuteNonQueryAsync();
                        cmd.Dispose();
                    }

                    if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;

        }

        public static async Task<MTBFEntity> DeleteMTBF(int IdMTBF)
        {


            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_DEL_Tb_MTBF", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pIdMTBF", SqlDbType.Int).Value = IdMTBF;

                        await cmd.ExecuteNonQueryAsync();
                        cmd.Dispose();
                    }

                    if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }

        public static async Task<MTBFEntity> DeleteMTBF_Anio(short anio)
        {


            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_DEL_tb_MTBF_Anio", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pAnio", SqlDbType.Int).Value = anio;

                        await cmd.ExecuteNonQueryAsync();
                        cmd.Dispose();
                    }

                    if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
    }
}
