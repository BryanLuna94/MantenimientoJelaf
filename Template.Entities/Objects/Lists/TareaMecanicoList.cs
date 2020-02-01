namespace Mantenimiento.Entities.Objects.Lists
{
    public class TareaMecanicoList
    {
        public int IdTareaMecanicos { get; set; }
        public string CodMecanico { get; set; }
        public string Mecanico { get; set; }
        public string FechaInicio { get; set; }
        public string HoraInicio { get; set; }
        public string FechaTermino { get; set; }
        public string HoraTermino { get; set; }
        public string Observacion { get; set; }
    }
}
