﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Mantenimiento.DataAccess.Connection;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Utility;

namespace Mantenimiento.DataAccess
{
    public static class BaseData
    {
        public static List<BaseEntity> ListEmpresa()
        {
            List<BaseEntity> List = new List<BaseEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new BaseEntity
                            {
                                Codigo = DataReader.GetStringValue(dr, "IdEmpresa"),
                                Descripcion = DataReader.GetStringValue(dr, "Empresa"),
                                Ruc = DataReader.GetStringValue(dr, "RUC")
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
        public static List<BaseEntity> ListUsuariosAutocomplete(string value)
        {
            List<BaseEntity> List = new List<BaseEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_EXC_Tb_Usuario_Autocomplete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 30).Value = (value != null) ? value : string.Empty;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new BaseEntity
                            {
                                Codigo = DataReader.GetStringValue(dr, "Codi_Usuario"),
                                Descripcion = DataReader.GetStringValue(dr, "Login"),
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

        public static List<BaseEntity> ListSistemasAutocomplete(string value)
        {
            List<BaseEntity> List = new List<BaseEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_EXC_Tb_Sistemas_Autocomplete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Sistema", SqlDbType.VarChar, 30).Value = (value != null) ? value : string.Empty;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new BaseEntity
                            {
                                Codigo = DataReader.GetStringValue(dr, "ID_tb_Sistema_Mant"),
                                Descripcion = DataReader.GetStringValue(dr, "Sistema"),
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

        public static List<BaseEntity> ListSubSistemasAutocomplete(string value)
        {
            List<BaseEntity> List = new List<BaseEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_EXC_Tb_SubSistemas_Autocomplete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SubSistema", SqlDbType.VarChar, 30).Value = (value != null) ? value : string.Empty;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new BaseEntity
                            {
                                Codigo = DataReader.GetStringValue(dr, "ID_tb_SubSistema_Mant"),
                                Descripcion = DataReader.GetStringValue(dr, "SubSistema"),
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

        public static List<BaseEntity> ListTipoMAutocomplete(string value)
        {
            List<BaseEntity> List = new List<BaseEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_EXC_tb_TipoMantenimiento_c_Autocomplete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TipoM", SqlDbType.VarChar, 50).Value = (value != null) ? value : string.Empty;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new BaseEntity
                            {
                                Codigo = DataReader.GetStringValue(dr, "IdTipMan"),
                                Descripcion = DataReader.GetStringValue(dr, "TipoM"),
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

        public static List<BaseEntity> ListFlotaAutocomplete(string value)
        {
            List<BaseEntity> List = new List<BaseEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_Are_Listar_Autocomplete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pAre_Nombre", SqlDbType.VarChar, 30).Value = (value != null) ? value : string.Empty;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new BaseEntity
                            {
                                Codigo = DataReader.GetStringValue(dr, "Are_Codigo"),
                                Descripcion = DataReader.GetStringValue(dr, "Are_Nombre"),
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

        public static List<BaseEntity> ListPlataformaAutocomplete(string value)
        {
            List<BaseEntity> List = new List<BaseEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_TBLG_PLATAFORMA_Listar_Autocomplete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pDescripcion", SqlDbType.VarChar, 30).Value = (value != null) ? value : string.Empty;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new BaseEntity
                            {
                                Codigo = DataReader.GetStringValue(dr, "ID_Index"),
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

        public static List<BaseEntity> ListTareasAutocomplete(string value)
        {
            List<BaseEntity> List = new List<BaseEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_Tb_Tareas_c_Listar_Autocomplete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pDescripcion", SqlDbType.VarChar, 30).Value = (value != null) ? value : string.Empty;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new BaseEntity
                            {
                                Codigo = DataReader.GetStringValue(dr, "IdTarea"),
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

        public static List<BaseEntity> ListBeneficiarioAutocomplete(string value)
        {
            List<BaseEntity> List = new List<BaseEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_Ben_Listar_Autocomplete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pDescripcion", SqlDbType.VarChar, 30).Value = (value != null) ? value : string.Empty;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new BaseEntity
                            {
                                Codigo = DataReader.GetStringValue(dr, "Ben_Codigo"),
                                Descripcion = DataReader.GetStringValue(dr, "Ben_Nombre"),
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

        public static List<BaseEntity> ListPlanAccionAutocomplete(string value)
        {
            List<BaseEntity> List = new List<BaseEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_PlanAccion_Listar_Autocomplete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pDescripcion", SqlDbType.VarChar, 30).Value = (value != null) ? value : string.Empty;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new BaseEntity
                            {
                                Codigo = DataReader.GetStringValue(dr, "IdPlan"),
                                Descripcion = DataReader.GetStringValue(dr, "PlanAccion"),
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

        public static List<BaseEntity> ListPuntoAtencionAutocomplete(string value)
        {
            List<BaseEntity> List = new List<BaseEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_SEL_TbLG_PuntoAtencion_Autocomplete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pDescripcion01", SqlDbType.VarChar, 20).Value = value ?? string.Empty;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new BaseEntity
                            {
                                Codigo = DataReader.GetStringValue(dr, "ID_Index"),
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion01"),
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
