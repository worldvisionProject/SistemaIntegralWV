using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EParroquiaViewModel
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Código")]
        public string Id { get; set; }

        [Display(Name = "Parroquia")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string par_nombre { get; set; }




        [Display(Name = "Programa")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public SelectList EProgramaList { get; set; }
        public string EProgramaId { get; set; }
        public EPrograma EPrograma { get; set; }




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



        [Display(Name = "Cantón")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public SelectList ECantonList { get; set; }
        [Display(Name = "Cantón")]
        public string ECantonId { get; set; }
        [Display(Name = "Cantón")]
        public ECanton ECanton { get; set; }





        public string OperacionEdicion { get; set; }


    }
}
