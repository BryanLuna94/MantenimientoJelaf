using System.Collections.Generic;
using System.Runtime.Serialization;
using Mantenimiento.Entities.Objects.Entities;

namespace Mantenimiento.Entities.Requests.Responses
{
    [DataContract]
    public class ProductoResponse
    {
        [DataMember]
        public List<ProductoEntity> List { get; set; }
        public ProductoEntity Producto { get; set; }
 
    }

}
