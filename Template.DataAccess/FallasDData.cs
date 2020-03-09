using System;

using System.Data;
using System.Data.SqlClient;

using System.Threading.Tasks;
using Mantenimiento.DataAccess.Connection;
using Mantenimiento.Entities.Objects.Entities;
using System.Collections.Generic;
using Mantenimiento.Utility;

namespace Mantenimiento.DataAccess
{
    public static class FallasDData
    {

        public static List<FallasDEntity> IdFallasD()
        {
            List<FallasDEntity> List = new List<FallasDEntity>();
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("Usp_tb_SolicitudRevisionTecnica_DId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new FallasDEntity
                            {
                                IdSolicitudRevisionD = DataReader.GetStringValue(dr, "IdSolicitudRevisionD"),

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


        public static List<FallasDEntity> SelectFallasD(string ID)
        {
            List<FallasDEntity> List = new List<FallasDEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("Usp_tb_SolicitudRevisionTecnica_DSelect", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Text).Value = ID;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new FallasDEntity
                            {
                                IdSolicitudRevisionD = DataReader.GetStringValue(dr, "IdSolicitudRevisionD"),
                                IdSolicitudRevision = DataReader.GetStringValue(dr, "IdSolicitudRevision"),
                                Observacion = DataReader.GetStringValue(dr, "Observacion"),
                                UsuarioRegistro = DataReader.GetStringValue(dr, "UsuarioRegistro"),
                                Fecharegistro = DataReader.GetStringValue(dr, "Fecharegistro"),
                                HoraRegistro = DataReader.GetStringValue(dr, "HoraRegistro"),
                                Estado = DataReader.GetIntValue(dr, "Estado"),
                                IdSistema = DataReader.GetIntValue(dr, "IdSistema"),
                                IdObservacion = DataReader.GetIntValue(dr, "IdObservacion"),

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

        public static List<FallasDEntity> SelectFallasPorInforme(decimal IdInforme)
        {
            List<FallasDEntity> List = new List<FallasDEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("Usp_tb_SolicitudRevisionTecnica_DSelect_Por_Informe", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdInforme", SqlDbType.Decimal).Value = IdInforme;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new FallasDEntity
                            {
                                IdSolicitudRevisionD = DataReader.GetStringValue(dr, "IdSolicitudRevisionD"),
                                IdSolicitudRevision = DataReader.GetStringValue(dr, "IdSolicitudRevision"),
                                Observacion = DataReader.GetStringValue(dr, "Observacion"),
                                UsuarioRegistro = DataReader.GetStringValue(dr, "UsuarioRegistro"),
                                Fecharegistro = DataReader.GetStringValue(dr, "Fecharegistro"),
                                HoraRegistro = DataReader.GetStringValue(dr, "HoraRegistro"),
                                Estado = DataReader.GetIntValue(dr, "Estado"),
                                IdSistema = DataReader.GetIntValue(dr, "IdSistema"),
                                IdObservacion = DataReader.GetIntValue(dr, "IdObservacion"),

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

        public static async Task<FallasDEntity> InsertFallasD(string IdSolicitudRevisionD, string IdSolicitudRevision, string Observacion,
            string UsuarioRegistro, string FechaRegistro, string HoraRegistro, int Estado, int IdSistema, int IdObservacion)
        {
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }
                    using (SqlCommand cmd = new SqlCommand("Usp_tb_SolicitudRevisionTecnica_DInsert2", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdSolicitudRevisionD ", SqlDbType.Text).Value = IdSolicitudRevisionD;
                        cmd.Parameters.Add("@IdSolicitudRevision", SqlDbType.Text).Value = IdSolicitudRevision;
                        cmd.Parameters.Add("@Observacion", SqlDbType.Text).Value = Observacion;
                        cmd.Parameters.Add("@UsuarioRegistro", SqlDbType.Text).Value = UsuarioRegistro;
                        cmd.Parameters.Add("@FechaRegistro", SqlDbType.Text).Value = FechaRegistro;
                        cmd.Parameters.Add("@HoraRegistro", SqlDbType.Text).Value = HoraRegistro;
                        cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = Estado;
                        cmd.Parameters.Add("@IdSistema", SqlDbType.Int).Value = IdSistema;
                        cmd.Parameters.Add("@IdObservacion", SqlDbType.Int).Value = IdObservacion;
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

 

        public static async Task<FallasDEntity> DeleteFallasD(string ID)
        {
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("Usp_tb_SolicitudRevisionTecnica_DDelete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.Text).Value = ID;

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
