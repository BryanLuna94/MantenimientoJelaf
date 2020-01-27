using System;

namespace Mantenimiento.Entities.Objects.Entities
{
    public class PlanAccionEntity
    {
        public int IdPlan { get; set; }
        public string PlanAccion { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
    }
}
