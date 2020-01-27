using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Filters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mantenimiento.Entities.Peticiones.Requests
{
    [DataContract]
    public class AuxilioMecanicoRequest
    {
        [DataMember]
        public AuxilioMecanicoFilter Filtro { get; set; }
        [DataMember]
        public AuxilioMecanicoEntity AuxilioMecanico { get; set; }
    }
}
