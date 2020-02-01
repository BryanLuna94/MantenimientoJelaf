using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.Entities.Objects.Entities
{
    public class TareaMecanicosAyudanteEntity
    {
        public int IdAyudante { get; set; }
        public int IdTareaMecanicos { get; set; }
        public string CodMecanico { get; set; }
        public string Observacion { get; set; }
    }
}
