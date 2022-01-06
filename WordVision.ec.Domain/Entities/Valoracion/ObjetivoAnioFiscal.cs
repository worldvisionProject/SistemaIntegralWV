using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Domain.Entities.Valoracion
{
    public class ObjetivoAnioFiscal
    {
        [Required]
        public int AnioFiscal { get; set; }
        [Required]
        public decimal Ponderacion { get; set; }
        public int IdObjetivo { get; set; }
        public Objetivo Objetivos { get; set; }
    }
}
