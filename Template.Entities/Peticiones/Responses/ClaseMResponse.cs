using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class ClaseMResponse
    {
        [DataMember]
        public List<ClaseMEntity> List { get; set; }
        public ClaseMEntity ClaseM { get; set; }
 



    }

}
