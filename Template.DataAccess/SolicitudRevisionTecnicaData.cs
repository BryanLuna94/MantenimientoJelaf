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
    public class SolicitudRevisionTecnicaData
    {
        public static int ObtenerUltimoId()
        {
            int ultimoId = 1;
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_SEL_tb_SolicitudRevisionTecnica_C_UltimoId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ultimoId = DataReader.GetIntValue(dr, "NumSol");
                            return ultimoId;
                        }

                        dr.Close();
                    }

                    cmd.Dispose();
                }

                if (con.State == ConnectionState.Open) { con.Close(); }
            }

            return ultimoId;
        }

        public static async Task<int> InsertSolicitudRevisionTecnica_C(SolicitudRevisionTecnica_CEntity objEntidad)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("Usp_tb_SolicitudRevisionTecnica_CInsert", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdSolicitudRevision", SqlDbType.VarChar).Value = objEntidad.IdSolicitudRevision;
                        cmd.Parameters.Add("@FechaDoc", SqlDbType.DateTime).Value = objEntidad.FechaDoc;
                        cmd.Parameters.Add("@HorasDoc", SqlDbType.VarChar).Value = objEntidad.HorasDoc;
                        cmd.Parameters.Add("@IdUnidad", SqlDbType.VarChar).Value = objEntidad.IdUnidad;
                        cmd.Parameters.Add("@IdChofer", SqlDbType.VarChar).Value = objEntidad.IdChofer;
                        cmd.Parameters.Add("@CodOrigen", SqlDbType.VarChar).Value = objEntidad.CodOrigen;
                        cmd.Parameters.Add("@CodDestino", SqlDbType.VarChar).Value = objEntidad.CodDestino;
                        cmd.Parameters.Add("@Kilometraje", SqlDbType.Decimal).Value = objEntidad.Kilometraje;
                        cmd.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = objEntidad.UsuarioRegistro;
                        cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = objEntidad.FechaRegistro;
                        cmd.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = objEntidad.HorasDoc;
                        cmd.Parameters.Add("@FechaViaje", SqlDbType.DateTime).Value = objEntidad.FechaViaje;
                        cmd.Parameters.Add("@HoraViahe", SqlDbType.VarChar).Value = objEntidad.HoraViahe;
                        cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = objEntidad.Estado;

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

            return nuevoId;
        }

        public static async Task<MTBFEntity> UpdateSolicitudRevisionTecnica_C_Correctivo(string IdSolicitudRevision, decimal Odometro, decimal NumInforme)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UPD_tb_SolicitudRevisionTecnica_C_Correctivo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pIdSolicitudRevision", SqlDbType.VarChar).Value = IdSolicitudRevision;
                        cmd.Parameters.Add("@pOdometro", SqlDbType.Decimal).Value = Odometro;
                        cmd.Parameters.Add("@pIdInforme", SqlDbType.Decimal).Value = NumInforme;
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

        public static async Task<MTBFEntity> AnularSolicitudRevisionTecnica_C_Correctivo(decimal NumInforme)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_DEL_tb_SolicitudRevisionTecnica_C_Anular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pNumeroInforme", SqlDbType.VarChar).Value = NumInforme;
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

        public static SolicitudRevisionTecnica_CEntity SelectSolicitudRevisionTecnica_C_Informe(int idInforme)
        {
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_SEL_tb_SolicitudRevisionTecnica_C_DatosInforme", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pIdInforme", SqlDbType.Int).Value = idInforme;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return new SolicitudRevisionTecnica_CEntity
                            {
                                IdSolicitudRevision = DataReader.GetStringValue(dr, "IdSolicitudRevision"),
                                Kilometraje = DataReader.GetDecimalValue(dr, "KIlometraje")
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

        public static SolicitudRevisionList SelectSolicitudRevision(string IdSolicitudRevision)
        {
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("Usp_tb_SolicitudRevisionTecnica_CSelect", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = IdSolicitudRevision;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return new SolicitudRevisionList
                            {
                                NumeroInforme = DataReader.GetDecimalValue(dr, "IdInforme"),
                                Odometro = DataReader.GetDecimalValue(dr, "Odometro"),
                                Chofer = DataReader.GetStringValue(dr, "Chofer"),
                                CorrelativoInterno = DataReader.GetStringValue(dr, "correlativo2"),
                                Destino = DataReader.GetStringValue(dr, "Destino"),
                                Estado = DataReader.GetStringValue(dr, "NOM_ESTADO"),
                                FechaDoc = DataReader.GetDateTimeValue(dr, "FechaDoc").Value.ToShortDateString(),
                                FechaViaje = DataReader.GetDateTimeValue(dr, "FechaViaje").Value.ToShortDateString(),
                                HoraDoc = DataReader.GetStringValue(dr, "HoraDoc"),
                                HoraViaje = DataReader.GetStringValue(dr, "HoraViahe"),
                                Origen = DataReader.GetStringValue(dr, "Origen"),
                                Unidad = DataReader.GetStringValue(dr, "Placa"),
                                IdUnidad = DataReader.GetStringValue(dr, "IdUnidad"),
                                IdSolicitudRevision = DataReader.GetStringValue(dr, "IdSolicitudRevision")
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

        public static List<SolicitudRevisionBusquedaList> ListSolicitudRevisionAdmin()
        {
            List<SolicitudRevisionBusquedaList> List = new List<SolicitudRevisionBusquedaList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("LIS_SolicitudRevision_Admin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new SolicitudRevisionBusquedaList
                            {
                                Chofer = DataReader.GetStringValue(dr, "Chofer"),
                                correlativo = DataReader.GetStringValue(dr, "correlativo"),
                                Destino = DataReader.GetStringValue(dr, "Destino"),
                                Placa = DataReader.GetStringValue(dr, "Placa"),
                                Fecha = DataReader.GetStringValue(dr, "Fecha"),
                                Hora = DataReader.GetStringValue(dr, "Hora"),
                                Origen = DataReader.GetStringValue(dr, "Origen"),
                                Usuario = DataReader.GetStringValue(dr, "Usuario"),
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

        public static List<SolicitudRevisionBusquedaList> ListSolicitudRevisionUsuario(string sucursal)
        {
            List<SolicitudRevisionBusquedaList> List = new List<SolicitudRevisionBusquedaList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("LIS_SolicitudRevision_Usr", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Sucursal", SqlDbType.VarChar).Value = sucursal;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new SolicitudRevisionBusquedaList
                            {
                                Chofer = DataReader.GetStringValue(dr, "Chofer"),
                                correlativo = DataReader.GetStringValue(dr, "correlativo"),
                                Destino = DataReader.GetStringValue(dr, "Destino"),
                                Placa = DataReader.GetStringValue(dr, "Placa"),
                                Fecha = DataReader.GetStringValue(dr, "Fecha"),
                                Hora = DataReader.GetStringValue(dr, "Hora"),
                                Origen = DataReader.GetStringValue(dr, "Origen"),
                                Usuario = DataReader.GetStringValue(dr, "Usuario"),
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

        public static async Task<MTBFEntity> UpdateSolicitudRevisionTecnica_C_CorrelativoInterno(string IdSolicitudRevision,string CorrelativoInterno)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UPD_tb_SolicitudRevisionTecnica_C_CorrelativoInterno", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pCorrelativoInterno", SqlDbType.VarChar).Value = CorrelativoInterno;
                        cmd.Parameters.Add("@pIdSolicitudRevision", SqlDbType.VarChar).Value = IdSolicitudRevision;
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

        public static string ObtenerUltimaRevisionChofer(string ben_codigo)
        {
            string ultimoId = "";
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("SEL_maxsolxChofer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Ben_Codigo", SqlDbType.VarChar).Value = ben_codigo;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ultimoId = Convert.ToString(dr[0]);
                            return ultimoId;
                        }

                        dr.Close();
                    }

                    cmd.Dispose();
                }

                if (con.State == ConnectionState.Open) { con.Close(); }
            }

            return ultimoId;
        }

        public static async Task<MTBFEntity> AnularSolicitudRevisionTecnica_C(string IdSolicitudRevision)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_tb_SolicitudRevisionTecnica_C_Anular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pIdSolicitudRevision", SqlDbType.VarChar).Value = IdSolicitudRevision;
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
