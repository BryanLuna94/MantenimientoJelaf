namespace Mantenimiento.Entities.Objects.Entities
{
    public class ChecklistMEntity
    {
        public int IdTarea { get; set; }
        public int IDCheckList { get; set; }
        public string CheckList { get; set; }
        public int Estado { get; set; }
        public string UsuarioRegistro { get; set; }
        public string FechaRegistro { get; set; }
        public string HoraRegistro { get; set; }
    }
}
