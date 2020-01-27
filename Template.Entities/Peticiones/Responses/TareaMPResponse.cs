using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class TareaMPResponse
    {
        [DataMember]
        public List<TareaMPEntity> List { get; set; }
        public TareaMPEntity TareaMP { get; set; }
 



    }

}
