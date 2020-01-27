using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class TipoMResponse
    {
        [DataMember]
        public List<TipoMEntity> List { get; set; }
        public TipoMEntity TipoM { get; set; }
 



    }

}
