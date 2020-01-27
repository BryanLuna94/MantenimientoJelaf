using System;
using System.Runtime.Serialization;

namespace Mantenimiento.Utility
{
    [Serializable()]
    [DataContract()]
    public class ServiceError
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
