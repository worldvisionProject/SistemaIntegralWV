using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Valoracion
{
    public class Resultado : AuditableEntity
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Indicador { get; set; }
        [Required]
        public int Tipo { get; set; }
        public int IdObjetivoAnioFiscal { get; set; }
        public ObjetivoAnioFiscal ObjetivoAnioFiscales { get; set; }

        //[ForeignKey("IdResultado")]
        //public ICollection<PlanificacionResultado> PlanificacionResultados { get; set; }
    }
}
