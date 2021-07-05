namespace WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetAllCached
{
    public class GetAllIndicadorEstrategicoesCachedResponse
    {
        public int Id { get; set; }
        public string IndicadorResultado { get; set; }
        public string MedioVerificacion { get; set; }
        public int? Responsable { get; set; }
        public int? UnidadMedida { get; set; }
        public decimal? LineaBase { get; set; }
        public decimal? Meta { get; set; }
        public int IdFactorCritico { get; set; }
    }
}