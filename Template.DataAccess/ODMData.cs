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
    public class ODMData
    {
        public static decimal InsertODM(ODMEntity objEntidad)
        {
            decimal nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("SP_INSERT_ODM", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Emp_Codigo", SqlDbType.VarChar).Value = objEntidad.Emp_Codigo;
                        cmd.Parameters.Add("@ODM_Incluye", SqlDbType.VarChar).Value = objEntidad.ODM_Incluye;
                        cmd.Parameters.Add("@Are_Codigo", SqlDbType.VarChar).Value = objEntidad.Are_Codigo;
                        cmd.Parameters.Add("@Usr_Codigo", SqlDbType.VarChar).Value = objEntidad.Usr_Codigo;
                        cmd.Parameters.Add("@ODM_Fecha", SqlDbType.DateTime).Value = objEntidad.ODM_Fecha;
                        cmd.Parameters.Add("@ODM_Hora", SqlDbType.VarChar).Value = objEntidad.ODM_Hora;
                        cmd.Parameters.Add("@ODM_Observacion", SqlDbType.VarChar).Value = objEntidad.ODM_Observacion;
                        cmd.Parameters.Add("@ODM_FechMovimiento", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.ODM_FechMovimiento);
                        cmd.Parameters.Add("@ODM_FechContable", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.ODM_FechContable);
                        cmd.Parameters.Add("@ODM_FechVencimiento", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.ODM_FechVencimiento);
                        cmd.Parameters.Add("@Ben_Codigo_Jefe", SqlDbType.VarChar).Value = objEntidad.Ben_Codigo_Jefe;
                        cmd.Parameters.Add("@Ben_Codigo_Solicitante", SqlDbType.VarChar).Value = objEntidad.Ben_Codigo_Solicitante;
                        cmd.Parameters.Add("@Suc_Codigo", SqlDbType.VarChar).Value = objEntidad.Suc_Codigo;
                        cmd.Parameters.Add("@Ofi_Codigo", SqlDbType.VarChar).Value = objEntidad.Ofi_Codigo;
                        cmd.Parameters.Add("@ODM_Informe", SqlDbType.Decimal).Value = objEntidad.ODM_Informe;
                        cmd.Parameters.Add("@ODM_Estado", SqlDbType.VarChar).Value = objEntidad.ODM_Estado;
                        cmd.Parameters.Add("@IdTareaMecanicos", SqlDbType.Int).Value = objEntidad.IdTareaMecanicos;
                        cmd.Parameters.Add("@ODM_Codigo", SqlDbType.Decimal).Value = 0;
                        cmd.Parameters["@ODM_Codigo"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        nuevoId = Convert.ToDecimal(cmd.Parameters["@ODM_Codigo"].Value);
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

        public static decimal ValidaExiste(string ben_codigo,decimal idInforme)
        {
            decimal result = 0;
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_SEL_tb_ODM_ValidaExiste", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pBen_Codigo_Solicitante", SqlDbType.VarChar).Value = ben_codigo;
                    cmd.Parameters.Add("@pODM_Informe", SqlDbType.Decimal).Value = idInforme;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result = Convert.ToDecimal(dr[0]);
                        }

                        dr.Close();
                    }

                    cmd.Dispose();
                }

                if (con.State == ConnectionState.Open) { con.Close(); }
            }

            return result;
        }
    }
}
