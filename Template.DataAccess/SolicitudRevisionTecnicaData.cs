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

    }
}
