using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
