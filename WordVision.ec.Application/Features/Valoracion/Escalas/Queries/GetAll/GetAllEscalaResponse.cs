using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.Features.Valoracion.Escalas.Queries.GetAll
{
    public class GetAllEscalaResponse
    {
        public string Calificacion { get; set; }
       
        public string Definicion { get; set; }
    
        public decimal EscalaInicio { get; set; }
      
        public decimal EscalaFin { get; set; }
    }
}
