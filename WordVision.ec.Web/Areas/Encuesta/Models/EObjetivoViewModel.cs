using System;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EObjetivoViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Objetivo")]
        public string obj_Nombre { get; set; }

    }
}
