using System;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Entities.Encuesta;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EIndicadorUsuarioViewModel
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Usuario")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Indicador")]
        //public EIndicador EIndicador { get; set; }
        public SelectList EIndicadorList { get; set; }


    }
}
