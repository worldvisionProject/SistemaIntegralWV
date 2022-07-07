using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EMetaViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public decimal met_valor { get; set; }




        [Display(Name = "Evaluación")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public SelectList EEvaluacionList { get; set; }
        [Display(Name = "Evaluación")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int EEvaluacionId { get; set; }
        [Display(Name = "Evaluación")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public EEvaluacion EEvaluacion { get; set; }    


        [Display(Name = "Indicador")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public SelectList EIndicadorList { get; set; }
        [Display(Name = "Indicador")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string EIndicadorId { get; set; }
        [Display(Name = "Indicador")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public EIndicador EIndicador { get; set; }  



        [Display(Name = "Programa")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public SelectList EProgramaList { get; set; }
        [Display(Name = "Programa")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string EProgramaId { get; set; }
        [Display(Name = "Programa")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public EPrograma EPrograma { get; set; }



        public string OperacionEdicion { get; set; }


    }
}
