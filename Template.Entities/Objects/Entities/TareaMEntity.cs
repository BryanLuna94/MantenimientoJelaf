namespace Mantenimiento.Entities.Objects.Entities
{
    public class TareaMEntity
    {
        public int IdTarea { get; set; }
        public int IdTipMan { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioRegistro { get; set; }
        public string FechaRegistro { get; set; }
        public int Estado { get; set; }
        public string Flg_Revision { get; set; }
        public int MinutosLabor { get; set; }
        public decimal CostoTopeExterno { get; set; }
        public decimal CostoInternoPorMin { get; set; }
        public decimal CostoIndirectoPorMinRef { get; set; }
        public int ID_tb_Sistema_Mant { get; set; }
        public string ID_tb_SubSistema_Mant { get; set; }
    }
}
