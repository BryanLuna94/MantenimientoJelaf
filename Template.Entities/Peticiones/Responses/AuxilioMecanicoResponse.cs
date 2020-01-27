using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Lists;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mantenimiento.Entities.Peticiones.Responses
{
    [DataContract]
    public class AuxilioMecanicoResponse
    {
        [DataMember]
        public List<AuxilioMecanicoList> List { get; set; }
        [DataMember]
        public AuxilioMecanicoEntity AuxilioMecanico { get; set; }
    }
}
