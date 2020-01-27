namespace Mantenimiento.Entities.Objects.Entities
{
    public class ProgramacionEntity
    {
        public string CODI_PROGRAMACION { get; set; }
        public string FechaGeneracion { get; set; }
        public string HoraGeneracion { get; set; }
        public string UsuarioGeneracion { get; set; }
        public string NumeroOrden { get; set; }
        public string NumeroMantenimieto { get; set; }
        public decimal KMT_VIAJE { get; set; }
        public string CODI_BUS { get; set; }
    }
}
