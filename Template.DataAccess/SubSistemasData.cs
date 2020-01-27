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
    public static class SubSistemasData
    {

        public static List<SubSistemasEntity> IdSubSistemas(Int16 ID_tb_Sistema_Mant)
        {
            List<SubSistemasEntity> List = new List<SubSistemasEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_MAX_tb_SubSistema_Mant", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID_tb_Sistema_Mant", SqlDbType.Int).Value = ID_tb_Sistema_Mant;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new SubSistemasEntity
                            {
                                ID_tb_SubSistema_Mant = DataReader.GetStringValue(dr, "ID_tb_SubSistema_Mant"),

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

        public static List<SubSistemasEntity> ListSubSistemas()
        {
            List<SubSistemasEntity> List = new List<SubSistemasEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_LIS_tb_SubSistema_Mant", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new SubSistemasEntity
                            {
                                ID_tb_SubSistema_Mant = DataReader.GetStringValue(dr, "ID_tb_SubSistema_Mant"),
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
        public static List<SubSistemasEntity> SelectSubSistemas(String ID_tb_SubSistema_Mant)
        {
            List<SubSistemasEntity> List = new List<SubSistemasEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_SEL_tb_SubSistema_Mant", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID_tb_SubSistema_Mant", SqlDbType.Text).Value = ID_tb_SubSistema_Mant;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new SubSistemasEntity
                            {
                                ID_tb_SubSistema_Mant = DataReader.GetStringValue(dr, "ID_tb_SubSistema_Mant"),
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
 

        public static async Task<SubSistemasEntity> InsertSubSistemas(String ID_tb_SubSistema_Mant, Int16 ID_tb_Sistema_Mant, String Descripcion)
        {
           

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_INS_tb_SubSistema_Mant", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID_tb_SubSistema_Mant", SqlDbType.Text).Value = ID_tb_SubSistema_Mant;
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

        public static async Task<SubSistemasEntity> UpdateSubSistemas(String ID_tb_SubSistema_Mant, Int16 ID_tb_Sistema_Mant, String Descripcion)
        {


            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UPD_tb_SubSistema_Mant", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID_tb_SubSistema_Mant", SqlDbType.Text).Value = ID_tb_SubSistema_Mant;
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

        public static async Task<SubSistemasEntity> DeleteSubSistemas(String ID_tb_SubSistema_Mant)
        {


            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_DEL_tb_SubSistema_Mant", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID_tb_SubSistema_Mant", SqlDbType.Text).Value = ID_tb_SubSistema_Mant;

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
