using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Filters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mantenimiento.Entities.Peticiones.Requests
{
    [DataContract]
    public class InformeRequest
    {
        [DataMember]
        public InformeFilter Filtro { get; set; }
        [DataMember]
        public InformeTareasEntity InformeTareas { get; set; }
        [DataMember]
        public TareaMecanicosAyudanteEntity TareaMecanicosAyudante { get; set; }
        [DataMember]
        public TareaMecanicosEntity TareaMecanico { get; set; }
        [DataMember]
        public Tb_CtrlBolsaRepInformeEntity Bolsa { get; set; }
        [DataMember]
        public ODMEntity ODM { get; set; }
        [DataMember]
        public ODMdEntity ODMd { get; set; }
    }
}
