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
        public int IdPlanificacion { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Indicador { get; set; }
        [Required]
        public int Tipo { get; set; }
        [Required]
        public decimal Meta { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
      
        public PlanificacionResultado PlanificacionResultados { get; set; }
    }
}
