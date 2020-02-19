using System;

namespace Mantenimiento.Utility
{
    public class Constants
    {
        // Security
        public const string UnaLlave = "JLM_2010/*SEGURIDAD";

        // Message
        public const string USUARIO_NO_EXISTE = "Usuario incorrecto";
        public const string CLAVE_INCORRECTA = "La clave ingresada es incorrecta";
        public const string CLAVE_AUTORIZACION_INCORRECTA = "La clave de autorizacion ingresada es incorrecta";
        public const string USUARIO_NO_ACTIVO = "Acceso denegado. Su usuario se encuentra actualmente inactivo";
        public const string CLAVE_VACIA = "Debe escribir una nueva clave";
        public const string CODIGO_VACIO = "Debe escoger un nuevo código";
        public const string DESCRIPCION_VACIA = "Debe ingresar una descripción";
        public const string NO_ELIMINO = "No se ha eliminado el registro";
        public const string YA_EXISTE = "Este registro ya existe";
        // Estados
        public const Int16 GENERADO = 1;
        public const Int16 PENDIENTE = 2;
        public const Int16 INCOMPLETO = 3;
        public const Int16 LIQUIDADO = 4;
        public const Int16 ANULADO = 5;
        public const Int16 ENTREGADO = 6;
        public const Int16 DEVUELTO = 7;

        public class Configuracion
        {
            public const int CODIGO_MAXIMO_ODOMETRO_FALLAS = 1;
            public const int CODIGO_MINIMO_ODOMETRO_FALLAS = 1;
        }

        public class EstadosInforme
        {
            public const byte ANULADO = 0;
            public const byte ACTIVO = 1;
            public const byte CERRADO = 2;
            public const byte BACK_LOG = 3;
        }

        public class TipoInforme
        {
            public const string CORRECTIVO = "1";
            public const string PREVENTIVO = "0";
        }
    }
}
