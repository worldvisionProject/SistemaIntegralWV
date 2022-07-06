using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WordVision.ec.Web.Areas.Encuesta.Models
{
    public class EReporteConsolidadoViewModel
    {
        [Display(Name = "Proyecto")]
        public string rpt_Proyecto { get; set; }
        [Display(Name = "Programa")]
        public string rpt_Programa { get; set; }
        [Display(Name = "Log Frame")]
        public string rpt_LogFrame { get; set; }
        [Display(Name = "Objetivo")]
        public string rpt_Objetivo { get; set; }
        [Display(Name = "Código Indicador")]
        public string rpt_IndicadorCodigo { get; set; }
        [Display(Name = "Indicador")]
        public string rpt_IndicadorNombre { get; set; }
        [Display(Name = "Unidad de Medida")]
        public string rpt_UnidadMedida { get; set; }
        [Display(Name = "Frecuencia")]
        public string rpt_Frecuencia { get; set; }
        [Display(Name = "Línea Base")]
        public decimal? rpt_LineaBaseResultado { get; set; }
        [Display(Name = "Año 4 Meta")]
        public decimal? rpt_Anio4_meta { get; set; }
        [Display(Name = "Año 4 Result")]
        public decimal? rpt_Anio4_ejec { get; set; }
        [Display(Name = "Año 5 Meta")]
        public decimal? rpt_Anio5_meta { get; set; }
        [Display(Name = "Año 5 Result")]
        public decimal? rpt_Anio5_ejec { get; set; }
        [Display(Name = "Año 6 Meta")]
        public decimal? rpt_Anio6_meta { get; set; }
        [Display(Name = "Año 6 Result")]
        public decimal? rpt_Anio6_ejec { get; set; }
        [Display(Name = "Total Meta")]
        public decimal? rpt_Total_meta { get; set; }
        [Display(Name = "Total Result")]
        public decimal? rpt_Total_ejec { get; set; }


        public int rpt_Region { get; set; }
        [Display(Name = "")]
        public string rpt_Provincia { get; set; }
        [Display(Name = "")]
        public string rpt_Canton { get; set; }
        [Display(Name = "")]
        public string rpt_Parroquia { get; set; }



    }
}
