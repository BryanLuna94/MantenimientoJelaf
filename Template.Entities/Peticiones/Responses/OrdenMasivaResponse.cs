using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Lists;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mantenimiento.Entities.Peticiones.Responses
{
    [DataContract]
    public class OrdenMasivaResponse
    {
        [DataMember]
        public List<OrdenMasivaList> List { get; set; }
        [DataMember]
        public InformeEntity Informe { get; set; }
    }
}
