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
    public class TareaMecanicosAyudanteData
    {
        public static List<TareaMecanicosAyudanteList> ListTareaMecanicosAyudante(int IdTareaMecanicos, string CodMecanico = "")
        {
            List<TareaMecanicosAyudanteList> List = new List<TareaMecanicosAyudanteList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_tb_tareamecanicos_ayudante_List", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pIdTareaMecanicos", SqlDbType.Int).Value = IdTareaMecanicos;
                    cmd.Parameters.Add("@pcodmecanico", SqlDbType.VarChar).Value = CodMecanico;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new TareaMecanicosAyudanteList
                            {
                                IdAyudante = DataReader.GetIntValue(dr, "IdAyudante"),
                                IdTareaMecanicos = DataReader.GetIntValue(dr, "IdTareaMecanicos"),
                                CodMecanico = DataReader.GetStringValue(dr, "CodMecanico"),
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

        public static async Task<int> InsertTareaMecanicosAyudante(TareaMecanicosAyudanteEntity objEntidad)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_tb_tareamecanicos_ayudante_insert", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pidtareamecanicos", SqlDbType.Int).Value = objEntidad.IdTareaMecanicos;
                        cmd.Parameters.Add("@pcodmecanico", SqlDbType.VarChar).Value = objEntidad.CodMecanico;
                        cmd.Parameters.Add("@pobservacion", SqlDbType.VarChar).Value = objEntidad.Observacion;
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

        public static async Task<int> DeleteTareaMecanicosAyudante(int IdAyudante)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_tb_tareamecanicos_ayudante_delete", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pidayudante", SqlDbType.Int).Value = IdAyudante;
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
