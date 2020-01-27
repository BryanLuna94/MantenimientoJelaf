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
    public static class SistemasData
    {
        public static async Task<SistemasEntity> ListSistemas(Int16 ID_tb_Sistema_Mant)
        {
            using (var con = GetConnection.BDALMACEN())
            {
                bool openConn = (con.State == ConnectionState.Open);
                if (!openConn) { con.Open(); }

                using (var cmd = new SqlCommand("usp_GEN_tb_Sistema_Mant", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID_tb_Sistema_Mant", SqlDbType.SmallInt).Value = ID_tb_Sistema_Mant;

                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (dr.Read())
                        {
                            return new SistemasEntity
                            {
                                ID_tb_Sistema_Mant = DataReader.GetShortValue(dr, "ID_tb_Sistema_Mant"),
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),

                               
                            };
                        }

                        dr.Close();
                    }

                    cmd.Dispose();
                }

                if (con.State == ConnectionState.Open) { con.Close(); }
            }

            return null;
        }
        public static List<SistemasEntity> SelectSistemas()
        {
            List<SistemasEntity> List = new List<SistemasEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_SEL_tb_Sistema_Mant", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new SistemasEntity
                            {
                                ID_tb_Sistema_Mant = DataReader.GetIntValue(dr, "ID_tb_Sistema_Mant"),
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),

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

        public static List<SistemasEntity> IdSistemas()
        {
            List<SistemasEntity> Max = new List<SistemasEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_MAX_tb_Sistema_Mant", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Max.Add(new SistemasEntity
                            {
                                ID_tb_Sistema_Mant = DataReader.GetIntValue(dr, "ID_tb_Sistema_Mant"),

                            });
                        }

                        dr.Close();
                    }

                    cmd.Dispose();
                }

                if (con.State == ConnectionState.Open) { con.Close(); }
            }

            return Max;
        }

        public static async Task<SistemasEntity> InsertSistemas(Int16 ID_tb_Sistema_Mant,String Descripcion)
        {
           

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_INS_tb_Sistema_Mant", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID_tb_Sistema_Mant", SqlDbType.SmallInt).Value = ID_tb_Sistema_Mant;
                        cmd.Parameters.Add("@Descripcion", SqlDbType.Text).Value = Descripcion;

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

            return null ;
        }

        public static async Task<SistemasEntity> UpdateSistemas(Int16 ID_tb_Sistema_Mant, String Descripcion)
        {



            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UPD_tb_Sistema_Mant", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID_tb_Sistema_Mant", SqlDbType.SmallInt).Value = ID_tb_Sistema_Mant;
                        cmd.Parameters.Add("@Descripcion", SqlDbType.Text).Value = Descripcion;

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

        public static async Task<SistemasEntity> DeleteSistemas(Int16 ID_tb_Sistema_Mant)
        {


            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_DEL_tb_Sistema_Mant", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID_tb_Sistema_Mant", SqlDbType.SmallInt).Value = ID_tb_Sistema_Mant;

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
