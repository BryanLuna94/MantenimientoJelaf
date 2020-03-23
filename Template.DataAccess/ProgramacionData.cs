using System;

using System.Data;
using System.Data.SqlClient;

using System.Threading.Tasks;
using Mantenimiento.DataAccess.Connection;
using Mantenimiento.Entities.Objects.Entities;
using System.Collections.Generic;
using Mantenimiento.Utility;
using Mantenimiento.Entities.Objects.Lists;
using Mantenimiento.Entities.Objects.Filters;

namespace Mantenimiento.DataAccess
{
    public static class ProgramacionData
    {
        public static List<OrdenMasivaList> ListOrdenMasiva(OrdenMasivaFilter objFiltro)
        {
            List<OrdenMasivaList> List = new List<OrdenMasivaList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_OrdenesMasivas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FecIni", SqlDbType.VarChar).Value = objFiltro.FecIni;
                    cmd.Parameters.Add("@FecFin", SqlDbType.VarChar).Value = objFiltro.FecFin;
                    cmd.Parameters.Add("@Origen", SqlDbType.VarChar).Value = objFiltro.Origen;
                    cmd.Parameters.Add("@Destino", SqlDbType.VarChar).Value = objFiltro.Destino;
                    cmd.Parameters.Add("@Unidad", SqlDbType.VarChar).Value = objFiltro.Unidad;
                    cmd.Parameters.Add("@Chofer", SqlDbType.VarChar).Value = objFiltro.Chofer;
                    cmd.Parameters.Add("@Generado", SqlDbType.Bit).Value = objFiltro.Generado;
                    cmd.Parameters.Add("@Orden", SqlDbType.VarChar).Value = objFiltro.Orden;
                    cmd.Parameters.Add("@X", SqlDbType.VarChar).Value = 0;
                    cmd.Parameters.Add("@tipoU", SqlDbType.VarChar).Value = 3;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new OrdenMasivaList
                            {
                                Codi_Programacion = DataReader.GetStringValue(dr, "Codi_Programacion"),
                                IdUnidad = DataReader.GetStringValue(dr, "IdUnidad"),
                                BusCodInt = DataReader.GetStringValue(dr, "BusCodInt"),
                                CodOrigen = DataReader.GetStringValue(dr, "CodOrigen"),
                                BusPlaca = DataReader.GetStringValue(dr, "BusPlaca"),
                                Origen = DataReader.GetStringValue(dr, "Origen"),
                                CodDestino = DataReader.GetStringValue(dr, "CodDestino"),
                                Destino = DataReader.GetStringValue(dr, "Destino"),
                                FechaViaje = Convert.ToDateTime(DataReader.GetStringValue(dr, "FechaViaje")).ToShortDateString(),
                                HoraViaje = DataReader.GetStringValue(dr, "HoraViaje"),
                                IDChofer = DataReader.GetStringValue(dr, "IDChofer"),
                                Ben_Nombre = DataReader.GetStringValue(dr, "Ben_Nombre"),
                                KILOMETRAJE = DataReader.GetStringValue(dr, "KILOMETRAJE"),
                                Generado = DataReader.GetBooleanValue(dr, "Generado"),
                                Correctivo = Functions.Check.Bool(DataReader.GetStringValue(dr, "Correctivo")),
                                Preventivo = Functions.Check.Bool(DataReader.GetStringValue(dr, "Preventivo")),
                                NumeroOrden = DataReader.GetStringValue(dr, "NumeroOrden"),
                                NumeroMantenimiento = DataReader.GetStringValue(dr, "NumeroMantenimiento"),
                                Tipo_s = DataReader.GetStringValue(dr, "Tipo_s"),
                                Externo = DataReader.GetStringValue(dr, "Externo"),
                                Empresa = DataReader.GetStringValue(dr, "Empresa"),
                                Glosa = DataReader.GetStringValue(dr, "Glosa"),
                                Odometro = DataReader.GetStringValue(dr, "Odometro"),
                                RUTAVIAJE = DataReader.GetStringValue(dr, "RUTAVIAJE"),
                                tipo = DataReader.GetStringValue(dr, "tipo"),
                                CODI_PROGRAMACION_REAL = DataReader.GetStringValue(dr, "CODI_PROGRAMACION_REAL")
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

        public static async Task<ProgramacionEntity> UpdateProgramacionOrdenCorrectivoGeneracion(ProgramacionEntity objEntidad)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UDP_PROGRAMACION_OrdenCorrectivo_Generacion", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pCODI_BUS", SqlDbType.VarChar).Value = objEntidad.CODI_BUS;
                        cmd.Parameters.Add("@pCODI_PROGRAMACION", SqlDbType.VarChar).Value = objEntidad.CODI_PROGRAMACION;
                        cmd.Parameters.Add("@pFechaGeneracion", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.FechaGeneracion);
                        cmd.Parameters.Add("@pHoraGeneracion", SqlDbType.VarChar).Value = objEntidad.HoraGeneracion;
                        cmd.Parameters.Add("@pKMT_VIAJE", SqlDbType.Decimal).Value = objEntidad.KMT_VIAJE;
                        cmd.Parameters.Add("@pNumeroMantenimiento", SqlDbType.VarChar).Value = objEntidad.NumeroMantenimieto;
                        cmd.Parameters.Add("@pNumeroOrden", SqlDbType.VarChar).Value = objEntidad.NumeroOrden;
                        cmd.Parameters.Add("@pUsuarioGeneracion", SqlDbType.VarChar).Value = objEntidad.UsuarioGeneracion;

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

        public static async Task<ProgramacionEntity> UpdateProgramacionOrdenCorrectivoAnulacion(string Codi_Programacion)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UDP_PROGRAMACION_OrdenCorrectivo_Anulacion", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pCODI_PROGRAMACION", SqlDbType.VarChar).Value = Codi_Programacion;

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

        public static async Task<ProgramacionEntity> UpdateProgramacionOrdenPreventivoGeneracion(ProgramacionEntity objEntidad)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UDP_PROGRAMACION_OrdenPreventivo_Generacion", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pCODI_PROGRAMACION", SqlDbType.VarChar).Value = objEntidad.CODI_PROGRAMACION;
                        cmd.Parameters.Add("@pNumeroMantenimiento", SqlDbType.VarChar).Value = objEntidad.NumeroMantenimieto;

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

        public static async Task<ProgramacionEntity> UpdateProgramacionOrdenPreventivoAnulacion(string Codi_Programacion)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UDP_PROGRAMACION_OrdenPreventivo_Anulacion", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pCODI_PROGRAMACION", SqlDbType.VarChar).Value = Codi_Programacion;

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

        public static ProgramacionEntity SelectProgramacionPorInforme(string idInforme, int tipo)
        {
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_PROGRAMACION_ObtenerProgramacionPorInforme", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pNumeroInforme", SqlDbType.VarChar).Value = idInforme;
                    cmd.Parameters.Add("@pTipoInforme", SqlDbType.Int).Value = tipo;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return new ProgramacionEntity
                            {
                                CODI_PROGRAMACION = DataReader.GetStringValue(dr, "CODI_PROGRAMACION"),
                            };
                        }

                        dr.Close();
                    }

                    cmd.Dispose();
                }

                if (con.State == ConnectionState.Open) { con.Close(); }
            }

            return null;
        }
    }
}
