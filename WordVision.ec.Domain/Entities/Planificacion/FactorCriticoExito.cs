using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class FactorCriticoExito : AuditableEntity
    {
        [Required]
        public string FactorCritico { get; set; }

        public int IdObjetivoEstra { get; set; }
        public ObjetivoEstrategico ObjetivoEstrategicos { get; set; }

        [ForeignKey("IdFactorCritico")]
        public ICollection<IndicadorEstrategico> IndicadorEstrategicos { get; set; }
    }
}
