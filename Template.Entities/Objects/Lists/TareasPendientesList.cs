using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.Entities.Objects.Lists
{
    public class TareasPendientesList
    {
        public short idtipman { get; set; }
        public string Descripcion { get; set; }
        public short IdTarea { get; set; }
        public string DescripcionTarea { get; set; }
        public string UnidadId { get; set; }
        public decimal KmtAviso { get; set; }
        public decimal KmtActual { get; set; }
        public DateTime fechainforme { get; set; }
        public int NroInforme { get; set; }
        // 20200218 INICIO
        public int Horas { get; set; }
        public int HorasRecorrido { get; set; }
        public int Dias { get; set; }
        public int DiasRecorrido { get; set; }
        // 20200218 FIN
    }
}
