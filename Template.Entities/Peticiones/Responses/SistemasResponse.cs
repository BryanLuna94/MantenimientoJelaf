using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class SistemasResponse
    {
        [DataMember]
        public List<SistemasEntity> List { get; set; }
        public SistemasEntity Sistemas { get; set; }
 



    }

}
