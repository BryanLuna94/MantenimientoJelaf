using System;

namespace Mantenimiento.Entities.Objects.Entities
{
    public class ODMEntity
    {
        public string Emp_Codigo { get; set; }
        public string ODM_Incluye { get; set; }
        public string Are_Codigo { get; set; }
        public DateTime ODM_Fecha { get; set; }
        public string ODM_Hora { get; set; }
        public string ODM_Observacion { get; set; }
        public string ODM_FechMovimiento { get; set; }
        public string ODM_FechContable { get; set; }
        public string ODM_FechVencimiento { get; set; }
        public string Ben_Codigo_Jefe { get; set; }
        public string Ben_Codigo_Solicitante { get; set; }
        public string Suc_Codigo { get; set; }
        public string Ofi_Codigo { get; set; }
        public decimal ODM_Informe { get; set; }
        public string ODM_Estado { get; set; }
        public decimal ODM_Codigo { get; set; }
        public int IdTareaMecanicos { get; set; }
        public string Usr_Codigo { get; set; }
    }
}
