using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Valoracion.Objetivos.Queries.GetById
{
    public class GetObjetivoPonderacionResponse
    {
        public int AnioFiscal { get; set; }
       public decimal Ponderacion { get; set; }
        public int IdObjetivo { get; set; }
        public int Minimo { get; set; }
        public int Maximo { get; set; }
    }
}
