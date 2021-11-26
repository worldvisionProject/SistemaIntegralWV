using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class FechaCantidadRecurso : AuditableEntity
    {
        [Required]
        public int Mes { get; set; }
        [Required]
        public decimal? Valor { get; set; }
        public int IdRecurso { get; set; }
        public Recurso Recursos { get; set; }
    }
}
