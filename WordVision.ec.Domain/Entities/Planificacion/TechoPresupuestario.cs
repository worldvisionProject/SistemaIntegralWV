using System.ComponentModel.DataAnnotations;
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
