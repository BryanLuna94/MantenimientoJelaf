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
    public static class MarcaModeloLogic
    {

        public static Response<MarcaModeloResponse> ListMarcaModelo()
        {
            try
            {
                Response<MarcaModeloResponse> response;
                List<MarcaModeloEntity> List;

                List = MarcaModeloData.ListMarcaModelo();

                response = new Response<MarcaModeloResponse>
                {
                    EsCorrecto = true,
                    Valor = new MarcaModeloResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<MarcaModeloResponse>(false, null, Functions.MessageError(ex), false);
            }
        } 
    }

     


}
