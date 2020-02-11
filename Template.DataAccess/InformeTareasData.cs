﻿using System;

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
    public class InformeTareasData
    {
        public static List<InformeTareasList> ListInformeTareas(int IdInforme, int IdTarea = 0, int IdEstado = 1)
        {
            List<InformeTareasList> List = new List<InformeTareasList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("Usp_Tb_InformeTareas_Consultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdInforme", SqlDbType.Int).Value = IdInforme;
                    cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = IdTarea;
                    cmd.Parameters.Add("@estado", SqlDbType.Int).Value = IdEstado;
                    cmd.Parameters.Add("@Are_Codigo", SqlDbType.VarChar).Value = "";
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new InformeTareasList
                            {
                                FechaInicio = DataReader.GetDateTimeValue(dr, "FECINICIO").Value.ToShortDateString(),
                                IdTarea = DataReader.GetIntValue(dr, "IdTarea"),
                                IdTipMan = DataReader.GetIntValue(dr, "IdTipMan"),
                                Mantenimiento = DataReader.GetStringValue(dr, "Mante"),
                                Observacion = DataReader.GetStringValue(dr, "Observacion"),
                                Tarea = DataReader.GetStringValue(dr, "Tareas"),
                                Estado = DataReader.GetIntValue(dr, "Estado")
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

        public static async Task<int> InsertInformeTareas(InformeTareasEntity objEntidad)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("Usp_Tb_InformeTareas_Insert", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdInforme", SqlDbType.Int).Value = objEntidad.IdInforme;
                        cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = objEntidad.IdTarea;
                        cmd.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = objEntidad.Observacion;
                        cmd.Parameters.Add("@ServTerceros_Codigo", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@ServTerceros_TbgDocumento", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@UsuarioRegistro", SqlDbType.Int).Value = objEntidad.UsuarioRegistro;
                        cmd.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.FechaInicio);
                        cmd.Parameters.Add("@IdPlanEjecucionTareas", SqlDbType.VarChar).Value = "";
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

        public static async Task<int> UpdateInformeTareas(InformeTareasEntity objEntidad)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("Usp_Tb_InformeTareas_Update", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdInforme", SqlDbType.Int).Value = objEntidad.IdInforme;
                        cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = objEntidad.IdTarea;
                        cmd.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = objEntidad.Observacion;
                        cmd.Parameters.Add("@ServTerceros_Codigo", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@pKmt_recorrido", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@UsuarioRegistro", SqlDbType.Int).Value = objEntidad.UsuarioRegistro;
                        cmd.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.FechaInicio);
                        cmd.Parameters.Add("@IdPlanEjecucionTareas", SqlDbType.VarChar).Value = "";
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

        public static async Task<int> DeleteInformeTareas(int IdInforme, int IdTarea, int Estado = 0, string Observacion = "")
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("Usp_Tb_InformeTareas_Delete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdInforme", SqlDbType.Int).Value = IdInforme;
                        cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = IdTarea;
                        cmd.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Observacion;
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