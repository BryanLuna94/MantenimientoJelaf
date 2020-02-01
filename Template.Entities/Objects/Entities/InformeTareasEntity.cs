namespace Mantenimiento.Entities.Objects.Entities
{
    public class InformeTareasEntity
    {
        public int IdInforme { get; set; }
        public int IdTarea { get; set; }
        public string Observacion { get; set; }
        public string FechaInicio { get; set; }
        public int UsuarioRegistro { get; set; }
    }
}
