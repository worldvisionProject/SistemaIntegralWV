using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
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
        public int IdDonante { get; set; }

        public List<InteracionListaViewModel> ListaInteracciones { get; set; }
    }

    public class InteracionListaViewModel
    {
        public int Id { get; set; }

       
        public int Interaciones { get; set; }

        public int Tipo { get; set; }

      
        public string Observacion { get; set; }

       
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }

}

