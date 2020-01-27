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
    public class InformeData
    {
        public static int InsertInforme(InformeEntity objEntidad)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("Usp_Tb_Informe_Insert", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Are_Codigo", SqlDbType.VarChar).Value = objEntidad.Are_Codigo;
                        cmd.Parameters.Add("@ChoferEntrega", SqlDbType.VarChar).Value = objEntidad.ChoferEntrega;
                        cmd.Parameters.Add("@KmUnidad", SqlDbType.Decimal).Value = objEntidad.KmUnidad;
                        cmd.Parameters.Add("@Ofi_Codigo", SqlDbType.VarChar).Value = objEntidad.Ofi_Codigo;
                        cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = objEntidad.Fecha;
                        cmd.Parameters.Add("@CostoManoObra", SqlDbType.Real).Value = objEntidad.CostoManoObra;
                        cmd.Parameters.Add("@ServicioTerceros", SqlDbType.Real).Value = objEntidad.ServicioTerceros;
                        cmd.Parameters.Add("@CostoRepuestos", SqlDbType.Real).Value = objEntidad.CostoRepuestos;
                        cmd.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = objEntidad.Observacion;
                        cmd.Parameters.Add("@UsuarioRegistro", SqlDbType.SmallInt).Value = objEntidad.UsuarioRegistro;
                        cmd.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = objEntidad.Tipo;
                        cmd.Parameters.Add("@IdUndAlerta", SqlDbType.Int).Value = objEntidad.IdUndAlerta;
                        cmd.Parameters.Add("@IdPlanEjecucionTarea", SqlDbType.VarChar).Value = objEntidad.IdPlanEjecucionTarea;
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                nuevoId = Convert.ToInt32(dr[0]);
                            }
                            cmd.Dispose();
                            dr.Close();
                        }
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

        public static int ObtenerUltimoId()
        {
            int ultimoId = 1;
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_tb_Informe_ObtenerId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ultimoId = Convert.ToInt32(dr[0]);
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

        public static async Task<MTBFEntity> UpdateInforme_NumInforme(int IdInforme, decimal NumInforme)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UPD_tb_Informe_NumInforme", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pIdInforme", SqlDbType.Int).Value = IdInforme;
                        cmd.Parameters.Add("@pNumInforme", SqlDbType.Decimal).Value = NumInforme;
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

        public static async Task<MTBFEntity> AnularInforme(decimal NumInforme, string Tipo)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_DEL_tb_Informe_Anular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pNumInforme", SqlDbType.Decimal).Value = NumInforme;
                        cmd.Parameters.Add("@pTipo", SqlDbType.Decimal).Value = Tipo;
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
