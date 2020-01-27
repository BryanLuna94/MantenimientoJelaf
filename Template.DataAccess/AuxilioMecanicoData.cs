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
    public class AuxilioMecanicoData
    {
        public static List<AuxilioMecanicoList> ListAuxilioMecanico(DateTime fechahora_ini, DateTime fechahora_fin, string Are_Codigo, string Ben_Codigo)
        {
            List<AuxilioMecanicoList> List = new List<AuxilioMecanicoList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_LIS_Tb_AuxilioMecanico", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pFechahora_ini", SqlDbType.DateTime).Value = fechahora_ini;
                    cmd.Parameters.Add("@pFechahora_fin", SqlDbType.DateTime).Value = fechahora_fin;
                    cmd.Parameters.Add("@pAre_Codigo", SqlDbType.VarChar).Value = Are_Codigo;
                    cmd.Parameters.Add("@pBen_Codigo", SqlDbType.VarChar).Value = Ben_Codigo;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new AuxilioMecanicoList
                            {
                                ID_Tb_AuxilioMecanico = DataReader.GetIntValue(dr, "ID_Tb_AuxilioMecanico"),
                                Carga = DataReader.GetStringValue(dr, "Carga"),
                                Bus = DataReader.GetStringValue(dr, "Bus"),
                                Carreta = DataReader.GetStringValue(dr, "Carreta"),
                                Kmt_unidad = DataReader.GetDecimalValue(dr, "Kmt_unidad"),
                                Kmt_recorrido = DataReader.GetDecimalValue(dr, "Kmt_recorrido"),
                                Beneficiario = DataReader.GetStringValue(dr, "Mecanico"),
                                StrFechaIni = DataReader.GetDateTimeValue(dr, "Fechahora_ini").Value.ToString("dd/MM/yyyy H:mm"),
                                StrFechaFin = DataReader.GetDateTimeValue(dr, "Fechahora_fin").Value.ToString("dd/MM/yyyy H:mm"),
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

        public static AuxilioMecanicoEntity SelectAuxilioMecanico(int ID_Tb_AuxilioMecanico)
        {
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_SEL_Tb_AuxilioMecanico", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pID_Tb_AuxilioMecanico", SqlDbType.Int).Value = ID_Tb_AuxilioMecanico;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return new AuxilioMecanicoEntity
                            {
                                ID_Tb_AuxilioMecanico = DataReader.GetIntValue(dr, "ID_Tb_AuxilioMecanico"),
                                Carga = DataReader.GetStringValue(dr, "Carga"),
                                Are_Codigo = DataReader.GetStringValue(dr, "Are_Codigo"),
                                Are_Codigo2 = DataReader.GetStringValue(dr, "Are_Codigo2"),
                                Kmt_unidad = DataReader.GetDecimalValue(dr, "Kmt_unidad"),
                                Kmt_recorrido = DataReader.GetDecimalValue(dr, "Kmt_recorrido"),
                                MMG = DataReader.GetStringValue(dr, "MMG"),
                                Fechahora_ini = DataReader.GetDateTimeValue(dr, "Fechahora_ini").Value.ToString("dd/MM/yyyy h:mm"),
                                Fechahora_fin = DataReader.GetDateTimeValue(dr, "Fechahora_fin").Value.ToString("dd/MM/yyyy h:mm"),
                                Controlable = DataReader.GetStringValue(dr, "Controlable"),
                                Id_plataforma = DataReader.GetDecimalValue(dr, "Id_plataforma"),
                                Idtarea_c = DataReader.GetSmallIntValue(dr, "Idtarea_c"),
                                Falla = DataReader.GetStringValue(dr, "Falla"),
                                Ben_codigo = DataReader.GetStringValue(dr, "Ben_codigo"),
                                Servicio = DataReader.GetStringValue(dr, "Servicio"),
                                Kmt_Perdido = DataReader.GetDecimalValue(dr, "Kmt_Perdido"),
                                CambioTracto = DataReader.GetSmallIntValue(dr, "CambioTracto"),
                                Responsable = DataReader.GetStringValue(dr, "Responsable"),
                                Atencion = DataReader.GetStringValue(dr, "Atencion"),
                                Causa = DataReader.GetStringValue(dr, "Causa"),
                                IdPlan = DataReader.GetIntValue(dr, "IdPlan")
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

        public static async Task<int> InsertAuxilioMecanico(AuxilioMecanicoEntity objEntidad)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_INS_Tb_AuxilioMecanico", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pCarga", SqlDbType.VarChar).Value = objEntidad.Carga;
                        cmd.Parameters.Add("@pAre_Codigo", SqlDbType.VarChar).Value = objEntidad.Are_Codigo;
                        cmd.Parameters.Add("@pAre_Codigo2", SqlDbType.VarChar).Value = Functions.Check.Cadena(objEntidad.Are_Codigo2);
                        cmd.Parameters.Add("@pKmt_unidad", SqlDbType.Decimal).Value = objEntidad.Kmt_unidad;
                        cmd.Parameters.Add("@pKmt_recorrido", SqlDbType.Decimal).Value = objEntidad.Kmt_recorrido;
                        cmd.Parameters.Add("@pMMG", SqlDbType.VarChar).Value = objEntidad.MMG;
                        cmd.Parameters.Add("@pFechahora_ini", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.Fechahora_ini);
                        cmd.Parameters.Add("@pFechahora_fin", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.Fechahora_fin);
                        cmd.Parameters.Add("@pControlable", SqlDbType.VarChar).Value = objEntidad.Controlable;
                        cmd.Parameters.Add("@pId_plataforma", SqlDbType.Decimal).Value = objEntidad.Id_plataforma;
                        cmd.Parameters.Add("@pIdtarea_c", SqlDbType.SmallInt).Value = objEntidad.Idtarea_c;
                        cmd.Parameters.Add("@pFalla", SqlDbType.VarChar).Value = objEntidad.Falla;
                        cmd.Parameters.Add("@pBen_codigo", SqlDbType.VarChar).Value = objEntidad.Ben_codigo;
                        cmd.Parameters.Add("@pKmt_Perdido", SqlDbType.Decimal).Value = objEntidad.Kmt_Perdido;
                        cmd.Parameters.Add("@pCambioTracto", SqlDbType.SmallInt).Value = objEntidad.CambioTracto;
                        cmd.Parameters.Add("@pResponsable", SqlDbType.VarChar).Value = objEntidad.Responsable;
                        cmd.Parameters.Add("@pServicio", SqlDbType.VarChar).Value = objEntidad.Servicio;
                        cmd.Parameters.Add("@pAtencion", SqlDbType.VarChar).Value = objEntidad.Atencion;
                        cmd.Parameters.Add("@pCausa", SqlDbType.VarChar).Value = objEntidad.Causa;
                        cmd.Parameters.Add("@pIdPlan", SqlDbType.Int).Value = objEntidad.IdPlan;
                        cmd.Parameters.Add("@pID_Tb_AuxilioMecanico", SqlDbType.Int).Value = 0;
                        await cmd.ExecuteNonQueryAsync();
                        nuevoId = Convert.ToInt32(cmd.Parameters["@pID_Tb_AuxilioMecanico"].Value);
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

        public static async Task<AuxilioMecanicoEntity> UpdateAuxilioMecanico(AuxilioMecanicoEntity objEntidad)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UPD_Tb_AuxilioMecanico", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pCarga", SqlDbType.VarChar).Value = objEntidad.Carga;
                        cmd.Parameters.Add("@pAre_Codigo", SqlDbType.VarChar).Value = objEntidad.Are_Codigo;
                        cmd.Parameters.Add("@pAre_Codigo2", SqlDbType.VarChar).Value = Functions.Check.Cadena(objEntidad.Are_Codigo2);
                        cmd.Parameters.Add("@pKmt_unidad", SqlDbType.Decimal).Value = objEntidad.Kmt_unidad;
                        cmd.Parameters.Add("@pKmt_recorrido", SqlDbType.Decimal).Value = objEntidad.Kmt_recorrido;
                        cmd.Parameters.Add("@pMMG", SqlDbType.VarChar).Value = objEntidad.MMG;
                        cmd.Parameters.Add("@pFechahora_ini", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.Fechahora_ini);
                        cmd.Parameters.Add("@pFechahora_fin", SqlDbType.DateTime).Value = Convert.ToDateTime(objEntidad.Fechahora_fin);
                        cmd.Parameters.Add("@pControlable", SqlDbType.VarChar).Value = objEntidad.Controlable;
                        cmd.Parameters.Add("@pId_plataforma", SqlDbType.Decimal).Value = objEntidad.Id_plataforma;
                        cmd.Parameters.Add("@pIdtarea_c", SqlDbType.SmallInt).Value = objEntidad.Idtarea_c;
                        cmd.Parameters.Add("@pFalla", SqlDbType.VarChar).Value = objEntidad.Falla;
                        cmd.Parameters.Add("@pBen_codigo", SqlDbType.VarChar).Value = objEntidad.Ben_codigo;
                        cmd.Parameters.Add("@pServicio", SqlDbType.VarChar).Value = objEntidad.Servicio;
                        cmd.Parameters.Add("@pKmt_Perdido", SqlDbType.Decimal).Value = objEntidad.Kmt_Perdido;
                        cmd.Parameters.Add("@pCambioTracto", SqlDbType.SmallInt).Value = objEntidad.CambioTracto;
                        cmd.Parameters.Add("@pResponsable", SqlDbType.VarChar).Value = objEntidad.Responsable;
                        cmd.Parameters.Add("@pAtencion", SqlDbType.VarChar).Value = objEntidad.Atencion;
                        cmd.Parameters.Add("@pCausa", SqlDbType.VarChar).Value = objEntidad.Causa;
                        cmd.Parameters.Add("@pIdPlan", SqlDbType.Int).Value = objEntidad.IdPlan;
                        cmd.Parameters.Add("@pID_Tb_AuxilioMecanico", SqlDbType.Int).Value = objEntidad.ID_Tb_AuxilioMecanico;
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

        public static async Task<AuxilioMecanicoEntity> DeleteAuxilioMecanico(int ID_Tb_AuxilioMecanico)
        {


            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_DEL_Tb_AuxilioMecanico", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pID_Tb_AuxilioMecanico", SqlDbType.Int).Value = ID_Tb_AuxilioMecanico;

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

        public static List<AuxilioMecanicoEntity> ListAuxilioMecanicoPorAnioMes(short anio, byte mes)
        {
            List<AuxilioMecanicoEntity> List = new List<AuxilioMecanicoEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_ObtenerPorMesAnio_Tb_AuxilioMecanico", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pAnio", SqlDbType.SmallInt).Value = anio;
                    cmd.Parameters.Add("@pMes", SqlDbType.TinyInt).Value = mes;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new AuxilioMecanicoEntity
                            {
                                ID_Tb_AuxilioMecanico = DataReader.GetIntValue(dr, "ID_Tb_AuxilioMecanico"),
                                Carga = DataReader.GetStringValue(dr, "Carga"),
                                Are_Codigo = DataReader.GetStringValue(dr, "Are_Codigo"),
                                Are_Codigo2 = DataReader.GetStringValue(dr, "Are_Codigo2"),
                                Kmt_unidad = DataReader.GetDecimalValue(dr, "Kmt_unidad"),
                                Kmt_recorrido = DataReader.GetDecimalValue(dr, "Kmt_recorrido"),
                                MMG = DataReader.GetStringValue(dr, "MMG"),
                                Fechahora_ini = DataReader.GetDateTimeValue(dr, "Fechahora_ini").Value.ToString("dd/MM/yyyy H:mm"),
                                Fechahora_fin = DataReader.GetDateTimeValue(dr, "Fechahora_fin").Value.ToString("dd/MM/yyyy H:mm"),
                                Controlable = DataReader.GetStringValue(dr, "Controlable"),
                                Id_plataforma = DataReader.GetDecimalValue(dr, "Id_plataforma"),
                                Idtarea_c = DataReader.GetSmallIntValue(dr, "Idtarea_c"),
                                Falla = DataReader.GetStringValue(dr, "Falla"),
                                Ben_codigo = DataReader.GetStringValue(dr, "Ben_codigo"),
                                Servicio = DataReader.GetStringValue(dr, "Servicio"),
                                Kmt_Perdido = DataReader.GetDecimalValue(dr, "Kmt_Perdido"),
                                CambioTracto = DataReader.GetSmallIntValue(dr, "CambioTracto"),
                                Responsable = DataReader.GetStringValue(dr, "Responsable"),
                                Atencion = DataReader.GetStringValue(dr, "Atencion"),
                                Causa = DataReader.GetStringValue(dr, "Causa"),
                                IdPlan = DataReader.GetIntValue(dr, "IdPlan")
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
