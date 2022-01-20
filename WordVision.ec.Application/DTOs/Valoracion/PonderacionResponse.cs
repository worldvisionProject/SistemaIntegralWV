using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.DTOs.Valoracion
{
    public class PonderacionResponse
    {
        public int IdObjetivo { get; set; }
        public int AnioFiscal { get; set; }
        public decimal Ponderacion { get; set; }
    }
}
