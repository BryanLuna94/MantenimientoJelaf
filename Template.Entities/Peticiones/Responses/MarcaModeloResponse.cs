using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class MarcaModeloResponse
    {
        [DataMember]
        public List<MarcaModeloEntity> List { get; set; }
        public MarcaModeloEntity MarcaModelo { get; set; }

        [DataMember]
        public List<MarcaModeloEntity> FiltroMarca { get; set; }
        [DataMember]
        public List<MarcaModeloEntity> FiltroModelo { get; set; }
    }

}
