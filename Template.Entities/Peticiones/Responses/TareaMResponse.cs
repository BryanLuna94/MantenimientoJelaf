using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class TareaMResponse
    {
        [DataMember]
        public List<TareaMEntity> List { get; set; }
        public TareaMEntity TareaM { get; set; }
 



    }

}
