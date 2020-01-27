namespace Mantenimiento.Entities.Objects.Entities
{
    public class InformeEntity
    {
        public string Are_Codigo { get; set; }
        public string ChoferEntrega { get; set; }
        public decimal KmUnidad { get; set; }
        public string Ofi_Codigo { get; set; }
        public System.DateTime Fecha { get; set; }
        public int CostoManoObra { get; set; }
        public decimal ServicioTerceros { get; set; }
        public decimal CostoRepuestos { get; set; }
        public string Observacion { get; set; }
        public short UsuarioRegistro { get; set; }
        public string Tipo { get; set; }
        public int IdUndAlerta { get; set; }
        public string IdPlanEjecucionTarea { get; set; }
    }
}
