﻿using System;

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
    public class AreData
    {
        public static AreEntity SelectAre(string are_codigo)
        {
            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_SEL_Are", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pAre_Codigo", SqlDbType.VarChar).Value = are_codigo;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return new AreEntity
                            {
                                Klm_Acumulados = DataReader.GetDecimalValue(dr, "Klm_Acumulados")
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
    }
}
