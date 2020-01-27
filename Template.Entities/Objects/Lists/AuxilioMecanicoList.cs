using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Objects.Lists
{
    public class AuxilioMecanicoList : AuxilioMecanicoEntity
    {
        public string Bus { get; set; }
        public string Carreta { get; set; }
        public string Beneficiario { get; set; }
        public string StrFechaIni { get; set; }
        public string StrFechaFin { get; set; }
    }
}
