using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Donacion.Models
{
    public class InteracionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Gestión")]
        public int Interaciones { get; set; }

        public int Tipo { get; set; }

        [Display(Name = "Observación")]
        public string Observacion { get; set; }

        public SelectList interacionesList { get; set; }

        public SelectList tipoList { get; set; }
    }
   
    }

