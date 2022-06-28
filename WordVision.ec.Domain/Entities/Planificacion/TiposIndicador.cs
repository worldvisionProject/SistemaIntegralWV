using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
    public class TiposIndicador : AuditableEntity
    {
        [Required]
        public int CodigoTipoIndicador { get; set; }
        [Required]
        [StringLength(50)]
        public string CodigoIndicador { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
