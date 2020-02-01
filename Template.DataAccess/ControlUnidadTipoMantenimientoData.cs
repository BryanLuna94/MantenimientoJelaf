using System;

using System.Data;
using System.Data.SqlClient;

using System.Threading.Tasks;
using Mantenimiento.DataAccess.Connection;
using Mantenimiento.Entities.Objects.Entities;
using System.Collections.Generic;
using Mantenimiento.Utility;
using Mantenimiento.Entities.Objects.Lists;

namespace Mantenimiento.DataAccess
{
    public class ControlUnidadTipoMantenimientoData
    {
        public static async Task<int> AnularControlUnidadMantenimiento(int IdTipMan, string Are_Codigo)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_tb_ControlUnidadTipoMantenimiento_Anular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pIdTipMan", SqlDbType.Int).Value = IdTipMan;
                        cmd.Parameters.Add("@pARE_CODIGO", SqlDbType.VarChar).Value = Are_Codigo;
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
