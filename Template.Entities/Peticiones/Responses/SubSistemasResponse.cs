using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class SubSistemasResponse
    {
        [DataMember]
        public List<SubSistemasEntity> List { get; set; }
        public SubSistemasEntity SubSistemas { get; set; }
 



    }

}
