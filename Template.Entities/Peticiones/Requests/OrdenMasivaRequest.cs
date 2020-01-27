using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Filters;
using Mantenimiento.Entities.Objects.Lists;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mantenimiento.Entities.Peticiones.Requests
{
    [DataContract]
    public class OrdenMasivaRequest
    {
        [DataMember]
        public OrdenMasivaFilter Filtro { get; set; }
        [DataMember]
        public List<OrdenMasivaList> ListInsertar { get; set; }
        [DataMember]
        public string FechaGenerar { get; set; }
        [DataMember]
        public string UsuarioRegistro { get; set; }
    }
}
