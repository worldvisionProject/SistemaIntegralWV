namespace WordVision.ec.Application.Features.Planificacion.IndicadorAFes.Queries.GetAllCached
{
    public class GetAllIndicadorAFesCachedResponse
    {
        public int Id { get; set; }
        public decimal? Meta { get; set; }
        public string Entregable { get; set; }
        public int Anio { get; set; }
        public int IdIndicadorEstrategico { get; set; }
    }
}