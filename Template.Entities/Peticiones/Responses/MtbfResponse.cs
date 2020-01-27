using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Peticiones.Responses
{
    [DataContract]
    public class MtbfResponse
    {
        [DataMember]
        public List<MTBFEntity> List { get; set; }
        [DataMember]
        public MTBFEntity Mtbf { get; set; }
        [DataMember]
        public decimal Bam { get; set; }
        [DataMember]
        public short ViajeEnHoras { get; set; }
        [DataMember]
        public byte HorasDia { get; set; }
    }
}
