using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EProgramaViewModel
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(450, MinimumLength = 2)]
        [Display(Name = "Código")]
        public string Id { get; set; }


        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "PA")]
        public string pa_nombre { get; set; }

        public string OperacionEdicion { get; set; }

    }
}
