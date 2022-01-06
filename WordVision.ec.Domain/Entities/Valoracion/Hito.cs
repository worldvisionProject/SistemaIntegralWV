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
    public class Hito : AuditableEntity
    {
        [Required]
        public int IdResponsabilidad { get; set; }
        [Required]
        public decimal Meta { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
       
        public Responsabilidad Responsabilidades { get; set; }

        [ForeignKey("IdHito")]
        public ICollection<PlanificacionHito> PlanificacionHitos { get; set; }
    }
}
