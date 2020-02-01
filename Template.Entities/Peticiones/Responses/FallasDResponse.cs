using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Lists;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class FallasDResponse
    {
        [DataMember]
        public List<FallasDEntity> List { get; set; }
        public FallasDEntity FallasD { get; set; }
        [DataMember]
        public List<SolicitudRevisionBusquedaList> ListBusqueda { get; set; }
        [DataMember]
        public SolicitudRevisionList SolicitudRevision { get; set; }
        [DataMember]
        public string IdSolicitud { get; set; }
    }

}
