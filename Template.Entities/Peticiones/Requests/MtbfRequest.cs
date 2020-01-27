using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Filters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mantenimiento.Entities.Peticiones.Requests
{
    [DataContract]
    public class MtbfRequest
    {
        [DataMember]
        public decimal Bam { get; set; }
        [DataMember]
        public short Anio { get; set; }
        [DataMember]
        public short ViajeEnHoras { get; set; }
        [DataMember]
        public byte HorasDia { get; set; }
        [DataMember]
        public List<MTBFEntity> ListMtbf { get; set; }
    }
}
