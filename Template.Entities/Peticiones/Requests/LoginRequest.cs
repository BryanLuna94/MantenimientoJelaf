using Mantenimiento.Entities.Objects.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Mantenimiento.Entities.Peticiones.Requests
{

        [DataContract]
        public class LoginRequest
        {
            [DataMember]
            public UsuarioEntity Usuario { get; set; }
            [DataMember]
            public bool Update { get; set; }
        }
   
}
