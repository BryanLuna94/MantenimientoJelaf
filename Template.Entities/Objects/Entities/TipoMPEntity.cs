namespace Mantenimiento.Entities.Objects.Entities
{
    public class TipoMPEntity
    {
        public int IdTipMan { get; set; }
        public string Descripcion { get; set; }
        public decimal Kilometros { get; set; }
        public decimal KilometrosAviso { get; set; }
        public int UsuarioRegistro { get; set; }
        public string FechaRegistro { get; set; }
        public string Cod_Marca { get; set; }
        public int Cod_Modelo { get; set; }
        public bool Estado { get; set; }
        public string FlgMov { get; set; }
        public int Dias { get; set; }
        public int DiasAviso { get; set; }
        public int Horas { get; set; }
        public int HorasAviso { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
    }
}
