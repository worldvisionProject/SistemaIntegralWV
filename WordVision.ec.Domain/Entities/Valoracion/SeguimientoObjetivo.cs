using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Valoracion
{
    public class SeguimientoObjetivo : AuditableEntity
    {
        [Required]
        public int Estado { get; set; }
        [Required]
        public int Ultimo { get; set; }
        public int AnioFiscal { get; set; }

        public int IdColaborador { get; set; }
    }
}
