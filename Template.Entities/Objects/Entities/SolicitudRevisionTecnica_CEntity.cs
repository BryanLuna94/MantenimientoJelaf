namespace Mantenimiento.Entities.Objects.Entities
{
    public class SolicitudRevisionTecnica_CEntity
    {
        public string IdSolicitudRevision { get; set; }
        public System.DateTime FechaDoc { get; set; }
        public string HorasDoc { get; set; }
        public string IdUnidad { get; set; }
        public string IdChofer { get; set; }
        public string CodOrigen { get; set; }
        public string CodDestino { get; set; }
        public decimal Kilometraje { get; set; }
        public string UsuarioRegistro { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public string HoraRegistro { get; set; }
        public System.DateTime FechaViaje { get; set; }
        public string HoraViahe { get; set; }
        public int Estado { get; set; }
    }
}
