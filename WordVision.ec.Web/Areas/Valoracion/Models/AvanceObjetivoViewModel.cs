using System;

namespace WordVision.ec.Web.Areas.Valoracion.Models
{
    public class AvanceObjetivoViewModel
    {
        public int Id { get; set; }
        public DateTime? FechaCumplimiento { get; set; }
     
        public decimal? Porcentaje { get; set; }
        public string Comentario { get; set; }
        public string ComentarioLider { get; set; }
        public int IdPlanificacion { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
