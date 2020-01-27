using System;

using System.Data;
using System.Data.SqlClient;

using System.Threading.Tasks;
using Mantenimiento.DataAccess.Connection;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Utility;

namespace Mantenimiento.DataAccess
{
    public static class LoginData
    {
        public static async Task<UsuarioEntity> Login(string CodiUsuario)
        {
            using (var con = GetConnection.BDALMACEN())
            {
                bool openConn = (con.State == ConnectionState.Open);
                if (!openConn) { con.Open(); }

                using (var cmd = new SqlCommand("usp_GEN_TabUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Codi_Usuario", SqlDbType.SmallInt).Value = CodiUsuario;

                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (dr.Read())
                        {
                            return new UsuarioEntity
                            {
                                Codigo = DataReader.GetShortValue(dr, "Codi_Usuario"),
                                Nombre = DataReader.GetStringValue(dr, "Nombre"),
                                Password = DataReader.GetStringValue(dr, "Pws"),
                                Codi_Empresa = DataReader.GetShortValue(dr, "Codi_Empresa"),
                                Nivel = DataReader.GetShortValue(dr, "Nivel"),
                                Sucursal = DataReader.GetShortValue(dr, "Sucursal"),
                                Terminal = DataReader.GetStringValue(dr, "Terminal"),
                                Ben_Codigo = DataReader.GetStringValue(dr, "Ben_Codigo"),
                                Ben_Nombre = DataReader.GetStringValue(dr, "Ben_Nombre"),
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

        public static async Task<UsuarioEntity> Actualizapwd(string codiUsuario, string Password)
        {
           

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_ACT_TabUsuario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Codi_Usuario", SqlDbType.SmallInt).Value = codiUsuario;
                        cmd.Parameters.Add("@Usr_Password", SqlDbType.Text).Value = Password;

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
 
    }
}
