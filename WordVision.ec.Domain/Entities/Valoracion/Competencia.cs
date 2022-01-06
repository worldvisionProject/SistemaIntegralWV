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
    public class Competencia : AuditableEntity
    {
        [Required]
        public int IdCompetencia { get; set; }
        [Required]
        public int Comportamiento { get; set; }
        //[Required]
        //public int Tipo { get; set; }
        //public ObjetivoAnioFiscal ObjetivoAnioFiscales { get; set; }
        //[ForeignKey("IdResponsabilidad")]
        //public ICollection<PlanificacionResponsabilidad> PlanificacionResponsabilidades { get; set; }
    }
}
