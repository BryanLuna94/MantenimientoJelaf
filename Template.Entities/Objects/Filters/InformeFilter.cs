namespace Mantenimiento.Entities.Objects.Filters
{
    public class InformeFilter
    {
        public string TipoU { get; set; }
        public string NInforme { get; set; }
        public string Fech_ini { get; set; }
        public string Fech_fin { get; set; }
        public string Orden { get; set; }
        public string NivelUsuario { get; set; }
        public string UsrCodigo { get; set; }
        public bool SoloMiUsuario { get; set; }
    }
}
