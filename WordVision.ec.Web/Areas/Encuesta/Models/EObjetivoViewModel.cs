using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EObjetivoViewModel
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(450, MinimumLength = 2)]
        [Display(Name = "Código")]
        public string Id { get; set; }


        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Objetivo")]
        public string obj_Nombre { get; set; }

        [Display(Name = "Nivel")]
        public string obj_Nivel { get; set; }
        [Display(Name = "Outcome")]
        public string obj_Outcome { get; set; }
        [Display(Name = "Output")]
        public string obj_Output { get; set; }
        [Display(Name = "Activity")]
        public string obj_Activity { get; set; }

        [Display(Name = "Objetivo")]
        public string NombreCompleto { get; set; }




        [Display(Name = "Programa Técnico")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public SelectList ProyectoList { get; set; }
        [Display(Name = "Programa Técnico")]
        public string EProyectoId { get; set; }



        public string OperacionEdicion { get; set; }

    }
}
