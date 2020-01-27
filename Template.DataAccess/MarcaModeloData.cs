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
    public static class MarcaModeloData
    {
        public static List<MarcaModeloEntity> ListMarcaModelo()
        {
            List<MarcaModeloEntity> List = new List<MarcaModeloEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_LIS_Tb_MarcaModeloBuses", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new MarcaModeloEntity
                            {
                                cod_marca = DataReader.GetStringValue(dr, "cod_marca"),
                                marca = DataReader.GetStringValue(dr, "marca"),
                                cod_modelo = DataReader.GetStringValue(dr, "cod_modelo"),
                                modelo = DataReader.GetStringValue(dr,"modelo"),
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
