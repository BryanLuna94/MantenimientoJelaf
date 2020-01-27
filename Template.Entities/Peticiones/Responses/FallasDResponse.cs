using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class FallasDResponse
    {
        [DataMember]
        public List<FallasDEntity> List { get; set; }
        public FallasDEntity FallasD { get; set; }
 



    }

}
