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
    public static class ArticuloTData
    {

        public static List<ArticuloTEntity> IdArticuloT()
        {
            List<ArticuloTEntity> List = new List<ArticuloTEntity>();
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_MAX_tb_ArticuloTareas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new ArticuloTEntity
                            {
                                IdArtTar = DataReader.GetIntValue(dr, "IdArtTar"),

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
        public static List<ArticuloTEntity> ListArticuloT(short IdTarea)
        {
            List<ArticuloTEntity> List = new List<ArticuloTEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_LIS_tb_ArticuloTareas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = IdTarea;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new ArticuloTEntity
                            {
                                IdArtTar = DataReader.GetIntValue(dr, "IdArtTar"),
                                IdTarea = DataReader.GetIntValue(dr, "IdTarea"),
                                Cod_Mer = DataReader.GetIntValue(dr, "Cod_Mer"),
                                CodigoOriginal = DataReader.GetStringValue(dr, "CodigoOriginal"),
                                Cantidad = DataReader.GetIntValue(dr, "Cantidad"),
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),
                                Orden = DataReader.GetIntValue(dr, "Orden"),


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


        public static List<ArticuloTEntity> SelectArticuloT(short IdArtTar)
        {
            List<ArticuloTEntity> List = new List<ArticuloTEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_SEL_tb_ArticuloTareas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdArtTar", SqlDbType.Int).Value = IdArtTar;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new ArticuloTEntity
                            {
                                IdArtTar = DataReader.GetIntValue(dr, "IdArtTar"),
                                IdTarea = DataReader.GetIntValue(dr, "IdTarea"),
                                Cod_Mer = DataReader.GetIntValue(dr, "Cod_Mer"),
                                CodigoOriginal = DataReader.GetStringValue(dr, "CodigoOriginal"),
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),
                                Orden = DataReader.GetIntValue(dr, "Orden"),
                                Cantidad = DataReader.GetIntValue(dr, "Cantidad")
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


        public static async Task<ArticuloTEntity> InsertArticuloT(short IdArtTar, short IdTarea, short Cod_Mer, short Cantidad, short Orden)
        {
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }
                    using (SqlCommand cmd = new SqlCommand("usp_INS_tb_ArticuloTareas", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdArtTar", SqlDbType.Int).Value = IdArtTar;
                        cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = IdTarea;
                        cmd.Parameters.Add("@Cod_Mer", SqlDbType.Int).Value = Cod_Mer;
                        cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;
                        cmd.Parameters.Add("@Orden", SqlDbType.Int).Value = Orden;
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

        public static async Task<ArticuloTEntity> UpdateArticuloT(short IdArtTar, short IdTarea, short Cod_Mer, short Cantidad, short Orden)
        {


            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UPD_tb_ArticuloTareas", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdArtTar", SqlDbType.Int).Value = IdArtTar;
                        cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = IdTarea;
                        cmd.Parameters.Add("@Cod_Mer", SqlDbType.Int).Value = Cod_Mer;
                        cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;
                        cmd.Parameters.Add("@Orden", SqlDbType.Int).Value = Orden;
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

        public static async Task<ArticuloTEntity> DeleteArticuloT(short IdArtTar)
        {
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_DEL_tb_ArticuloTareas", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdArtTar", SqlDbType.Int).Value = IdArtTar;

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

        public static List<ArticuloTEntity> ListTraerBolsaRepuestos(int IdTarea)
        {
            List<ArticuloTEntity> List = new List<ArticuloTEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_tb_ArticuloTareas_TraerBolsaRepuestos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pIdTarea", SqlDbType.Int).Value = IdTarea;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new ArticuloTEntity
                            {
                                IdArtTar = DataReader.GetIntValue(dr, "IdArtTar"),
                                IdTarea = DataReader.GetIntValue(dr, "IdTarea"),
                                Cod_Mer = DataReader.GetIntValue(dr, "Cod_Mer"),
                                Cantidad = DataReader.GetIntValue(dr, "Cantidad"),
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
