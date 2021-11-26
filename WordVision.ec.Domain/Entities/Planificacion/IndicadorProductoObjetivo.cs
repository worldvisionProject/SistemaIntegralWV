using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class IndicadorProductoObjetivo : AuditableEntity
    {
        [Required]
        public string Indicador { get; set; }

        [Required]
        public int AnioFiscal { get; set; }
        public int IdProductoObjetivo { get; set; }
        public ProductoObjetivo ProductoObjetivos { get; set; }
    }
}
