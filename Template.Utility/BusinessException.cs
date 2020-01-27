using System.ServiceModel;

namespace Mantenimiento.Utility
{
    public static class BusinessException
    {
        public static FaultException<ServiceError> Generate(string strMensaje)
        {
            dynamic serviceErrorResponse = new ServiceError { Message = strMensaje };
            throw new FaultException<ServiceError>(serviceErrorResponse, new FaultReason("Advertencia del lado del servidor"));
        }
    }
}
