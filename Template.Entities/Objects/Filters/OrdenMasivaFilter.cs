namespace Mantenimiento.Entities.Objects.Filters
{
    public class OrdenMasivaFilter
    {
        public string FecIni { get; set; }
        public string FecFin { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Unidad { get; set; }
        public string Chofer { get; set; }
        public bool Generado { get; set; }
        public string Orden { get; set; }
    }
}
