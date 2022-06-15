using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Maestro
{
    public class MarcoLogico : AuditableEntity
    {
        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(70)]
        public string Responsable { get; set; }
        [StringLength(2)]
        public string Estado { get; set; }

        public ICollection<IndicadorPR> Indicadores { get; set; }

    }
}
