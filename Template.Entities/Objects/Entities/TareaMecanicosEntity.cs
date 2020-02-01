namespace Mantenimiento.Entities.Objects.Entities
{
    public class TareaMecanicosEntity
    {
        public int IdInforme { get; set; }
        public int IdTarea { get; set; }
        public string FechaInicio { get; set; }
        public string HoraInicio { get; set; }
        public string FechaTermino { get; set; }
        public string HoraTermino { get; set; }
        public string CodMecanico { get; set; }
        public string Observacion { get; set; }
        public int UsuarioRegistro { get; set; }
    }
}
