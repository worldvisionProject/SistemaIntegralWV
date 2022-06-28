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
    public class PlanificacionComportamiento : AuditableEntity
    {
        [Required]
        public int IdCompetencia { get; set; }

        [Required]
        public int IdPlanificacion { get; set; }
      
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
       
        public PlanificacionResultado PlanificacionResultados { get; set; }

       
    }
}
