namespace Mantenimiento.Entities.Objects.Entities
{
    public class UsuarioEntity
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int Codi_Empresa { get; set; }
        public int Nivel { get; set; }
        public int Sucursal { get; set; }
        public string Terminal { get; set; }
        public string Ben_Codigo { get; set; }
        public string Ben_Nombre { get; set; }
    }
}
