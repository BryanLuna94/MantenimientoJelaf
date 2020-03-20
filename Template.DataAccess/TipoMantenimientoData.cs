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
    public class TipoMantenimientoData
    {
        public static List<TareasPendientesList> ListTareasPendientes(string are_codigo)
        {
            List<TareasPendientesList> List = new List<TareasPendientesList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_List_Preventivos_Pendientes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Are_Codigo", SqlDbType.VarChar).Value = (are_codigo != null) ? are_codigo : string.Empty;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new TareasPendientesList
                            {
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),
                                DescripcionTarea = DataReader.GetStringValue(dr, "DescripcionTarea"),
                                fechainforme = DataReader.GetDateTimeValue(dr, "fechainforme").Value,
                                IdTarea = DataReader.GetSmallIntValue(dr, "IdTarea"),
                                idtipman = DataReader.GetSmallIntValue(dr, "idtipman"),
                                KmtActual = DataReader.GetDecimalValue(dr, "KmtActual"),
                                KmtAviso = DataReader.GetDecimalValue(dr, "KmtAviso"),
                                NroInforme = DataReader.GetIntValue(dr, "NroInforme"),
                                UnidadId = DataReader.GetStringValue(dr, "UnidadId"),
                                // 20200218 - INICIO
                                Horas = DataReader.GetIntValue(dr, "Horas"),
                                HorasRecorrido = DataReader.GetIntValue(dr, "HorasRecorrido"),
                                Dias = DataReader.GetIntValue(dr, "Dias"),
                                DiasRecorrido = DataReader.GetIntValue(dr, "DiasRecorrido"),
                                // 20200218 - FIN
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

        public static List<AreEntity> ListAreBus(string are_codigo,string codigo_programacion_real)
        {
            List<AreEntity> List = new List<AreEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("proc_ObtenerEncabezadoPreventivo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Are_Codigo", SqlDbType.VarChar).Value = (are_codigo != null) ? are_codigo : string.Empty;
                    cmd.Parameters.Add("@Codigo_Programacion_Real", SqlDbType.VarChar).Value = (codigo_programacion_real != null) ? codigo_programacion_real : string.Empty;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new AreEntity
                            {
                                Are_Codigo = DataReader.GetStringValue(dr, "Are_Codigo"),
                                Are_Nombre = DataReader.GetStringValue(dr, "Are_Nombre"),
                                Ben_Nombre = DataReader.GetStringValue(dr, "Ben_Nombre"),
                                tbg_Descripcion = DataReader.GetStringValue(dr, "tbg_Descripcion"),

                                Modelo = DataReader.GetStringValue(dr, "Modelo"),
                                Kilometraje = DataReader.GetDecimalValue(dr, "Kilometraje"),
                                FechaViaje = DataReader.GetDateTimeValue(dr, "FechaViaje").Value.ToString("dd/MM/yyyy"),
                                OrdenTrabajo = DataReader.GetIntValue(dr, "OrdenTrabajo"),
                                Marca = DataReader.GetStringValue(dr, "Marca"),
                                Ubicacion = DataReader.GetStringValue(dr, "Ubicacion"),
                                CODI_PROGRAMACION_REAL = DataReader.GetStringValue(dr, "CODI_PROGRAMACION_REAL"),
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
    }
}
