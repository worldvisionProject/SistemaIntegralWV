using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class AcuerdoDesempenio : AuditableEntity
    {

        public int? Nivel { get; set; }
        [Required]
        public int? Competencia { get; set; }
        [Required]
        public int? Comportamiento { get; set; }
        [Required]
        public string PorQue { get; set; }

    }
}
