using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
