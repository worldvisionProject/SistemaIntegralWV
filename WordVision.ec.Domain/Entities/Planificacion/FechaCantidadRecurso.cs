using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class FechaCantidadRecurso : AuditableEntity
    {
        [Required]
        public int Mes { get; set; }
        [Required]
        public decimal? Valor { get; set; }

        public Recurso Recursos { get; set; }
    }
}
