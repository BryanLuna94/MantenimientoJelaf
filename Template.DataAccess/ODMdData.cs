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
    public class ODMdData
    {
        public static decimal InsertODMd(ODMdEntity objEntidad)
        {
            decimal nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("SP_INSERT_ODMd", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Emp_Codigo", SqlDbType.VarChar).Value = objEntidad.Emp_Codigo;
                        cmd.Parameters.Add("@ODM_Codigo", SqlDbType.VarChar).Value = objEntidad.ODM_Codigo;
                        cmd.Parameters.Add("@Cod_Sistema", SqlDbType.VarChar).Value = objEntidad.Cod_Sistema;
                        cmd.Parameters.Add("@Cod_Componente", SqlDbType.VarChar).Value = objEntidad.Cod_Componente;
                        cmd.Parameters.Add("@Mer_Tipo", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@Mer_Codigo", SqlDbType.VarChar).Value = objEntidad.Mer_Codigo;
                        cmd.Parameters.Add("@ODMd_Cuenta", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@ODMd_Cantidad", SqlDbType.Decimal).Value = objEntidad.ODMd_Cantidad;
                        cmd.Parameters.Add("@ODMd_Can_Atendida", SqlDbType.Decimal).Value = 0;
                        cmd.Parameters.Add("@ODMd_Precio", SqlDbType.Decimal).Value = 0;
                        cmd.Parameters.Add("@ODMd_Exonerado", SqlDbType.Decimal).Value = 0;
                        cmd.Parameters.Add("@ODMd_Bruto", SqlDbType.Decimal).Value = 0;
                        cmd.Parameters.Add("@ODMd_Total", SqlDbType.Decimal).Value = 0;
                        cmd.Parameters.Add("@ODMd_VVenta", SqlDbType.Decimal).Value = 0;
                        cmd.Parameters.Add("@ODMd_VIgv", SqlDbType.Decimal).Value = 0;
                        cmd.Parameters.Add("@ODMd_VTotal", SqlDbType.Decimal).Value = 0;
                        cmd.Parameters.Add("@ODMd_Observacion ", SqlDbType.VarChar).Value = objEntidad.ODMd_Observacion;
                        cmd.Parameters.Add("@ODMd_Estado", SqlDbType.VarChar).Value = "00";
                        cmd.Parameters.Add("@Ben_Codigo", SqlDbType.VarChar).Value = objEntidad.Ben_Codigo;
                        cmd.Parameters.Add("@Are_Codigo", SqlDbType.VarChar).Value = objEntidad.Are_Codigo;
                        cmd.Parameters.Add("@DTem_Informe", SqlDbType.VarChar).Value = objEntidad.DTem_Informe;
                        cmd.Parameters.Add("@DTem_Destino", SqlDbType.VarChar).Value = objEntidad.DTem_Destino;
                        cmd.Parameters.Add("@COD_OFI", SqlDbType.VarChar).Value = objEntidad.COD_OFI;
                        cmd.Parameters.Add("@Id_CtrlBolsaRepInforme", SqlDbType.Int).Value = objEntidad.Id_CtrlBolsaRepInforme;
                        cmd.Parameters.Add("@ODMd_Codigo", SqlDbType.Decimal).Value = 0;
                        cmd.Parameters["@ODMd_Codigo"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        nuevoId = Convert.ToDecimal(cmd.Parameters["@ODMd_Codigo"].Value);
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

        public static async Task<ODMdEntity> DeleteODMd(decimal ODMd_Codigo)
        {
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("SP_DELETE_ODMd", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ODMd_Codigo", SqlDbType.VarChar).Value = ODMd_Codigo; 
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

        public static List<ODMdList> ListBolsas(decimal IdInforme, string Ben_Codigo)
        {
            List<ODMdList> List = new List<ODMdList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_LIS_VW_ODMs", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pnumeroinforme", SqlDbType.Decimal).Value = IdInforme;
                    cmd.Parameters.Add("@pben_codigo", SqlDbType.VarChar).Value = Ben_Codigo;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new ODMdList
                            {
                                Atendida = DataReader.GetDecimalValue(dr, "Atendida"),
                                BenNombreSolicitante = DataReader.GetStringValue(dr, "BenNombreSolicitante"),
                                Ben_Codigo_Solicitante = DataReader.GetStringValue(dr, "Ben_Codigo_Solicitante"),
                                Cod_Componente = DataReader.GetStringValue(dr, "Cod_Componente"),
                                Cod_Sistema = DataReader.GetStringValue(dr, "Cod_Sistema"),
                                Id_CtrlBolsaRepInforme = DataReader.GetStringValue(dr, "Id_CtrlBolsaRepInforme"),
                                Mer_Codigo = DataReader.GetStringValue(dr, "Mer_Codigo"),
                                Mer_CodOriginal = DataReader.GetStringValue(dr, "Mer_CodOriginal"),
                                Mer_Nombre = DataReader.GetStringValue(dr, "Mer_Nombre"),
                                ODMd_Cantidad = DataReader.GetDecimalValue(dr, "ODMd_Cantidad"),
                                ODMd_Codigo = DataReader.GetStringValue(dr, "ODMd_Codigo"),
                                ODM_Codigo = DataReader.GetStringValue(dr, "ODM_Codigo"),
                                ODM_FechMovimiento = DataReader.GetDateTimeValue(dr, "ODM_FechMovimiento").Value.ToShortDateString()
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

        public static List<ODMdList> ListBolsasPorInforme(decimal IdInforme)
        {
            List<ODMdList> List = new List<ODMdList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_LIS_VW_ODMs_Por_Informe", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pnumeroinforme", SqlDbType.Decimal).Value = IdInforme;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new ODMdList
                            {
                                Atendida = DataReader.GetDecimalValue(dr, "Atendida"),
                                BenNombreSolicitante = DataReader.GetStringValue(dr, "BenNombreSolicitante"),
                                Ben_Codigo_Solicitante = DataReader.GetStringValue(dr, "Ben_Codigo_Solicitante"),
                                Cod_Componente = DataReader.GetStringValue(dr, "Cod_Componente"),
                                Cod_Sistema = DataReader.GetStringValue(dr, "Cod_Sistema"),
                                Id_CtrlBolsaRepInforme = DataReader.GetStringValue(dr, "Id_CtrlBolsaRepInforme"),
                                Mer_Codigo = DataReader.GetStringValue(dr, "Mer_Codigo"),
                                Mer_CodOriginal = DataReader.GetStringValue(dr, "Mer_CodOriginal"),
                                Mer_Nombre = DataReader.GetStringValue(dr, "Mer_Nombre"),
                                ODMd_Cantidad = DataReader.GetDecimalValue(dr, "ODMd_Cantidad"),
                                ODMd_Codigo = DataReader.GetStringValue(dr, "ODMd_Codigo"),
                                ODM_Codigo = DataReader.GetStringValue(dr, "ODM_Codigo"),
                                ODM_FechMovimiento = DataReader.GetDateTimeValue(dr, "ODM_FechMovimiento").Value.ToShortDateString()
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
