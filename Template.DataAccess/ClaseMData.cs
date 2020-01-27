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
    public static class ClaseMData
    {
        public static List<ClaseMEntity> ListClaseM()
        {
            List<ClaseMEntity> List = new List<ClaseMEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_LIS_tb_ClaseMantenimiento", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new ClaseMEntity
                            {
                                IdClaseMantenimiento = DataReader.GetStringValue(dr, "IdClaseMantenimiento"),
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),
                                NroOrden = DataReader.GetIntValue(dr, "NroOrden"),
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
        public static List<ClaseMEntity> ListClaseMP()
        {
            List<ClaseMEntity> List = new List<ClaseMEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_LIS_Clases", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new ClaseMEntity
                            {
                                IdClaseMantenimiento = DataReader.GetStringValue(dr, "IdClaseMantenimiento"),
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

        public static List<ClaseMEntity> SelectClaseM(String IdClaseMantenimiento)
        {
            List<ClaseMEntity> List = new List<ClaseMEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_SEL_tb_ClaseMantenimiento", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdClaseMantenimiento", SqlDbType.Text).Value = IdClaseMantenimiento;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new ClaseMEntity
                            {
                                IdClaseMantenimiento = DataReader.GetStringValue(dr, "IdClaseMantenimiento"),
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),
                                NroOrden = DataReader.GetIntValue(dr, "NroOrden"),

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


        public static async Task<ClaseMEntity> InsertClaseM(String IdClaseMantenimiento, String Descripcion, Int16 NroOrden)
        {


            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_INS_tb_ClaseMantenimiento", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdClaseMantenimiento", SqlDbType.Text).Value = IdClaseMantenimiento;
                        cmd.Parameters.Add("@Descripcion", SqlDbType.Text).Value = Descripcion;
                        cmd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = NroOrden;
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

        public static async Task<ClaseMEntity> UpdateClaseM(String IdClaseMantenimiento, String Descripcion, Int16 NroOrden)
        {


            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UPD_tb_ClaseMantenimiento", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdClaseMantenimiento", SqlDbType.Text).Value = IdClaseMantenimiento;
                        cmd.Parameters.Add("@Descripcion", SqlDbType.Text).Value = Descripcion;
                        cmd.Parameters.Add("@NroOrden", SqlDbType.SmallInt).Value = NroOrden;
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

        public static async Task<ClaseMEntity> DeleteClaseM(String IdClaseMantenimiento)
        {


            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_DEL_tb_ClaseMantenimiento", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdClaseMantenimiento", SqlDbType.Text).Value = IdClaseMantenimiento;

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
