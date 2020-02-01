namespace Mantenimiento.Entities.Objects.Lists
{
    public class SolicitudRevisionList
    {
        public decimal NumeroInforme { get; set; }
        public string Chofer { get; set; }
        public string FechaDoc { get; set; }
        public string HoraDoc { get; set; }
        public string Unidad { get; set; }
        public decimal Odometro { get; set; }
        public string FechaViaje { get; set; }
        public string HoraViaje { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Estado { get; set; }
        public string CorrelativoInterno { get; set; }
        public decimal OdometroAnterior { get; set; }
        public string IdUnidad { get; set; }
        public string IdSolicitudRevision { get; set; }
    }
}
