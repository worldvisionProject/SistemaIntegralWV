using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetById
{
    public class GetPlanificacionResultadoByIdResponse
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
      
        public int IdResultado { get; set; }

        public decimal? Meta { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public decimal? Ponderacion { get; set; }
        public Resultado Resultados { get; set; }
    }
}
