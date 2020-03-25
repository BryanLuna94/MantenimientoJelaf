using System;

namespace Mantenimiento.Entities.Objects.Others
{
    public class ColumnsTable
    {
        public int id { get; set; }
        public int IdTarea { get; set; }
        public string Tarea_Descripcion { get; set; }
        public int ID_tb_Sistema_Mant { get; set; }
        public string Sistema_Descripcion { get; set; }
        public int Activo { get; set; }
        public string Operacion { get; set; }
    }

    public class ColumnsTableUnion
    {
        public int id { get; set; }
        public int IdTarea1 { get; set; }
        public string Tarea_Descripcion1 { get; set; }
        public string Sistema_Descripcion1 { get; set; }
        public int IdTarea2 { get; set; }
        public string Tarea_Descripcion2 { get; set; }
        public string Sistema_Descripcion2 { get; set; }
    }

}
