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
    public class LogFrame : AuditableEntity
    {
        [Required]
        [StringLength(2)]
        public string OutCome { get; set; }

        [StringLength(2)]
        public string OutPut { get; set; }

        [StringLength(2)]
        public string Activity { get; set; }

        [Required]
        [StringLength(250)]
        public string SumaryObjetives { get; set; }

        public int IdNivel { get; set; }
        [ForeignKey("IdNivel")]
        public DetalleCatalogo Nivel { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public DetalleCatalogo Estado { get; set; }

    }
}
