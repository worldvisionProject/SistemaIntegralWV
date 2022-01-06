using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Valoracion
{
    public class PlanificacionHito : AuditableEntity
    {
        [Required]
        public int IdHito { get; set; }
        [Required]
        public decimal Meta { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
      
        public Hito Hitos { get; set; }
    }
}
