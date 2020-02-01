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
    public class Tb_CtrlBolsaRepInformeData
    {
        public static List<Tb_CtrlBolsaRepInformeEntity> AgregarBolsa(string IdAlmacen, int IdTarea, int IdInforme)
        {
            List<Tb_CtrlBolsaRepInformeEntity> List = new List<Tb_CtrlBolsaRepInformeEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_Tb_CtrlBolsaRepInforme_AgregarBolsa", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idalmacen", SqlDbType.VarChar).Value = IdAlmacen;
                    cmd.Parameters.Add("@idtarea", SqlDbType.Int).Value = IdTarea;
                    cmd.Parameters.Add("@idinforme", SqlDbType.Int).Value = IdInforme;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new Tb_CtrlBolsaRepInformeEntity
                            {
                                IdArticuloTarea = DataReader.GetIntValue(dr, "idarttar"),
                                FechaInicio = DataReader.GetDateTimeValue(dr, "FechaInicio").Value.ToShortDateString(),
                                Codigo = DataReader.GetStringValue(dr, "Codigo"),
                                Original = DataReader.GetStringValue(dr, "Original"),
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),
                                Cantidad = DataReader.GetDecimalValue(dr, "cantidad"),
                                Consumo = DataReader.GetDecimalValue(dr, "consumo"),
                                Solicitado = 0,
                                Pendiente = 0,
                                Tipo = "BOLSA",
                                CodiAlmacen = ""
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

        public static async Task<int> InsertBolsa(Tb_CtrlBolsaRepInformeEntity objEntidad)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("Usp_Tb_CtrlBolsaRepInformeInsert", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdInforme", SqlDbType.Int).Value = objEntidad.IdInforme;
                        cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = objEntidad.IdTarea;
                        cmd.Parameters.Add("@IdArtTar", SqlDbType.Int).Value = objEntidad.IdArticuloTarea;
                        cmd.Parameters.Add("@Mer_codigo", SqlDbType.VarChar).Value = objEntidad.Codigo;
                        cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = objEntidad.Cantidad;
                        cmd.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = objEntidad.Tipo;

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
