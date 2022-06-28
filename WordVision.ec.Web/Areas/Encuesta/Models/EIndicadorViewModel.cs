using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EIndicadorViewModel
    {
        [StringLength(450, MinimumLength = 2)]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string ind_LogFrame { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string ind_Nombre { get; set; }
        public string ind_Resultado { get; set; }
        public string ind_Definicion { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string ind_Fuente { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string ind_Seccion { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string ind_Preguntas { get; set; }
        public string ind_Medicion { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string int_PlanTabulados { get; set; }
        public string ind_UnidadMedida { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int ind_Frecuencia { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public SelectList ind_tipoList { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string ind_proyecto { get; set; }

        public int ObjetivoId { get; set; }
        public EObjetivo EObjetivo { get; set; }



    }
}
