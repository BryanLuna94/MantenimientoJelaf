namespace Mantenimiento.Entities.Objects.Entities
{
    public class TareaSistemaEntity
    {
        public int IdTarea { get; set; }
        public string Tarea_Descripcion { get; set; }
        public int ID_tb_Sistema_Mant { get; set; }
        public string Sistema_Descripcion { get; set; }
        public int Activo { get; set; }
        public string Operacion { get; set; }
    }
}
