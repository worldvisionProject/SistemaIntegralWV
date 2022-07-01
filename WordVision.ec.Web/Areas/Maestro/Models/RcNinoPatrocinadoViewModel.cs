﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Web.Common.Constants;

namespace WordVision.ec.Web.Areas.Maestro.Models
{
    public class RcNinoPatrocinadoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Comunidad")]
        public string Comunidad { get; set; }

        [Display(Name = "Edad")]
        public int? Edad { get; set; }

        public bool Patrocinado { get; set; }

        public int IdGrupoEtario { get; set; }
        public DetalleCatalogoViewModel GrupoEtario { get; set; }

        public int IdGenero { get; set; }
        public DetalleCatalogoViewModel Genero { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }

        public int IdProgramaArea { get; set; }
        public ProgramaAreaViewModel ProgramaArea { get; set; }

        public SelectList EstadoList { get; set; }
        public SelectList GeneroList { get; set; }
        public SelectList GrupoEtarioList { get; set; }
        public SelectList ProgramaAreaList { get; set; }
    }
}
