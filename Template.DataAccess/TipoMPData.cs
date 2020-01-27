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
    public static class TipoMPData
    {

        public static List<TipoMPEntity> IdTipoMP()
        {
            List<TipoMPEntity> List = new List<TipoMPEntity>();
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_MAX_tb_tipomantenimiento", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new TipoMPEntity
                            {
                                IdTipMan = DataReader.GetIntValue(dr, "IdTipMan"),

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
        public static List<TipoMPEntity> ListTipoMP()
        {
            List<TipoMPEntity> List = new List<TipoMPEntity>();
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_LIS_tb_tipomantenimiento", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new TipoMPEntity
                            {
                                IdTipMan = DataReader.GetIntValue(dr, "IdTipMan"),
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),
                                Kilometros = DataReader.GetDecimalValue(dr, "Kilometros"),
                                KilometrosAviso = DataReader.GetDecimalValue(dr, "KilometrosAviso"),
                                UsuarioRegistro = DataReader.GetIntValue(dr, "IdTipMan"),
                                FechaRegistro = DataReader.GetStringValue(dr, "FechaRegistro"),
                                Cod_Marca = DataReader.GetStringValue(dr, "Cod_Marca"),
                                Cod_Modelo = DataReader.GetIntValue(dr, "Cod_Modelo"),
                                Estado = DataReader.GetBooleanValue(dr, "Estado"),
                                FlgMov = DataReader.GetStringValue(dr, "FlgMov"),
                                Dias = DataReader.GetIntValue(dr, "Dias"),
                                DiasAviso = DataReader.GetIntValue(dr, "DiasAviso"),
                                Horas = DataReader.GetIntValue(dr, "Horas"),
                                HorasAviso = DataReader.GetIntValue(dr, "HorasAviso"),

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


        public static List<TipoMPEntity> SelectTipoMP(short IdTipMan)
        {
            List<TipoMPEntity> List = new List<TipoMPEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_SEL_tb_tipomantenimiento", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdTipMan", SqlDbType.Int).Value = IdTipMan;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new TipoMPEntity
                            {
                                IdTipMan = DataReader.GetIntValue(dr, "IdTipMan"),
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),
                                Kilometros = DataReader.GetDecimalValue(dr, "Kilometros"),
                                KilometrosAviso = DataReader.GetDecimalValue(dr, "KilometrosAviso"),
                                UsuarioRegistro = DataReader.GetIntValue(dr, "IdTipMan"),
                                FechaRegistro = DataReader.GetStringValue(dr, "FechaRegistro"),
                                Cod_Marca = DataReader.GetStringValue(dr, "Cod_Marca"),
                                Cod_Modelo = DataReader.GetIntValue(dr, "Cod_Modelo"),
                                Estado = DataReader.GetBooleanValue(dr, "Estado"),
                                FlgMov = DataReader.GetStringValue(dr, "FlgMov"),
                                Dias = DataReader.GetIntValue(dr, "Dias"),
                                DiasAviso = DataReader.GetIntValue(dr, "DiasAviso"),
                                Horas = DataReader.GetIntValue(dr, "Horas"),
                                HorasAviso = DataReader.GetIntValue(dr, "HorasAviso"),

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


        public static async Task<TipoMPEntity> InsertTipoMP(short IdTipMan, string Descripcion, decimal Kilometros, decimal KilometrosAviso,
            short UsuarioRegistro, DateTime FechaRegistro, short Dias, short DiasAviso, short Horas, short HorasAviso, string cod_marca, int cod_modelo)
        {


            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_INS_tb_tipomantenimiento", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdTipMan", SqlDbType.Int).Value = IdTipMan;
                        cmd.Parameters.Add("@Descripcion", SqlDbType.Text).Value = Descripcion;
                        cmd.Parameters.Add("@Kilometros", SqlDbType.Decimal).Value = Kilometros;
                        cmd.Parameters.Add("@KilometrosAviso", SqlDbType.Decimal).Value = KilometrosAviso;
                        cmd.Parameters.Add("@UsuarioRegistro", SqlDbType.SmallInt).Value = UsuarioRegistro;
                        cmd.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro;
                        cmd.Parameters.Add("@Dias", SqlDbType.Int).Value = Dias;
                        cmd.Parameters.Add("@DiasAviso", SqlDbType.Int).Value = DiasAviso;
                        cmd.Parameters.Add("@Horas", SqlDbType.Int).Value = Horas;
                        cmd.Parameters.Add("@HorasAviso", SqlDbType.Int).Value = HorasAviso;
                        cmd.Parameters.Add("@Cod_Marca", SqlDbType.VarChar).Value = cod_marca;
                        cmd.Parameters.Add("@cod_Modelo", SqlDbType.Int).Value = cod_modelo;
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

        public static async Task<TipoMPEntity> UpdateTipoMP(short IdTipMan, string Descripcion, decimal Kilometros, decimal KilometrosAviso, short Dias,
            short DiasAviso, short Horas, short HorasAviso)
        {


            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UPD_tb_tipomantenimiento", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdTipMan", SqlDbType.Int).Value = IdTipMan;
                        cmd.Parameters.Add("@Descripcion", SqlDbType.Text).Value = Descripcion;
                        cmd.Parameters.Add("@Kilometros", SqlDbType.Decimal).Value = Kilometros;
                        cmd.Parameters.Add("@KilometrosAviso", SqlDbType.Decimal).Value = KilometrosAviso;
                        cmd.Parameters.Add("@Dias", SqlDbType.Int).Value = Dias;
                        cmd.Parameters.Add("@DiasAviso", SqlDbType.Int).Value = DiasAviso;
                        cmd.Parameters.Add("@Horas", SqlDbType.Int).Value = Horas;
                        cmd.Parameters.Add("@HorasAviso", SqlDbType.Int).Value = HorasAviso;
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

        public static async Task<TipoMPEntity> DeleteTipoMP(short IdTipMan)
        {
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_DEL_tb_tipomantenimiento", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdTipMan", SqlDbType.Int).Value = IdTipMan;

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
