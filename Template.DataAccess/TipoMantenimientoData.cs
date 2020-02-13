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
                                UnidadId = DataReader.GetStringValue(dr, "UnidadId")
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
