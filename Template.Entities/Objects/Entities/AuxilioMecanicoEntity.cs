using System;

namespace Mantenimiento.Entities.Objects.Entities
{
    public class AuxilioMecanicoEntity
    {
        public int ID_Tb_AuxilioMecanico { get; set; }
        public string Carga { get; set; }
        public string Are_Codigo { get; set; }
        public string Are_Codigo2 { get; set; }
        public decimal Kmt_unidad { get; set; }
        public decimal Kmt_recorrido { get; set; }
        public string MMG { get; set; }
        public string Fechahora_ini { get; set; }
        public string Fechahora_fin { get; set; }
        public string Controlable { get; set; }
        public decimal Id_plataforma { get; set; }
        public short Idtarea_c { get; set; }
        public string Falla { get; set; }
        public string Ben_codigo { get; set; }
        public string Servicio { get; set; }
        public decimal Kmt_Perdido { get; set; }
        public short CambioTracto { get; set; }
        public string Responsable { get; set; }
        public string Atencion { get; set; }
        public string Causa { get; set; }
        public int IdPlan { get; set; }
        
    }
}
