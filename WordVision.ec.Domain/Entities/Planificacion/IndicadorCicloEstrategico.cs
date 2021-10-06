using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class IndicadorCicloEstrategico : AuditableEntity
    {
        [Required]
        public string IndicadorCiclo { get; set; }
        public int IdEstrategia { get; set; }
        public EstrategiaNacional EstrategiaNacionales { get; set; }

        [ForeignKey("IdIndicadorCicloEstrategico")]
        public ICollection<MetaCicloEstrategico> MetaCicloEstrategicos { get; set; }
    }
}
