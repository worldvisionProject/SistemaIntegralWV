using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class TechoPresupuestario : AuditableEntity
    {
        [Required]
        [StringLength(25)]
        public string CodigoCC { get; set; }
        [Required]
        public string DescripcionCC { get; set; }
        [Required]
        public decimal? Techo { get; set; }
    }
}
