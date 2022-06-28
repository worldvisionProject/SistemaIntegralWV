using System;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Web.Areas.Valoracion.Models
{
    public class PlanificacionComportamientoViewModel
    {
        public int Id { get; set; }
        public int IdCompetencia { get; set; }
        public int IdPlanificacion { get; set; }
        public DateTime FechaInicio { get; set; }
         public DateTime FechaFin { get; set; }
        public PlanificacionResultado PlanificacionResultados { get; set; }
    }
}
