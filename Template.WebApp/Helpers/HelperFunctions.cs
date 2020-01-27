namespace Mantenimiento.WebApp.Helpers
{
    public class HelperFunctions
    {
        public static string ValdiarFechaStr(string fecha)
        {
            var fechaSalida = "";
            if (fecha == "__/__/____ __:__")
            {
                fechaSalida = "";
            }
            else
            {
                fechaSalida = fecha.Replace("_", "0");
            }
            return fechaSalida;
        }
    }
}