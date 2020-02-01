using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Filters;
using Mantenimiento.Entities.Objects.Lists;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mantenimiento.Entities.Peticiones.Requests
{
    [DataContract]
    public class FallasDRequest
    {
        [DataMember]
        public SolicitudRevisionList SolicitudRevision { get; set; }
    }
}
