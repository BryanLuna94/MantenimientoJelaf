namespace Mantenimiento.Entities.Objects.Entities
{
    public class MTBFEntity
    {
        public decimal Bam { get; set; }
        public short ViajeEnHoras { get; set; }
        public byte HorasDia { get; set; }
        public short Anio { get; set; }
        public byte NumMes { get; set; }
        public byte DiasMes { get; set; }
        public short Viajes { get; set; }
        public short FallasMecanicas { get; set; }
        public string TotalHoras { get; set; }
        public string MTTR { get; set; }
        public short MetaMTBF { get; set; }
        public short MTBFHorasTotales { get; set; }
        public short MTBFDiario { get; set; }
        public short MTBFViajes { get; set; }
        public int KmPerdidos { get; set; }
        public decimal Meta { get; set; }
        public decimal Eficiencia { get; set; }
        public byte CambioTractos { get; set; }
        public decimal DisponibilidadMecanica { get; set; }
        public decimal DisponibilidadFlota { get; set; }
        public System.DateTime FechaHoraRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public int IdMtbf { get; set; }
        public string NombreMes { get; set; }

    }
}
