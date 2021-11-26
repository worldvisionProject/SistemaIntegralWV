namespace WordVision.ec.Web.Areas.Planificacion.Models
{
    public class MetaCicloEstrategicoViewModel
    {
        public int IdGestion { get; set; }
        public decimal? Meta { get; set; }
        public decimal? IdEmpresa { get; set; }
        public int IdIndicadorCicloEstrategico { get; set; }

        public IndicadorCicloEstrategicoViewModel IndicadorCicloEstrategicos { get; set; }
    }
}
