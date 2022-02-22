namespace WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Queries.GetById
{
    public class GetIndicadorCicloEstrategicoByIdResponse
    {

        public int Id { get; set; }
        public string IndicadorCiclo { get; set; }
        public decimal? Meta { get; set; }
        public decimal? Logro { get; set; }
        public decimal? LineBase { get; set; }
        public int AnioFiscal { get; set; }
        public int IdEstrategia { get; set; }
        public int TipoIndicador { get; set; }
        public int CodigoIndicador { get; set; }
        public int UnidadMedida { get; set; }
        public int ActorParticipante { get; set; }
        //public ICollection<MetaCicloEstrategico> MetaCicloEstrategicos { get; set; }
        public int AnioFiscal2 { get; set; }
        public decimal? Meta2 { get; set; }
        public decimal? Logro2 { get; set; }
        public decimal? LineBase2 { get; set; }

        public int AnioFiscal3 { get; set; }
        public decimal? Meta3 { get; set; }
        public decimal? Logro3 { get; set; }
        public decimal? LineBase3 { get; set; }

        public int AnioFiscal4 { get; set; }
        public decimal? Meta4 { get; set; }
        public decimal? Logro4 { get; set; }
        public decimal? LineBase4 { get; set; }
        public decimal? MetaAcumulada { get; set; }
        public int TipoMeta { get; set; }
    }
}
