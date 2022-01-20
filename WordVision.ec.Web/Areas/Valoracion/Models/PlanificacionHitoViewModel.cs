using System;

namespace WordVision.ec.Web.Areas.Valoracion.Models
{
    public class PlanificacionHitoViewModel
    {
        public int Id { get; set; }
        public int IdPlanificacion { get; set; }
        public string Nombre { get; set; }
        public string Indicador { get; set; }
        public int Tipo { get; set; }
        public decimal Meta { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

    }
}
