using Mantenimiento.Entities.Peticiones.Responses;
using System.ServiceModel;

namespace Mantenimiento.BusinessLayer
{
    public class BusinessException
    {
        public static FaultException<ServiceErrorResponse> Generar(string strMensaje)
        {
            dynamic serviceErrorResponse = new ServiceErrorResponse();
            serviceErrorResponse.Message = strMensaje;
            throw new FaultException<ServiceErrorResponse>(serviceErrorResponse, new FaultReason(strMensaje));
        }
    }
}
