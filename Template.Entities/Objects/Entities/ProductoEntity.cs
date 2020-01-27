namespace Mantenimiento.Entities.Objects.Entities
{
    public class ProductoEntity
    {
                   
        public double ID_Key { get; set; }
        public double ID_Index { get; set; }
        public double Index_Compañia { get; set; }
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public string CodigoOriginal { get; set; }
        public string DescripcionOriginal { get; set; }
        public string CodigoAlternativo { get; set; }
        public int Index_Marca { get; set; }
        public string Marca { get; set; }
        public int Index_Modelo { get; set; }
        public string Modelo { get; set; }
    }
}
