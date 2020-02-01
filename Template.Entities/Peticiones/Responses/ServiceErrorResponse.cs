using System;
using System.Runtime.Serialization;

namespace Mantenimiento.Entities.Peticiones.Responses
{
    [Serializable()]
    [DataContract()]
    public class ServiceErrorResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public string Code { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string SubCode { get; set; }
    }
}
