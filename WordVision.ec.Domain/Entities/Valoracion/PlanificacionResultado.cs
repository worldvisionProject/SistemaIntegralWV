using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Valoracion
{
    public class PlanificacionResultado : AuditableEntity
    {
        [Required]
        public int IdResultado { get; set; }
        [Required]
        public decimal Meta { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
        [Required]
        public decimal Ponderacion { get; set; }
        //public Resultado Resultados { get; set; }
    }
}
