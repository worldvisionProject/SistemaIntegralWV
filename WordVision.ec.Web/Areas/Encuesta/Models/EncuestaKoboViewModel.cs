using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EncuestaKoboViewModel
    {
        public int Id { get; set; }

        [Display(Name = "ID String")]
        public string enk_Id_string { get; set; }

        [Display(Name = "Título")]
        public string enk_Title { get; set; }

        [Display(Name = "Descripción")]
        public string enk_Description { get; set; }

        [Display(Name = "URL")]
        public string enk_Url { get; set; }

        [Display(Name = "Ult. Actualización")]
        public DateTime enk_Fecha { get; set; }

        [Display(Name = "# de Encuestas")]
        public int NumEncuestados { get; set; }
        
        [Display(Name = "# de Preguntas")]
        public int NumPreguntas { get; set; }


    }
}
