using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EEvaluacionViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Descripción")]
        public string eva_Nombre { get; set; }

        [BindProperty, DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Fecha Desde")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime eva_Desde { get; set; }

        [BindProperty, DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Fecha Hasta")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime eva_Hasta { get; set; }

        public string OperacionEdicion { get; set; }

    }
}
