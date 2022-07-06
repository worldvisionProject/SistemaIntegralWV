using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class ERegionViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string reg_nombre { get; set; }

        public string OperacionEdicion { get; set; }


    }
}
