using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Valoracion
{
    public class AvanceObjetivo : AuditableEntity
    {
        [Required]
        public DateTime? FechaCumplimiento { get; set; }
        [Required]
        public decimal? Porcentaje { get; set; }
        public string Comentario { get; set; }
        public string ComentarioLider { get; set; }
        public int IdPlanificacion { get; set; }
        public PlanificacionResultado PlanificacionResultados { get; set; }
    }
}
