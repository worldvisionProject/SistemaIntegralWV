using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Indicadores.Models
{
    public class FaseProgramaAreaViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        public DateTime FechaDisenio { get; set; }

        [Required]
        public DateTime FechaRedisenio { get; set; }

        [Required]
        public DateTime FechaTransicion { get; set; }

        [StringLength(10)]
        public string Dip1 { get; set; }

        [StringLength(10)]
        public string Dip2 { get; set; }

        [StringLength(10)]
        public string Dip3 { get; set; }

        [StringLength(10)]
        public string Dip4 { get; set; }

        [StringLength(10)]
        public string Dip5 { get; set; }

        [StringLength(10)]
        public string Dip6 { get; set; }

        public int IdProgramaArea { get; set; }
        public ProgramaAreaViewModel ProgramaArea { get; set; }

        public int IdProyectoTecnico { get; set; }
        public ProyectoTecnicoViewModel ProyectoTecnico { get; set; }

        public int IdFaseProyecto { get; set; }
        public DetalleCatalogoViewModel FaseProyecto { get; set; }

        public int IdEstado { get; set; }
        public DetalleCatalogoViewModel Estado { get; set; }


        public SelectList ProgramaAreaList { get; set; }
        public SelectList FaseProyectoList { get; set; }
        public SelectList EstadoList { get; set; }

    }
}
