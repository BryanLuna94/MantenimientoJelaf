using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class BaseResponse
    {
        [DataMember]
        public List<BaseEntity> List { get; set; }
    }
}
