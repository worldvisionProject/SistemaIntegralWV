using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class IndicadorCicloEstrategico : AuditableEntity
    {
        [Required]
        public string IndicadorCiclo { get; set; }
        public decimal? Meta { get; set; }
        public decimal? Logro { get; set; }

        [Required]
        public int AnioFiscal { get; set; }
        public int IdEstrategia { get; set; }
        public int TipoIndicador { get; set; }
        public int CodigoIndicador { get; set; }
        public int UnidadMedida { get; set; }
        public string ActorParticipante { get; set; }
        public EstrategiaNacional EstrategiaNacionales { get; set; }

        //[ForeignKey("IdIndicadorCicloEstrategico")]
        //public ICollection<MetaCicloEstrategico> MetaCicloEstrategicos { get; set; }
    }
}
