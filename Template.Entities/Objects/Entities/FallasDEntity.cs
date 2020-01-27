namespace Mantenimiento.Entities.Objects.Entities
{
    public class FallasDEntity
    {
        public string IdSolicitudRevisionD  { get; set; }
        public string IdSolicitudRevision { get; set; }
        public string Observacion { get; set; }
        public string UsuarioRegistro { get; set; }
        public string Fecharegistro { get; set; }
        public string HoraRegistro { get; set; }
        public int Estado { get; set; }
        public int IdSistema { get; set; }
        public int IdObservacion { get; set; }
    }
}
