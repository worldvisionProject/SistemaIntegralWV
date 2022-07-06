using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class ECantonViewModel
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Código")]
        public string Id { get; set; }

        [Display(Name = "Cantón")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string can_nombre { get; set; }


        [Display(Name = "Región")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public SelectList ERegionList { get; set; }
        [Display(Name = "Región")]
        public int ERegionId { get; set; }
        [Display(Name = "Región")]
        public ERegion ERegion { get; set; }



        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public SelectList EProvinciaList { get; set; }
        [Display(Name = "Provincia")]
        public string EProvinciaId { get; set; }
        [Display(Name = "Provincia")]
        public EProvincia EProvincia { get; set; }


        public string OperacionEdicion { get; set; }


    }
}
