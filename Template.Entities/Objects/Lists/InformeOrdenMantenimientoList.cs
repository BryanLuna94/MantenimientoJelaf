namespace Mantenimiento.Entities.Objects.Lists
{
    public class InformeOrdenMantenimientoList
    {
        public int IdInforme { get; set; }
        public int NumeroInforme { get; set; }
        public string FechaRegistro { get; set; }
        public string Fecha { get; set; }
        public string BusPlaca { get; set; }
        public string Ben_Nombre { get; set; }
        public string Ofi_Nombre { get; set; }
        public decimal KmUnidad { get; set; }
        public int IdTarea { get; set; }
        public string Tarea { get; set; }
        public string Mecanico { get; set; }
        public string Observacion { get; set; }
        public int Estado { get; set; }
        public string Dia { get; set; }

    }
}
