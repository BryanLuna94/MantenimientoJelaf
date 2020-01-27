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
    public static class TareaMPData
    {

        public static List<TareaMPEntity> IdTareaMP()
        {
            List<TareaMPEntity> List = new List<TareaMPEntity>();
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_MAX_Tb_Tareas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new TareaMPEntity
                            {
                                IdTarea = DataReader.GetIntValue(dr, "IdTarea"),

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
        public static List<TareaMPEntity> ListTareaMP(short IdTipMan)
        {
            List<TareaMPEntity> List = new List<TareaMPEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_LIS_Tb_Tareas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdTipMan", SqlDbType.Int).Value = IdTipMan;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new TareaMPEntity
                            {
                                IdTarea = DataReader.GetIntValue(dr, "IdTarea"),
                                IdTipMan = DataReader.GetIntValue(dr, "IdTipMan"),
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),
                                UsuarioRegistro = DataReader.GetIntValue(dr, "UsuarioRegistro"),
                                FechaRegistro = DataReader.GetStringValue(dr, "FechaRegistro"),
                                Flg_Revision = DataReader.GetIntValue(dr, "Flg_Revision"),
                                MinutosLabor = DataReader.GetIntValue(dr, "MinutosLabor"),
                                CostoTopeExterno = DataReader.GetDecimalValue(dr, "CostoTopeExterno"),
                                CostoInternoPorMin = DataReader.GetDecimalValue(dr, "CostoInternoPorMin"),
                                ID_tb_Sistema_Mant = DataReader.GetIntValue(dr, "ID_tb_Sistema_Mant"),
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


        public static List<TareaMPEntity> SelectTareaMP(short IdTarea)
        {
            List<TareaMPEntity> List = new List<TareaMPEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_SEL_Tb_Tareas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = IdTarea;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new TareaMPEntity
                            {
                                IdTarea = DataReader.GetIntValue(dr, "IdTarea"),
                                IdTipMan = DataReader.GetIntValue(dr, "IdTipMan"),
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),
                                UsuarioRegistro = DataReader.GetIntValue(dr, "UsuarioRegistro"),
                                FechaRegistro = DataReader.GetStringValue(dr, "FechaRegistro"),
                                Flg_Revision = DataReader.GetIntValue(dr, "Flg_Revision"),
                                MinutosLabor = DataReader.GetIntValue(dr, "MinutosLabor"),
                                CostoTopeExterno = DataReader.GetDecimalValue(dr, "CostoTopeExterno"),
                                CostoInternoPorMin = DataReader.GetDecimalValue(dr, "CostoInternoPorMin"),
                                ID_tb_Sistema_Mant = DataReader.GetIntValue(dr, "ID_tb_Sistema_Mant"),
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


        public static async Task<TareaMPEntity> InsertTareaMP(short IdTarea, short IdTipMan, string Descripcion, short UsuarioRegistro,DateTime FechaRegistro,int Flg_Revision,int ID_tb_Sistema_Mant,string ID_tb_SubSistema_Mant)
        {
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }
                    using (SqlCommand cmd = new SqlCommand("usp_INS_Tb_Tareas", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = IdTarea;
                        cmd.Parameters.Add("@IdTipMan", SqlDbType.Int).Value = IdTipMan;
                        cmd.Parameters.Add("@Descripcion", SqlDbType.Text).Value = Descripcion;
                        cmd.Parameters.Add("@UsuarioRegistro", SqlDbType.SmallInt).Value = UsuarioRegistro;
                        cmd.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro;
                        cmd.Parameters.Add("@Flg_Revision", SqlDbType.Int).Value = Flg_Revision;
                        cmd.Parameters.Add("@ID_tb_Sistema_Mant", SqlDbType.Int).Value = ID_tb_Sistema_Mant;
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

        public static async Task<TareaMPEntity> UpdateTareaMP(short IdTarea, short IdTipMan, string Descripcion, int Flg_Revision, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant)
        {


            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UPD_Tb_Tareas", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = IdTarea;
                        cmd.Parameters.Add("@IdTipMan", SqlDbType.Int).Value = IdTipMan;
                        cmd.Parameters.Add("@Descripcion", SqlDbType.Text).Value = Descripcion;
                        cmd.Parameters.Add("@Flg_Revision", SqlDbType.Int).Value = Flg_Revision;
                        cmd.Parameters.Add("@ID_tb_Sistema_Mant", SqlDbType.Int).Value = ID_tb_Sistema_Mant;
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

        public static async Task<TareaMPEntity> DeleteTareaMP(short IdTarea)
        {
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_DEL_Tb_Tareas", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdTarea", SqlDbType.Int).Value = IdTarea;

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
