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
    public class PlanAccionData
    {
        public static List<PlanAccionEntity> SelectPlanAccion(int IdPlan)
        {
            List<PlanAccionEntity> List = new List<PlanAccionEntity>();

            using (var con = GetConnection.BDALMACEN())
            {
                using (var cmd = new SqlCommand("usp_PlanAccion_ObtenerPorId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pIdPlan", SqlDbType.Int).Value = IdPlan;
                    bool openConn = (con.State == ConnectionState.Open);
                    if (!openConn) { con.Open(); }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            List.Add(new PlanAccionEntity
                            {
                                IdPlan = DataReader.GetIntValue(dr, "IdPlan"),
                                PlanAccion = DataReader.GetStringValue(dr, "PlanAccion"),
                                fecha_inicio = DataReader.GetDateTimeValue(dr, "fecha_inicio"),
                                fecha_fin = DataReader.GetDateTimeValue(dr, "fecha_fin"),
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
