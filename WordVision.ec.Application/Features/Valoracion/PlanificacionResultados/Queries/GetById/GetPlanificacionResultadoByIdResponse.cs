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
        public string DatoManual1 { get; set; }

        public string DatoManual2 { get; set; }
        public int DatoManual3 { get; set; }
        public int ReportaId { get; set; }
        public int Estado { get; set; }
        public string ObservacionLider { get; set; }
        public DateTime? FechaCumplimiento { get; set; }
        public decimal? PorcentajeCumplimiento { get; set; }
        public decimal? PonderacionResultado { get; set; }
        public Resultado Resultados { get; set; }
        public ICollection<PlanificacionHito> PlanificacionHitos { get; set; }
        public ICollection<AvanceObjetivo> AvanceObjetivoS { get; set; }
        public ICollection<PlanificacionComportamiento> PlanificacionComportamientos { get; set; }
    }
}
