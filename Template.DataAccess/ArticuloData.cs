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
    public class ArticuloData
    {
        public static List<BusquedaArticuloList> BusquedaArticulo(string CodiEmpresa, string IdAlmacen)
        {
            List<BusquedaArticuloList> List = new List<BusquedaArticuloList>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_Mer_Buscar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pCodi_Empresa", SqlDbType.VarChar).Value = CodiEmpresa;
                    cmd.Parameters.Add("@pidalmacen", SqlDbType.VarChar).Value = IdAlmacen;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new BusquedaArticuloList
                            {
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),
                                Original = DataReader.GetStringValue(dr, "Original"),
                                Marca = DataReader.GetStringValue(dr, "Marca"),
                                Codigo = DataReader.GetStringValue(dr, "Codigo"),
                                Abr = DataReader.GetStringValue(dr, "Abr"),
                                Stock = DataReader.GetDecimalValue(dr, "Stock"),
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
