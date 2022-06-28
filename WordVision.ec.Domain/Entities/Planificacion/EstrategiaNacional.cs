using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class EstrategiaNacional : AuditableEntity
    {
        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        public string MetaRegional { get; set; }
        [Required]
        public string MetaNacional { get; set; }

        //[Required]
        public string FactorCritico { get; set; }

        //[Required]
        public string Indicador { get; set; }

        public int IdEmpresa { get; set; }
        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
        [ForeignKey("IdEstrategia")]
        public ICollection<Gestion> Gestiones { get; set; }
        [ForeignKey("IdEstrategia")]
        public ICollection<ObjetivoEstrategico> ObjetivoEstrategicos { get; set; }

        [ForeignKey("IdEstrategia")]
        public ICollection<IndicadorCicloEstrategico> IndicadorCicloEstrategicos { get; set; }
    }
}
