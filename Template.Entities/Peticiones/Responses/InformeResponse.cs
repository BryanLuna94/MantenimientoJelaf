using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Lists;

namespace Mantenimiento.Entities.Peticiones.Responses
{
    [DataContract]
    public class InformeResponse
    {
        [DataMember]
        public List<InformeList> List { get; set; }
        [DataMember]
        public List<InformeTareasList> ListInformeTareas { get; set; }
        [DataMember]
        public InformeEntity Informe { get; set; }
        [DataMember]
        public List<TareaMecanicosAyudanteList> ListTareaMecanicosAyudante { get; set; }
        [DataMember]
        public List<TareaMecanicoList> ListTareaMecanico { get; set; }
        [DataMember]
        public List<BusquedaArticuloList> ListBusquedaArticulo { get; set; }
        [DataMember]
        public List<Tb_CtrlBolsaRepInformeEntity> ListBolsas { get; set; }
    }
}
