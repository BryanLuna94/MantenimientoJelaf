namespace Mantenimiento.Entities.Objects.Entities
{
    public class Tb_CtrlBolsaRepInformeEntity
    {
        public int IdArticuloTarea { get; set; }
        public string FechaInicio { get; set; }
        public string Codigo { get; set; }
        public string Original { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Solicitado { get; set; }
        public decimal Consumo { get; set; }
        public decimal Pendiente { get; set; }
        public string Tipo { get; set; }
        public string CodiAlmacen { get; set; }
        public int IdTarea { get; set; }
        public int IdInforme { get; set; }
    }
}
