using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class IndicadorAF : AuditableEntity
    {
        [Required]
        public decimal? Meta { get; set; }
        public string Entregable { get; set; }
        [StringLength(15)]
        public string Anio { get; set; }
        public decimal? LineaBase { get; set; }
        public int IdIndicadorEstrategico { get; set; }
        public IndicadorEstrategico IndicadorEstrategicos { get; set; }


    }
}
