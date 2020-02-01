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
    public class InformeData
    {
        public static List<InformeList> ListInformeAdmin(InformeFilter objFiltro)
        {
            List<InformeList> List = new List<InformeList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("LIS_Tb_Informe_Admin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TIPOU", SqlDbType.Int).Value = Functions.Check.Int32(objFiltro.TipoU);
                    cmd.Parameters.Add("@NINFORME", SqlDbType.Int).Value = Functions.Check.Int32(objFiltro.NInforme);
                    cmd.Parameters.Add("@FECH_INI", SqlDbType.Date).Value = Convert.ToDateTime(objFiltro.Fech_ini);
                    cmd.Parameters.Add("@FECH_FIN", SqlDbType.Date).Value = Convert.ToDateTime(objFiltro.Fech_fin);
                    cmd.Parameters.Add("@ORDEN", SqlDbType.VarChar).Value = objFiltro.Orden;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new InformeList
                            {
                                Chofer = DataReader.GetStringValue(dr, "Chofer"),
                                TIPOU = DataReader.GetIntValue(dr, "TIPOU"),
                                CodChofer = DataReader.GetStringValue(dr, "CodChofer"),
                                Fecha = DataReader.GetDateTimeValue(dr, "Fecha").Value.ToShortDateString(),
                                FechaCierre = Functions.Check.Datetime(DataReader.GetStringValue(dr, "FechaCierre")).Value.ToShortDateString(),
                                IdInforme = DataReader.GetIntValue(dr, "IdInforme"),
                                Interno = DataReader.GetStringValue(dr, "Interno"),
                                NumeroInforme = DataReader.GetDecimalValue(dr, "NumeroInforme"),
                                Oficina = DataReader.GetStringValue(dr, "Oficina"),
                                Placa = DataReader.GetStringValue(dr, "Placa"),
                                Tipo = DataReader.GetStringValue(dr, "Tipo"),
                                Usr_Nombre = DataReader.GetStringValue(dr, "Usr_Nombre"),
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

        public static List<InformeList> ListInformeSoloMiUsuario(InformeFilter objFiltro)
        {
            List<InformeList> List = new List<InformeList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("LIS_Tb_Informe_User", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TIPOU", SqlDbType.Int).Value = Functions.Check.Int32(objFiltro.TipoU);
                    cmd.Parameters.Add("@NINFORME", SqlDbType.Int).Value = Functions.Check.Int32(objFiltro.NInforme);
                    cmd.Parameters.Add("@FECH_INI", SqlDbType.Date).Value = Convert.ToDateTime(objFiltro.Fech_ini);
                    cmd.Parameters.Add("@FECH_FIN", SqlDbType.Date).Value = Convert.ToDateTime(objFiltro.Fech_fin);
                    cmd.Parameters.Add("@ORDEN", SqlDbType.VarChar).Value = objFiltro.Orden;
                    cmd.Parameters.Add("@USR_CODIGO", SqlDbType.Int).Value = objFiltro.UsrCodigo;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new InformeList
                            {
                                Chofer = DataReader.GetStringValue(dr, "Chofer"),
                                TIPOU = DataReader.GetIntValue(dr, "TIPOU"),
                                CodChofer = DataReader.GetStringValue(dr, "CodChofer"),
                                Fecha = DataReader.GetDateTimeValue(dr, "Fecha").Value.ToShortDateString(),
                                FechaCierre = Functions.Check.Datetime(DataReader.GetStringValue(dr, "FechaCierre")).Value.ToShortDateString(),
                                IdInforme = DataReader.GetIntValue(dr, "IdInforme"),
                                Interno = DataReader.GetStringValue(dr, "Interno"),
                                NumeroInforme = DataReader.GetDecimalValue(dr, "NumeroInforme"),
                                Oficina = DataReader.GetStringValue(dr, "Oficina"),
                                Placa = DataReader.GetStringValue(dr, "Placa"),
                                Tipo = DataReader.GetStringValue(dr, "Tipo"),
                                Usr_Nombre = DataReader.GetStringValue(dr, "Usr_Nombre"),
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

        public static List<InformeList> ListInformeUsuario(InformeFilter objFiltro)
        {
            List<InformeList> List = new List<InformeList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("LIS_Tb_Informe_Sucursal", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TIPOU", SqlDbType.Int).Value = Functions.Check.Int32(objFiltro.TipoU);
                    cmd.Parameters.Add("@NINFORME", SqlDbType.Int).Value = Functions.Check.Int32(objFiltro.NInforme);
                    cmd.Parameters.Add("@FECH_INI", SqlDbType.Date).Value = Convert.ToDateTime(objFiltro.Fech_ini);
                    cmd.Parameters.Add("@FECH_FIN", SqlDbType.Date).Value = Convert.ToDateTime(objFiltro.Fech_fin);
                    cmd.Parameters.Add("@ORDEN", SqlDbType.VarChar).Value = objFiltro.Orden;
                    cmd.Parameters.Add("@USR_CODIGO", SqlDbType.Int).Value = objFiltro.UsrCodigo;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new InformeList
                            {
                                Chofer = DataReader.GetStringValue(dr, "Chofer"),
                                TIPOU = DataReader.GetIntValue(dr, "TIPOU"),
                                CodChofer = DataReader.GetStringValue(dr, "CodChofer"),
                                Fecha = DataReader.GetDateTimeValue(dr, "Fecha").Value.ToShortDateString(),
                                FechaCierre = Functions.Check.Datetime(DataReader.GetStringValue(dr, "FechaCierre")).Value.ToShortDateString(),
                                IdInforme = DataReader.GetIntValue(dr, "IdInforme"),
                                Interno = DataReader.GetStringValue(dr, "Interno"),
                                NumeroInforme = DataReader.GetDecimalValue(dr, "NumeroInforme"),
                                Oficina = DataReader.GetStringValue(dr, "Oficina"),
                                Placa = DataReader.GetStringValue(dr, "Placa"),
                                Tipo = DataReader.GetStringValue(dr, "Tipo"),
                                Usr_Nombre = DataReader.GetStringValue(dr, "Usr_Nombre"),
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

        public static InformeEntity SelectInforme(int idInforme)
        {
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("Usp_Tb_Infome_Find_", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idInforme;
                    cmd.Parameters.Add("@e", SqlDbType.Int).Value = 1;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return new InformeEntity
                            {
                                IdInforme = DataReader.GetIntValue(dr, "IDINFORME"),
                                Are_Codigo = DataReader.GetStringValue(dr, "ARE_CODIGO"),
                                Are_Nombre = DataReader.GetStringValue(dr, "ARE_NOMBRE"),
                                Ofi_Codigo = DataReader.GetStringValue(dr, "Ofi_Codigo"),
                                Oficina = DataReader.GetStringValue(dr, "Oficina"),
                                Ben_Codigo = DataReader.GetStringValue(dr, "Ben_Codigo"),
                                Chofer = DataReader.GetStringValue(dr, "Cocher"),
                                FechaStr = DataReader.GetDateTimeValue(dr, "FECHA").Value.ToShortDateString(),
                                Hora = DataReader.GetStringValue(dr, "hora"),
                                Observacion = DataReader.GetStringValue(dr, "OBSERVACION"),
                                KmUnidad = DataReader.GetDecimalValue(dr, "KMUNIDAD"),
                                EstCierre = DataReader.GetBooleanValue(dr, "EstCierre"),
                                TipoInforme = DataReader.GetStringValue(dr, "TipoInforme"),
                                Are_Observacion = DataReader.GetStringValue(dr, "are_observacion"),
                                IdUndAlerta = DataReader.GetIntValue(dr, "IdUndAlerta"),
                                NumeroInforme = DataReader.GetIntValue(dr, "NumeroInforme"),
                                Solicitante = DataReader.GetStringValue(dr, "Solicitante")
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

        public static InformeEntity SelectInformeCorrectivoPreventivoTractoCarreta(decimal NumeroInforme, string TipoInforme, int TipoU)
        {
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("Usp_Tb_Infome_Find_TraerCorrectivoPreventivoTractoCarreta", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pNumeroInforme", SqlDbType.Decimal).Value = NumeroInforme;
                    cmd.Parameters.Add("@pTipoInforme", SqlDbType.VarChar).Value = TipoInforme;
                    cmd.Parameters.Add("@pTipoU", SqlDbType.Int).Value = TipoU;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return new InformeEntity
                            {
                                IdInforme = DataReader.GetIntValue(dr, "IDINFORME"),
                                Are_Codigo = DataReader.GetStringValue(dr, "ARE_CODIGO"),
                                Are_Nombre = DataReader.GetStringValue(dr, "ARE_NOMBRE"),
                                Ofi_Codigo = DataReader.GetStringValue(dr, "Ofi_Codigo"),
                                Oficina = DataReader.GetStringValue(dr, "Oficina"),
                                Ben_Codigo = DataReader.GetStringValue(dr, "Ben_Codigo"),
                                Chofer = DataReader.GetStringValue(dr, "Cocher"),
                                FechaStr = DataReader.GetDateTimeValue(dr, "FECHA").Value.ToShortDateString(),
                                Hora = DataReader.GetStringValue(dr, "hora"),
                                Observacion = DataReader.GetStringValue(dr, "OBSERVACION"),
                                KmUnidad = DataReader.GetDecimalValue(dr, "KMUNIDAD"),
                                EstCierre = DataReader.GetBooleanValue(dr, "EstCierre"),
                                TipoInforme = DataReader.GetStringValue(dr, "TipoInforme"),
                                Are_Observacion = DataReader.GetStringValue(dr, "are_observacion"),
                                IdUndAlerta = DataReader.GetIntValue(dr, "IdUndAlerta"),
                                NumeroInforme = DataReader.GetIntValue(dr, "NumeroInforme"),
                                Solicitante = DataReader.GetStringValue(dr, "Solicitante"),
                                Tipo = DataReader.GetStringValue(dr, "TIPOU")
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

        public static int InsertInforme(InformeEntity objEntidad)
        {
            int nuevoId = 0;
            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("Usp_Tb_Informe_Insert", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Are_Codigo", SqlDbType.VarChar).Value = objEntidad.Are_Codigo;
                        cmd.Parameters.Add("@ChoferEntrega", SqlDbType.VarChar).Value = objEntidad.ChoferEntrega;
                        cmd.Parameters.Add("@KmUnidad", SqlDbType.Decimal).Value = objEntidad.KmUnidad;
                        cmd.Parameters.Add("@Ofi_Codigo", SqlDbType.VarChar).Value = objEntidad.Ofi_Codigo;
                        cmd.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = objEntidad.Fecha;
                        cmd.Parameters.Add("@CostoManoObra", SqlDbType.Real).Value = objEntidad.CostoManoObra;
                        cmd.Parameters.Add("@ServicioTerceros", SqlDbType.Real).Value = objEntidad.ServicioTerceros;
                        cmd.Parameters.Add("@CostoRepuestos", SqlDbType.Real).Value = objEntidad.CostoRepuestos;
                        cmd.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = objEntidad.Observacion;
                        cmd.Parameters.Add("@UsuarioRegistro", SqlDbType.SmallInt).Value = objEntidad.UsuarioRegistro;
                        cmd.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = objEntidad.Tipo;
                        cmd.Parameters.Add("@IdUndAlerta", SqlDbType.Int).Value = objEntidad.IdUndAlerta;
                        cmd.Parameters.Add("@IdPlanEjecucionTarea", SqlDbType.VarChar).Value = objEntidad.IdPlanEjecucionTarea;
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                nuevoId = Convert.ToInt32(dr[0]);
                            }
                            cmd.Dispose();
                            dr.Close();
                        }
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

        public static int ObtenerUltimoId()
        {
            int ultimoId = 1;
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_tb_Informe_ObtenerId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ultimoId = Convert.ToInt32(dr[0]);
                            return ultimoId;
                        }

                        dr.Close();
                    }

                    cmd.Dispose();
                }

                if (con.State == ConnectionState.Open) { con.Close(); }
            }

            return ultimoId;
        }

        public static async Task<MTBFEntity> UpdateInforme_NumInforme(int IdInforme, decimal NumInforme)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_UPD_tb_Informe_NumInforme", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pIdInforme", SqlDbType.Int).Value = IdInforme;
                        cmd.Parameters.Add("@pNumInforme", SqlDbType.Decimal).Value = NumInforme;
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

        public static async Task<MTBFEntity> AnularInforme(decimal NumInforme, string Tipo)
        {

            try
            {
                using (SqlConnection con = GetConnection.BDALMACEN())
                {
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (SqlCommand cmd = new SqlCommand("usp_DEL_tb_Informe_Anular", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pNumInforme", SqlDbType.Decimal).Value = NumInforme;
                        cmd.Parameters.Add("@pTipo", SqlDbType.Decimal).Value = Tipo;
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
