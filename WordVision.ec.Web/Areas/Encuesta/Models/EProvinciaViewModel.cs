using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EProvinciaViewModel
    {
        [Display(Name = "Código")]
        [StringLength(450, MinimumLength = 2)]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Id { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string pro_nombre { get; set; }


        [Display(Name = "Región")]
        public SelectList ERegionList { get; set; }
        public string ERegionId { get; set; }

        public ERegion ERegion { get; set; }
        public string OperacionEdicion { get; set; }


    }
}
