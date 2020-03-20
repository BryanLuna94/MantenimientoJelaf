using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class TipoMPResponse
    {
        [DataMember]
        public List<TipoMPEntity> List { get; set; }
        public TipoMPEntity TipoMP { get; set; }


        [DataMember]
        public List<MarcaModeloEntity> FiltroMarca { get; set; }
        [DataMember]
        public List<MarcaModeloEntity> FiltroModelo { get; set; }



    }

}
