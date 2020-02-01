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
    public class TareaMecanicoData
    {
        public static List<TareaMecanicoList> ListTareaMecanico(int IdInforme, int IdTarea, string IdMecanico = "")
        {
            List<TareaMecanicoList> List = new List<TareaMecanicoList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("Usp_Tb_InformeMecanico_Consultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = IdInforme;
                    cmd.Parameters.Add("@idtarea", SqlDbType.Int).Value = IdTarea;
                    cmd.Parameters.Add("@idmeca", SqlDbType.VarChar).Value = IdMecanico;
                    cmd.Parameters.Add("@estado", SqlDbType.Int).Value = 99;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new TareaMecanicoList
                            {
                                CodMecanico = DataReader.GetStringValue(dr, "CodMecanico"),
                                FechaInicio= DataReader.GetDateTimeValue(dr, "FechaInicio").Value.ToShortDateString(),
                                FechaTermino = DataReader.GetDateTimeValue(dr, "FechaTermino").Value.ToShortDateString(),
                                HoraInicio = DataReader.GetStringValue(dr, "HoraInicio"),
                                HoraTermino = DataReader.GetStringValue(dr, "HoraTermino"),
                                IdTareaMecanicos = DataReader.GetIntValue(dr, "IdTareaMecanicos"),
                                Mecanico = DataReader.GetStringValue(dr, "Mecanico"),
                                Observacion = DataReader.GetStringValue(dr, "Observacion")
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

        public static async Task<int> InsertTareaMecanico(TareaMecanicosEntity objEntidad)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("Usp_Tb_Tareamecanicos_Insert", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdInforme", SqlDbType.Int).Value = objEntidad.IdInforme;
                        cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = objEntidad.IdTarea;
                        cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.FechaInicio);
                        cmd.Parameters.Add("@HoraInicio", SqlDbType.VarChar).Value = objEntidad.HoraInicio;
                        cmd.Parameters.Add("@FechaTermino", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.FechaTermino);
                        cmd.Parameters.Add("@HoraTermino", SqlDbType.VarChar).Value = objEntidad.HoraTermino;
                        cmd.Parameters.Add("@CodMecanico", SqlDbType.VarChar).Value = objEntidad.CodMecanico;
                        cmd.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = objEntidad.Observacion;
                        cmd.Parameters.Add("@UsuarioRegistro", SqlDbType.Int).Value = objEntidad.UsuarioRegistro;
                        cmd.Parameters.Add("@CostoInterno", SqlDbType.Decimal).Value = 0;
                        cmd.Parameters.Add("@CostoExterno", SqlDbType.Decimal).Value = 0;
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

        public static async Task<int> UpdateTareaMecanico(TareaMecanicosEntity objEntidad)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("Usp_Tb_Tareamecanicos_Update", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdInforme", SqlDbType.Int).Value = objEntidad.IdInforme;
                        cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = objEntidad.IdTarea;
                        cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.FechaInicio);
                        cmd.Parameters.Add("@HoraInicio", SqlDbType.VarChar).Value = objEntidad.HoraInicio;
                        cmd.Parameters.Add("@FechaTermino", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.FechaTermino);
                        cmd.Parameters.Add("@HoraTermino", SqlDbType.VarChar).Value = objEntidad.HoraTermino;
                        cmd.Parameters.Add("@CodMecanico", SqlDbType.VarChar).Value = objEntidad.CodMecanico;
                        cmd.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = objEntidad.Observacion;
                        cmd.Parameters.Add("@UsuarioRegistro", SqlDbType.Int).Value = objEntidad.UsuarioRegistro;
                        cmd.Parameters.Add("@CostoInterno", SqlDbType.Decimal).Value = 0;
                        cmd.Parameters.Add("@CostoExterno", SqlDbType.Decimal).Value = 0;
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

        public static async Task<int> DeleteTareaMecanico(int IdTareaMecanicos, int Estado = 0)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("Usp_Tb_Tareamecanicos_Delete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = IdTareaMecanicos;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = Estado;
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
    }
}
