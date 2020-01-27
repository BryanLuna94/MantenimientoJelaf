using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class LoginResponse
    {
        [DataMember]
        public UsuarioEntity Usuario { get; set; }
    }

    public class PwdResponse
    {
        [DataMember]
        public UsuarioEntity Usuario { get; set; }
        public bool Update { get; set; }
    }
}
