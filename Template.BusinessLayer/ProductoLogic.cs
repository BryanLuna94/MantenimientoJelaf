using System.Collections.Generic;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Mantenimiento.DataAccess;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Others;
using Mantenimiento.Entities.Requests.Responses;
using Mantenimiento.Utility;

namespace Mantenimiento.BusinessLayer
{
    public static class ProductoLogic
    {
 

        public static Response<ProductoResponse> ListProducto(short Index_Compañia, string filtro)
        {
            try
            {
                Response<ProductoResponse> response;
                List<ProductoEntity> List;

                List = ProductoData.ListProducto(Index_Compañia, filtro);

                response = new Response<ProductoResponse>
                {
                    EsCorrecto = true,
                    Valor = new ProductoResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<ProductoResponse>(false, null, Functions.MessageError(ex), false);
            }
        }
         
    }




}
