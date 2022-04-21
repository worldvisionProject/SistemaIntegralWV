using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVision.ec.Application.DTOs.Valoracion
{
    public class ComportamientoResponse
    {       public int IdCompetencia { get; set; }
           public string DescCompetencia { get; set; }
           public int IdPlanificacion { get; set; }

           
            public DateTime FechaInicio { get; set; }
          
            public DateTime FechaFin { get; set; }

        
    }
}
