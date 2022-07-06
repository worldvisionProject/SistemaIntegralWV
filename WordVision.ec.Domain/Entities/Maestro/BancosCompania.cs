using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class BancosCompania : AuditableEntity
    {
        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string CuentaContable { get; set; }

        [Required]
        public int Estado { get; set; }

    }
}
