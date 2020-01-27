using System.Configuration;
using System.Data.SqlClient;

namespace Mantenimiento.DataAccess.Connection
{
    public static class GetConnection
    {
        public static SqlConnection BDALMACEN()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BDALMACEN"].ConnectionString);
            return con;
        }
    }
}
