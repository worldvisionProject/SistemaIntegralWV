namespace WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Queries.GetById
{
    public class GetIndicadorCicloEstrategicoByIdResponse
    {

        public int Id { get; set; }
        public string IndicadorCiclo { get; set; }
        public decimal? Meta { get; set; }
        public decimal? Logro { get; set; }
        public int AnioFiscal { get; set; }
        public int IdEstrategia { get; set; }
        public int TipoIndicador { get; set; }
        public int CodigoIndicador { get; set; }
        public int UnidadMedida { get; set; }
        public string ActorParticipante { get; set; }
        //public ICollection<MetaCicloEstrategico> MetaCicloEstrategicos { get; set; }
    }
}
