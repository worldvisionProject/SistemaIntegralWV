using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EIndicadorViewModel
    {
        [Display(Name = "Código")]
        [StringLength(450, MinimumLength = 2)]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Id { get; set; }

        [Display(Name = "LogFrame")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string ind_LogFrame { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string ind_Nombre { get; set; }

        [Display(Name = "Resultado")]
        public string ind_Resultado { get; set; }

        [Display(Name = "Definición")]
        public string ind_Definicion { get; set; }


        [Display(Name = "Fuente")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string ind_Fuente { get; set; }

        [Display(Name = "Sección")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string ind_Seccion { get; set; }


        [Display(Name = "Preguntas")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string ind_Preguntas { get; set; }

        [Display(Name = "Medición")]
        public string ind_Medicion { get; set; }


        [Display(Name = "Plan Tabulados")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string int_PlanTabulados { get; set; }

        [Display(Name = "Unidad Medida")]
        public string ind_UnidadMedida { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]


        [Display(Name = "Frecuencia")]
        public SelectList ind_FrecuenciaList { get; set; }
        [Display(Name = "Frecuencia")]
        public int ind_Frecuencia { get; set; }



        [Display(Name = "Tipo Indicador")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public SelectList ind_tipoList { get; set; }
        [Display(Name = "Tipo Indicador")]
        public string ind_tipo { get; set; }


        [Display(Name = "Operación")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public SelectList ind_OperacionList { get; set; }
        [Display(Name = "Operación")]
        public string ind_Operacion { get; set; }



        [Display(Name = "Objetivo")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public SelectList ObjetivoList { get; set; }
        [Display(Name = "Objetivo")]
        public string EObjetivoId { get; set; }



        public string OperacionEdicion { get; set; }


    }
}
