using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class ArticuloTResponse
    {
        [DataMember]
        public List<ArticuloTEntity> List { get; set; }
        public ArticuloTEntity ArticuloT { get; set; }
 
    }

}
