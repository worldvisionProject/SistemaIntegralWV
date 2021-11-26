using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class MetaCicloEstrategico : AuditableEntity
    {
        public int IdGestion { get; set; }
        public decimal? Meta { get; set; }
        public int IdIndicadorCicloEstrategico { get; set; }

        public IndicadorCicloEstrategico IndicadorCicloEstrategicos { get; set; }
    }
}
