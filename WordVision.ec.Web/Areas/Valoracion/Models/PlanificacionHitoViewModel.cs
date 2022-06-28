using System;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Valoracion.Models
{
    public class PlanificacionHitoViewModel
    {
        public int Id { get; set; }
        public int IdPlanificacion { get; set; }
        public string Nombre { get; set; }
        public string Indicador { get; set; }
        public int Tipo { get; set; }
        [RegularExpression(@"^-?(?:\d+|\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$", ErrorMessage = "Ingese un valor decimal")]
        public string Meta { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }

    }
}
