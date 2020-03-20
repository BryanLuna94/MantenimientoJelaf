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

        public static List<InformeOrdenMantenimientoList> ListInformeOrdenMantenimiento(int IdInforme)
        {
            List<InformeOrdenMantenimientoList> List = new List<InformeOrdenMantenimientoList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_Rpt_Informe_Orden_Mantenimiento_web_gen", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdInforme", SqlDbType.Int).Value = IdInforme;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new InformeOrdenMantenimientoList
                            {
                                IdInforme = DataReader.GetIntValue(dr, "IdInforme"),
                                NumeroInforme = DataReader.GetIntValue(dr, "NumeroInforme"),
                                FechaRegistro = DataReader.GetDateTimeValue(dr, "FechaRegistro").Value.ToShortDateString(),
                                Fecha = DataReader.GetDateTimeValue(dr, "Fecha").Value.ToShortDateString(),
                                BusPlaca = DataReader.GetStringValue(dr, "BusPlaca"),
                                Ben_Nombre = DataReader.GetStringValue(dr, "Ben_Nombre"),
                                Ofi_Nombre = DataReader.GetStringValue(dr, "Ofi_Nombre"),
                                KmUnidad = DataReader.GetIntValue(dr, "KmUnidad"),
                                IdTarea = DataReader.GetIntValue(dr, "IdTarea"),
                                Tarea = DataReader.GetStringValue(dr, "Tarea"),
                                Mecanico = DataReader.GetStringValue(dr, "Mecanico"),
                                Observacion = DataReader.GetStringValue(dr, "Observacion"),
                                Estado = DataReader.GetIntValue(dr, "Estado"),
                                Dia = DataReader.GetStringValue(dr, "Dia"),

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

        public static List<InformeTareasList> ListInformeTareasBackLogCorrectivo(string IdUnidad)
        {
            List<InformeTareasList> List = new List<InformeTareasList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("vw_List_tareas_backlog", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Unidad", SqlDbType.VarChar).Value = IdUnidad;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new InformeTareasList
                            {
                                FechaInicio = DataReader.GetDateTimeValue(dr, "fecha").Value.ToShortDateString(),
                                IdTarea = DataReader.GetIntValue(dr, "IdTarea"),
                                IdTipMan = DataReader.GetIntValue(dr, "IdTipMan"),
                                Mantenimiento = DataReader.GetStringValue(dr, "Descripcion"),
                                Observacion = DataReader.GetStringValue(dr, "Observacion"),
                                Tarea = DataReader.GetStringValue(dr, "DescripcionTarea"),
                                Estado = DataReader.GetIntValue(dr, "estado"),
                                Are_Codigo = DataReader.GetStringValue(dr, "Are_Codigo"),
                                IdInforme = DataReader.GetIntValue(dr, "IdInforme")
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

        public static List<InformeTareasList> ListInformeTareasBackLogPreventivo(string IdUnidad)
        {
            List<InformeTareasList> List = new List<InformeTareasList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("vw_List_tareas_backlog_prev", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Unidad", SqlDbType.VarChar).Value = IdUnidad;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new InformeTareasList
                            {
                                FechaInicio = DataReader.GetDateTimeValue(dr, "fecha").Value.ToShortDateString(),
                                IdTarea = DataReader.GetIntValue(dr, "IdTarea"),
                                IdTipMan = DataReader.GetIntValue(dr, "IdTipMan"),
                                Mantenimiento = DataReader.GetStringValue(dr, "Descripcion"),
                                Observacion = DataReader.GetStringValue(dr, "Observacion"),
                                Tarea = DataReader.GetStringValue(dr, "DescripcionTarea"),
                                Estado = DataReader.GetIntValue(dr, "estado"),
                                Are_Codigo = DataReader.GetStringValue(dr, "Are_Codigo"),
                                IdInforme = DataReader.GetIntValue(dr, "IdInforme")
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
                        cmd.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = Functions.Check.Datetime(objEntidad.FechaInicio);
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

        public static async Task<int> UpdateInformeTareasKilometraje(int IdInforme, int IdTarea, decimal Kilometraje)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("Usp_Tb_InformeTareas_Update_Kilometraje", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdInforme", SqlDbType.Int).Value = IdInforme;
                        cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = IdTarea;
                        cmd.Parameters.Add("@Kilometraje", SqlDbType.Decimal).Value = Kilometraje;
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

        public static async Task<int> UpdateInformeTareasEstado(int IdInforme, int IdTarea, byte Estado)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_tb_InformeTareas_CambiarEstado", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pIdInforme", SqlDbType.Int).Value = IdInforme;
                        cmd.Parameters.Add("@pIdTarea", SqlDbType.Int).Value = IdTarea;
                        cmd.Parameters.Add("@pEstado", SqlDbType.TinyInt).Value = Estado;
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

        public static async Task<int> UpdateInformeTareasReasignarInforme(int IdInformeNuevo, int IdInformeAnterior, int IdTarea, byte Estado)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_tb_InformeTareas_ReasignarAInforme", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pIdInformeNuevo", SqlDbType.Int).Value = IdInformeNuevo;
                        cmd.Parameters.Add("@pIdInformeAnterior", SqlDbType.Int).Value = IdInformeAnterior;
                        cmd.Parameters.Add("@pIdTarea", SqlDbType.Int).Value = IdTarea;
                        cmd.Parameters.Add("@pEstado", SqlDbType.TinyInt).Value = Estado;
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


        public static async Task<int> InsertTareasSistemas(string AreCodigo,string IdClaseMantenimiento, string Operacion, string xmlData)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("proc_InsertarTareaSistema", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Are_Codigo", SqlDbType.VarChar).Value = AreCodigo;
                        cmd.Parameters.Add("@IdClaseMantenimiento", SqlDbType.VarChar).Value = IdClaseMantenimiento;
                        cmd.Parameters.Add("@Operacion", SqlDbType.VarChar).Value = Operacion;
                        cmd.Parameters.Add("@XMLData", SqlDbType.Xml).Value = xmlData;
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
