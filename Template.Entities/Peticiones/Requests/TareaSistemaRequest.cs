using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Filters;
using Mantenimiento.Entities.Objects.Lists;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mantenimiento.Entities.Peticiones.Requests
{
    [DataContract]
    public class TareaSistemaRequest
    {
        [DataMember]
        public List<TareaSistemaEntity> ListInsertar { get; set; }

        [DataMember]
        public string Are_Codigo { get; set; }

        [DataMember]
        public string IdClaseMantenimiento { get; set; }

        [DataMember]
        public string Operacion { get; set; }

    }
}
