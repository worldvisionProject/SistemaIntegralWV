using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EProyectoViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Programa Técnico")]
        public string py_nombre { get; set; }

        public string OperacionEdicion { get; set; }

    }
}
