using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Contracts;

namespace WordVision.ec.Domain.Entities.Planificacion
{
   public class IndicadorAF : AuditableEntity
    {
        [Required]
        public decimal? Meta { get; set; }
        public string Entregable { get; set; }
        public int Anio { get; set; }
        public int IdIndicadorEstrategico { get; set; }
        public IndicadorEstrategico IndicadorEstrategicos { get; set; }

     
    }
}
