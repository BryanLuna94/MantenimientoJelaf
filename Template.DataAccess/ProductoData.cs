using System;

using System.Data;
using System.Data.SqlClient;

using System.Threading.Tasks;
using Mantenimiento.DataAccess.Connection;
using Mantenimiento.Entities.Objects.Entities;
using System.Collections.Generic;
using Mantenimiento.Utility;
using System.Linq;

namespace Mantenimiento.DataAccess
{
    public static class ProductoData
    {

        public static List<ProductoEntity> ListProducto(short Index_Compañia, string filtro)
        {
            List<ProductoEntity> List = new List<ProductoEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_LIS_TbLG_Producto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Index_Compañia ", SqlDbType.Int).Value = Index_Compañia;
                    cmd.Parameters.Add("@Filtro ", SqlDbType.VarChar).Value = filtro;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new ProductoEntity
                            {
                                ID_Key = DataReader.GetIntValue(dr, "ID_Key"),
                                ID_Index = DataReader.GetIntValue(dr, "ID_Index"),
                                Index_Compañia = DataReader.GetIntValue(dr, "Index_Compañia"),
                                Descripcion = DataReader.GetStringValue(dr, "Descripcion"),
                                Observacion = DataReader.GetStringValue(dr, "Observacion"),
                                CodigoOriginal = DataReader.GetStringValue(dr, "CodigoOriginal"),
                                DescripcionOriginal = DataReader.GetStringValue(dr, "DescripcionOriginal"),
                                CodigoAlternativo = DataReader.GetStringValue(dr, "CodigoAlternativo"),
                                Index_Marca = DataReader.GetIntValue(dr, "Index_Marca"),
                                Marca = DataReader.GetStringValue(dr, "Marca"),
                                Index_Modelo = DataReader.GetIntValue(dr, "Index_Modelo"),
                                Modelo = DataReader.GetStringValue(dr, "Modelo"),
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
